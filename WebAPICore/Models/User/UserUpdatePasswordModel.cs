using System.ComponentModel.DataAnnotations;
using WebAPICore.ValidationAttributes;

namespace WebAPICore.Models.User
{
    public class UserUpdatePasswordModel
    {
        [PasswordValidation]
        [Required(ErrorMessage = "CurrentPassword Required")]
        public string CurrentPassword { get; set; }
        [PasswordValidation]
        [Required(ErrorMessage = "NewPassword Required")]
        public string NewPassword { get; set; }
    }
}
