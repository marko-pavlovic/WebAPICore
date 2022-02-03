using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DBCommunication.Dtos.Token;
using DBCommunication.Identity;
using DBCommunication.JsonSettings;

namespace DBCommunication.Services
{
    public class TokenService
    {
        private readonly JwtTokenClientJsonSettings _jwtTokenClientJsonSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserDataService _userDataService;

        public TokenService(
            IOptions<JwtTokenClientJsonSettings> jwtTokenClientSettings,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            UserDataService userDataService)
        {
            _jwtTokenClientJsonSettings = jwtTokenClientSettings.Value;
            _userManager = userManager;
            _roleManager = roleManager;
            _userDataService = userDataService;
            
        }

        private async Task<string> CreateAccessTokenAsync(
            ApplicationUser appUser,
            DateTime currentTime)
        {

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));

            var roleName = (await _userManager.GetRolesAsync(appUser)).FirstOrDefault();
            var role = _roleManager.Roles.FirstOrDefault(r => r.Name == roleName);
            claims.Add(new Claim(ClaimTypes.Role, role.Name));

            var userRolesClaims = await _roleManager.GetClaimsAsync(role);
            
            claims.AddRange(userRolesClaims);

            var token = CreateAccessTokenFromClaims(currentTime, claims);
            
            return token;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtTokenClientJsonSettings.ClientSecret)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private string CreateAccessTokenFromClaims(
            DateTime currentTime,
            IEnumerable<Claim> claims)
        {
            //var expiresAt = currentTime.AddDays(
            //    _jwtTokenClientJsonSettings.AccessTokenExpiresTimeInMinutes);

            var expiresAt = currentTime.AddMinutes(
                _jwtTokenClientJsonSettings.AccessTokenExpiresTimeInMinutes);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(_jwtTokenClientJsonSettings.ClientSecret)),
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return accessToken;
        }

        public async Task<bool> RemoveTokenAsync(ApplicationUser appUser, string refreshToken)
        {
            var result = await _userDataService.RemoveTokenAsync(appUser.Id, refreshToken);

            return result;
        }

        public async Task<TokenClientSideDto> CreateTokensAsync(ApplicationUser appUser)
        {
            var currentTime = DateTime.Now;

            var refreshToken = RefreshTokenGenerator.GenerateRefreshToken();
            var accessToken = await CreateAccessTokenAsync(appUser, currentTime);

            var expiresAt = currentTime
                .AddMinutes(_jwtTokenClientJsonSettings.RefreshTokenExpiresTimeInMinutes);

            await _userDataService.StoreUserTokenExpiresAtAsync(appUser.Id, refreshToken, expiresAt);

            var result = new TokenClientSideDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return result;
        }
        
        public async Task<TokenClientSideDto> RefreshAccessTokenAsync(
            string userName,
            string accessToken,
            string refreshTokenClientSide)
        {
            var appUser = await _userManager.FindByNameAsync(userName);

            var currentTime = DateTime.Now;

            //read from token from memory
            var refreshTokenExpiresAt = await _userDataService.GetUserTokenExpiresAtAsync(appUser.Id, refreshTokenClientSide);

            if (currentTime > refreshTokenExpiresAt)
                throw new Exception("Expired Refresh Token");

            var accessTokenPrincipal = GetPrincipalFromExpiredToken(accessToken);

            var expiresAt = currentTime
                .AddMinutes(_jwtTokenClientJsonSettings.RefreshTokenExpiresTimeInMinutes);
            //store new refreshtoken in redis 
            await _userDataService.UpdateUserTokenExpiresAtAsync(appUser.Id, refreshTokenClientSide, expiresAt);

            return new TokenClientSideDto
            {
                AccessToken = CreateAccessTokenFromClaims(currentTime, accessTokenPrincipal.Claims),
                RefreshToken = refreshTokenClientSide
            };
        }
    }
}
