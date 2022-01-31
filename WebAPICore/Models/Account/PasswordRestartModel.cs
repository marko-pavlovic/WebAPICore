using System.ComponentModel.DataAnnotations;
using WebAPICore.ValidationAttributes;

namespace WebAPICore.Models.Account
{
    public class PasswordRestartModel
    {
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [PasswordValidation]
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Token Required")]
        public string Token { get; set; }
    }
}
