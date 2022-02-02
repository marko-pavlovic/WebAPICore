using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPICore.Mappers;
using WebAPICore.Models.User;
using WebAPICore.Permisions;
using WebAPICore.Services;

namespace WebAPICore.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(
            UserService userService,
            ILogger<UserController> logger)
        {
            _userService = userService;
        }

        [Authorize(ApiClaims.USERS)]

        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel userCreate)
        {
            
            var userCreateDto = UserMapper
                .UserCreateModelToUserCreateDto(userCreate);

            var result = await _userService
                .CreateAsync(userCreateDto);

            return Ok(result);
            
        }

        [Authorize(ApiClaims.USERS)]
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUser(string userName)
        {
            var result = await _userService.GetAsync(userName);

            return Ok(result);
        }

        [Authorize(ApiClaims.ACCOUNT)]
        [HttpGet("me")]
        public async Task<IActionResult> GetUser()
        {
            var result = await _userService.GetAsync(User.Identity.Name);

            return Ok(result);
        }

        [Authorize(ApiClaims.USERS)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAsync();

            return Ok(result);
        }

        //get org / get sel

        [Authorize(ApiClaims.USERS)]
        [HttpPatch("{userName}/update-role")]
        public async Task<IActionResult> UpdateUserRole(
            string userName, 
            [FromBody]UserUpdateRoleModel userUpdateRole)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService
                    .UpdateUserRoleAsync(userName, userUpdateRole.Role);

                return Ok(result);
            }

            return BadRequest(
                ModelState.Values.Where(m => m.Errors.Count > 0)
                    .SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage));
        }

        [Authorize(ApiClaims.USERS)]
        [HttpPut("{userName}")]
        public async Task<IActionResult> Update(
            string userName, 
            [FromBody] UserUpdateModel userUpdate)
        {
            if (ModelState.IsValid)
            {
                var userUpdateDto = UserMapper
                    .UserUpdateModelToUserUpdateDto(userUpdate);

                var result = await _userService
                    .UpdateAsync(userName, userUpdateDto);

                return Ok(result);
            }

            return BadRequest(
                ModelState.Values.Where(m => m.Errors.Count > 0)
                    .SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage));
        }

        [Authorize(ApiClaims.ACCOUNT)]
        [HttpPut("me")] 
        public async Task<IActionResult> Update(
            [FromBody] UserProfileUpdateModel userProfileUpdate)
        {
            
            var userProfileUpdateDto = UserMapper
                .UserProfileUpdateModelToUserProfileUpdateDto(userProfileUpdate);

            var result = await _userService
                .UpdateProfileAsync(User.Identity.Name, userProfileUpdateDto);  // base controller user name

            return Ok(result);
            
        }

        [Authorize(ApiClaims.ACCOUNT)]
        [HttpPut("me/password")]
        public async Task<IActionResult> UpdatePassword(
            [FromBody] UserUpdatePasswordModel userUpdatePassword)
        {
            
            var userUpdatePasswordDto = UserMapper
                .UserUpdatePasswordModelToUserUpdatePasswordDto(userUpdatePassword);

            var result = await _userService
                .UpdatePasswordAsync(User.Identity.Name, userUpdatePasswordDto);

            return Ok(result);
        }

        [Authorize(ApiClaims.USERS)]
        [HttpPut("enable")]
        public async Task<IActionResult> EnableUser(
            [FromQuery] UserEnableModel userEnable)
        {
            
            var result = await _userService
                .EnableUserdAsync(userEnable.UserName);

            return Ok(result);
            
        }

        [Authorize(ApiClaims.USERS)]
        [HttpDelete("{userName}")]
        public async Task<IActionResult> Delete(string userName)
        {
            var result = await _userService
                .DeleteAsync(userName);

            return Ok(result);
        }

        [Authorize(ApiClaims.ACCOUNT)]
        [HttpDelete("me")]
        public async Task<IActionResult> Delete()
        {
            var result = await _userService
                .DeleteAsync(User.Identity.Name);

            return Ok(result);
        }
    }
}