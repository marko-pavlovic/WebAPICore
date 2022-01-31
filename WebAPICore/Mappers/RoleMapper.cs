using WebAPICore.Models.Role;
using WebAPICore.Dtos.Role;

namespace WebAPICore.Mappers
{
    public static class RoleMapper
    {
        public static RoleCreateDto RoleCreateModelToRoleCreateDto(RoleCreateModel roleCreate)
        {
            var result = new RoleCreateDto
            {
                Name = roleCreate.Name,
                Claims = roleCreate.Claims
            };

            return result;
        }
    }
}
