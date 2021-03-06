using System.Collections.Generic;

namespace DBCommunication.Dtos.Role
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Claims { get; set; }
    }
}
