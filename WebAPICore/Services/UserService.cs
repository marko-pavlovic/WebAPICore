using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Dtos.User;
using WebAPICore.Identity;
using WebAPICore.Mappers;
using Utilities.Exceptions;
using Utilities.SimpleObjects;

namespace WebAPICore.Services
{
    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private async Task<ApplicationUser> GetAppUserAsync(string userName)
        {
            var appUser = await _userManager.FindByNameAsync(userName);

            if (appUser == null)
                throw new NotFoundException("User", userName);

            return appUser;
        }

        private async Task<IdentityRole> GetRoleAsync(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);

            if (role == null)
                throw new NotFoundException("Role", name);

            return role;
        }


        public async Task<List<IdAndName>> GetForRoleAsync(string roleName)
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);

            if (usersInRole == null)
                throw new NotFoundException("User", roleName);

            var result = usersInRole
                .Select(u => new IdAndName(u.Id, u.UserName))
                .ToList();

            return result;
        }


        public async Task<UserDto> GetAsync(string userName)
        {
            var appUser = await GetAppUserAsync(userName);

            var roles = await _userManager.GetRolesAsync(appUser);

            var result = UserMapper.ApplicationUserToUserDto
                (appUser,
                roles.FirstOrDefault());

                return result;
        }
        
        public async Task<List<IdAndName>> GetAsync()
        {
            var result = await _userManager.Users
                .Select(u => new IdAndName(u.Id, u.UserName))
                .ToListAsync();

            return result;
        }

        public async Task<bool> CreateAsync(UserCreateDto userCreate)
        {
            var role = await GetRoleAsync(userCreate.Role);

            var appUser = UserMapper.UserCreateDtoToApplicationUser(userCreate);

            var identityResult = await _userManager
                .CreateAsync(appUser, userCreate.Password);

            return true;
            
        }

        public async Task<bool> UpdateUserRoleAsync(string userName, string role)
        {
            var appUser = await GetAppUserAsync(userName);

            var currentRole = (await _userManager.GetRolesAsync(appUser))
                .FirstOrDefault();

            if (currentRole != role)
            {
                var addUserToRole = await _userManager
                    .AddToRoleAsync(appUser, role);

                if (addUserToRole.Succeeded)
                {
                    var removeUserRole = await _userManager
                        .RemoveFromRoleAsync(appUser, currentRole);

                    if (removeUserRole.Succeeded)
                        return true;
                    else
                        throw new InternalServerErrorException(
                            /*nameof(AspNetUsers) + */" with UserName: " + userName + " Remove from Role Failed");
                }
                else
                    throw new InternalServerErrorException(nameof(UpdateUserRoleAsync) + " Failed");
            }
            else
                return true;
        }

        public async Task<bool> UpdateProfileAsync(string userName, UserProfileUpdateDto userProfileUpdate)
        {
            var appUser = await GetAppUserAsync(userName);

            UserMapper.UserProfileUpdateDtoToApplicationUser(userProfileUpdate, appUser);

            var identityResult = await _userManager.UpdateAsync(appUser);

            if (identityResult.Succeeded)
                return true;
            else
                throw new InternalServerErrorException(
                    nameof(ApplicationUser) + " with UserName: " + userName + " Update Failed");
        }

        public async Task<bool> UpdatePasswordAsync(string userName, UserUpdatePasswordDto userUpdatePassword)
        {
            var appUser = await GetAppUserAsync(userName);

            //pasword change
            var currentPaswordHash = _userManager.PasswordHasher.HashPassword(appUser, userUpdatePassword.CurrentPassword);
            if (appUser.PasswordHash.Equals(currentPaswordHash))
            {
                var newPasswordHash = _userManager.PasswordHasher.HashPassword(appUser, userUpdatePassword.NewPassword);
                appUser.PasswordHash = newPasswordHash;

                var identityResult = await _userManager.UpdateAsync(appUser);
                if (identityResult.Succeeded)
                    return true;
            }

            throw new InternalServerErrorException(
                    nameof(ApplicationUser) + " with UserName: " + userName + " Update Failed");
        }

        public async Task<bool> EnableUserdAsync(string userName)
        {
            var appUser = await GetAppUserAsync(userName);

            var lockoutEnabled = await _userManager.IsLockedOutAsync(appUser);
            
            if (lockoutEnabled)
            {
                var result = await _userManager.SetLockoutEndDateAsync(appUser, DateTimeOffset.Now);

                return result.Succeeded;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(string userName, UserUpdateDto userUpdate)
        {
            var appUser = await GetAppUserAsync(userName);

            appUser.UserName = userUpdate.UserName;
            appUser.Email = userUpdate.Email;

            //pasword change
            var paswordHash = _userManager.PasswordHasher.HashPassword(appUser, userUpdate.Password);
            if (!appUser.PasswordHash.Equals(paswordHash))
            {
                appUser.PasswordHash = paswordHash;
            }

            var identityResult = await _userManager.UpdateAsync(appUser);

            if (identityResult.Succeeded)
                return true;
            else
                throw new InternalServerErrorException(
                    nameof(ApplicationUser) + " with UserName: " + userName + " Update Failed");
        }

        public async Task<bool> DeleteAsync(string userName)
        {
            var appUser = await GetAppUserAsync(userName);

            var identityResult = await _userManager.DeleteAsync(appUser);

            if (identityResult.Succeeded)
                return true;
            else
                throw new InternalServerErrorException(
                    "User with UserName: " + userName + " Delete Failed");
        }
    }
}