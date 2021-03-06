using System.ComponentModel.DataAnnotations;
using DBCommunication.ValidationAttributes;

namespace DBCommunication.Models.Account
{
    public class SignUpUserModel
    {
        [UserNameValidation]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [PasswordValidation]
        [Required(ErrorMessage = "UserName Required")]
        public string Password { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "UserName Required")]
        public string Email { get; set; }
        [SignUpRoleValidation]
        [Required(ErrorMessage = "UserName Required")]
        public string Role { get; set; }
    }
}
