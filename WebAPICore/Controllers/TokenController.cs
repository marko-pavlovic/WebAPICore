using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DBCommunication.Models.Token;
using DBCommunication.Permisions;
using DBCommunication.Services;

namespace WebAPICore.Controllers
{
    [Route("api/tokens")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public readonly TokenService _tokenService;

        public TokenController(
            TokenService tokenService, 
            ILogger<TokenController> logger)
        {
            _tokenService = tokenService;
        }

        [Authorize(ApiClaims.ACCOUNT)]
        [HttpPost("refresh-token")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RefreshAccessToken([FromBody] RefreshTokenModel refreshToken)
        {
            
            var result = await _tokenService
                .RefreshAccessTokenAsync(
                    refreshToken.UserName,
                    refreshToken.AccessToken,
                    refreshToken.RefreshTokenClientSide);

            return Ok(result);
            
        }
    }
}