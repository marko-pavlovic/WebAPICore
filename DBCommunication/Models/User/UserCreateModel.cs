using System.ComponentModel.DataAnnotations;
using DBCommunication.ValidationAttributes;

namespace DBCommunication.Models.User
{
    public class UserCreateModel
    {
        [UserNameValidation]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [PasswordValidation]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Role Required")]
        public string Role { get; set; }
    }
}
