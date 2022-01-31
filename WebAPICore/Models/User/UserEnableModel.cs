using System.ComponentModel.DataAnnotations;
using WebAPICore.ValidationAttributes;

namespace WebAPICore.Models.User
{
    public class UserEnableModel
    {
        [UserNameValidation]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
    }
}
