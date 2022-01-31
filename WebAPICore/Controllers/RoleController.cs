using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPICore.Controllers;
using WebAPICore.Dtos.Role;
using WebAPICore.Mappers;
using WebAPICore.Models.Role;
using WebAPICore.Permisions;
using WebAPICore.Services;

namespace WebAPICore.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public readonly RoleService _roleService;

        public RoleController(
            RoleService roleService,
            ILogger<RoleController> logger)
        {
            _roleService = roleService;
        }

        [Authorize(ApiClaims.ROLES)]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        public async Task<IActionResult> Create([FromBody]RoleCreateModel roleCreate)
        {
                var roleCreateDto = RoleMapper
                    .RoleCreateModelToRoleCreateDto(roleCreate);

                var result = await _roleService
                    .CreateAsync(roleCreateDto);

                return Ok(result);
        }

        [Authorize(ApiClaims.ROLES)]
        [HttpGet("{roleName}")]
        public async Task<IActionResult> Get(string roleName)
        {
            var result = await _roleService.GetAsync(roleName);

            return Ok(result);
        }

        [Authorize(ApiClaims.ROLES)]
        [HttpGet("claims")]
        public IActionResult GetClaims()
        {
            return Ok(ApiClaims.All);
        }

        [Authorize(ApiClaims.ROLES)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _roleService.GetAsync();

            return Ok(result);
        }

        [Authorize(ApiClaims.ROLES)]
        [HttpPut("{roleName}")]
        public async Task<IActionResult> Update(
            string roleName,
            [FromBody] RoleUpdateModel roleUpdate)
        {
            
            var result = await _roleService
                .UpdateAsync(roleName, roleUpdate.Claims);

            return Ok(result);

        }

        [Authorize(ApiClaims.ROLES)]
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> Delete(string roleName)
        {
            var result = await _roleService
                .DeleteAsync(roleName);

            return Ok(result);
        }
    }
}