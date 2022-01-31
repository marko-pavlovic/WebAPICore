using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPICore.Models.Role
{
    public class RoleCreateModel
    {
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        public List<string> Claims { get; set; }
    }
}
