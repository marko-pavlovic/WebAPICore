using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WebAPICore.Identity;
using WebAPICore.Dtos.Token;
using Utilities.Exceptions;

namespace WebAPICore.Services
{
    public class AccountService
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public AccountService(TokenService tokenService,
                              UserManager<ApplicationUser> userManager,
                              ILogger<AccountService> logger)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _logger = logger;
        }

        private async Task<ApplicationUser> GetAppUserAysnc(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null)
                throw new NotFoundException("User", userName);

            return appUser;
        }

        private async Task<ApplicationUser> GetEnabledUserAsync(string userName)
        {
            var appUser = await GetAppUserAysnc(userName);

            var lockedOut = await _userManager.IsLockedOutAsync(appUser);
            if (lockedOut)
                throw new InternalServerErrorException("User with UserName: " + userName + " is locked!");

            return appUser;
        }

        public async Task<TokenClientSideDto> SignInAsync(string userName, string password)
        {
            var appUser = await GetEnabledUserAsync(userName);

            var correctPassword = await _userManager.CheckPasswordAsync(appUser, password);
            if (!correctPassword)
            {
                await _userManager.AccessFailedAsync(appUser);

                throw new NotFoundException("Password", password);
            }

            await _userManager.ResetAccessFailedCountAsync(appUser);
            var token = await _tokenService.CreateTokensAsync(appUser);

            return token;
        }

        public async Task<bool> SignOutAsync(string refreshToken, string userName)
        {
            var appUser = await GetAppUserAysnc(userName);

            var removedToken = await _tokenService.RemoveTokenAsync(appUser, refreshToken);

            if (!removedToken)
                throw new NotFoundException("Token", refreshToken);

            return true;
        }

        //public async Task<bool> ConfirmEmailAsync(string token, string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user == null)
        //        throw new NotFoundException("User", email);

        //    var result = await _userManager.ConfirmEmailAsync(user, token);

        //    if (!result.Succeeded)
        //        throw new NotFoundException("Token", token);

        //    return result.Succeeded;
        //}

        public async Task<bool> RestartPasswordAsync(string userName, string password, string token)
        {
            var appUser = await _userManager.FindByNameAsync(userName);

            var result = await _userManager.ResetPasswordAsync(appUser, token, password);

            return result.Succeeded;
        }
    }
}
