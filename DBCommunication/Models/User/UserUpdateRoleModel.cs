using System.ComponentModel.DataAnnotations;

namespace DBCommunication.Models.User
{
    public class UserUpdateRoleModel
    {
        [Required(ErrorMessage = "Role Required")]
        public string Role { get; set; }
    }
}
