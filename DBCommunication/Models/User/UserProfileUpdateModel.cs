using System.ComponentModel.DataAnnotations;
using DBCommunication.ValidationAttributes;

namespace DBCommunication.Models.User
{
    public class UserProfileUpdateModel
    {
        [UserNameValidation]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [SignUpRoleValidation]
        public string Role { get; set; }
    }
}
