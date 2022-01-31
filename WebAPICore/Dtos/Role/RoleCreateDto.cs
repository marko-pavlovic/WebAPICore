using System.Collections.Generic;

namespace WebAPICore.Dtos.Role
{
    public class RoleCreateDto
    {
        public string Name { get; set; }
        public List<string> Claims { get; set; }
    }
}
