using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Threading.Tasks;
using WebAPICore.Controllers;
using WebAPICore.Mappers;
using WebAPICore.Models.Account;
using WebAPICore.Permisions;
using WebAPICore.Services;

namespace WebAPICore.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController :ControllerBase
    {
        public readonly AccountService _accountService;
        public readonly UserService _userService;

        public AccountController(
            AccountService accountService,
            UserService userService,
            ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("sign-up")]
        public async Task<bool> SignUp([FromBody] SignUpUserModel signUpUser)
        {
            var userCreate = UserMapper
                .SignUpUserModelToUserCreateDto(signUpUser);

            var result = await _userService
                .CreateAsync(userCreate);

            return result;
        }

        [AllowAnonymous]
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody]SignInModel signInModel)
        {
            var result = await _accountService
                .SignInAsync(signInModel.UserName,
                                signInModel.Password);

            return Ok(result);
            
        }

        [Authorize(ApiClaims.ACCOUNT)]
        [HttpPost("sign-out")]
        public async Task<IActionResult> SignOut([FromBody] SignOutModel signOutModel)
        {
            var result = await _accountService.SignOutAsync(
                signOutModel.RefreshToken,
                User.Identity.Name);  // kako da vratim username ako nemam base controller

            return Ok(result);
        }

        //[AllowAnonymous]
        //[HttpGet("confirm-email")]
        //public async Task<IActionResult> ConfirmEmail(
        //    [FromQuery] EmailConfirmationModel emailConfirmationModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _accountService.ConfirmEmailAsync(
        //            emailConfirmationModel.Token,
        //            emailConfirmationModel.Email);

        //        return Ok(result);
        //    }

        //    return BadRequest(
        //        ModelState.Values.Where(m => m.Errors.Count > 0)
        //            .SelectMany(m => m.Errors)
        //            .Select(e => e.ErrorMessage));
        //}

        //[AllowAnonymous]
        //[HttpPost("send-restart-password")]
        //public async Task<IActionResult> SendRestartPassword(
        //    [FromBody] SendPasswordRestartModel sendPasswordRestart)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _accountService.SendRestartPasswordAsync(
        //            Url, 
        //            sendPasswordRestart.UserName);

        //        return Ok(result);
        //    }

        //    return BadRequest(
        //        ModelState.Select(key => key.Value.Errors)
        //            .Where(y => y.Count > 0)
        //            .ToList());
        //}

        //[AllowAnonymous]
        //[HttpGet("restart-password")]
        //public async Task<IActionResult> RestartPassword(
        //    [FromQuery] PasswordRestartModel passwordRestartModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _accountService.RestartPasswordAsync(
        //            passwordRestartModel.UserName,
        //            passwordRestartModel.Password,
        //            passwordRestartModel.Token);

        //        return Ok(result);
        //    }

        //    return BadRequest(
        //        ModelState.Values.Where(m => m.Errors.Count > 0)
        //            .SelectMany(m => m.Errors)
        //            .Select(e => e.ErrorMessage));
        //}

        [AllowAnonymous]
        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            return Ok(ApiRoles.UserSignUpRoles);
        }
    }
}