using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPICore.Dtos.Role;
using Utilities.Exceptions;
using Utilities.SimpleObjects;

namespace WebAPICore.Services
{
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<UserService> _logger;

        public RoleService(
            RoleManager<IdentityRole> roleManager,
            ILogger<UserService> logger)
        {
            _roleManager = roleManager;
            _logger = logger;
        }

        private async Task<IdentityRole> GetRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
                throw new NotFoundException("Role", roleName);

            return role;
        }

        public async Task<List<IdAndName>> GetAsync()
        {
            var roles = await _roleManager.Roles
                .Select(r => new IdAndName(r.Id, r.Name))
                .ToListAsync();

            return roles;
        }

        public async Task<RoleDto> GetAsync(string roleName)
        {
            var role = await GetRoleAsync(roleName);
            var claims = await _roleManager.GetClaimsAsync(role);

            var result = new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Claims = claims.Select(c => c.Value).ToList()
            };

            return result;
        }

        public async Task<bool> DeleteAsync(string roleName)
        {
            var role = await GetRoleAsync(roleName);

            var identityResult = await _roleManager.DeleteAsync(role);

            if (identityResult.Succeeded)
                return true;
            else
                throw new InternalServerErrorException(
                    "Delete with Name: " + roleName + " Failed");
        }

        public async Task<string> CreateAsync(RoleCreateDto roleCreate)
        {
            var role = new IdentityRole
            {
                Name = roleCreate.Name
            };

            var identityResult = await _roleManager.CreateAsync(role);

            if (identityResult.Succeeded && roleCreate.Claims != null)
            {
                foreach (var claim in roleCreate.Claims)
                {
                    await _roleManager.AddClaimAsync(role, new Claim("Permission", claim));
                }
            }

            return role.Id;
        }

        public async Task<bool> UpdateAsync(string roleName, List<string> claims)
        {
            if (claims != null && claims.Count > 0)
            {
                var role = await GetRoleAsync(roleName);

                var roleClaims = await _roleManager.GetClaimsAsync(role);

                var toBeRemovedClaims = roleClaims
                    .Where(c => !claims.Contains(c.Value));

                foreach (var claim in toBeRemovedClaims)
                {
                    await _roleManager.RemoveClaimAsync(role, claim);
                }

                var toBeAddedClaims = claims
                    .Where(c => !roleClaims.Any(rc => rc.Value == c));

                foreach (var claim in toBeAddedClaims)
                {
                    await _roleManager.AddClaimAsync(role, new Claim("Permission", claim));
                }

                return true;
            }

            return false;
        }
    }
}
