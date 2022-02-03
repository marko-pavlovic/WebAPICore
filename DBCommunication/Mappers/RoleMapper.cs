using DBCommunication.Models.Role;
using DBCommunication.Dtos.Role;

namespace DBCommunication.Mappers
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
