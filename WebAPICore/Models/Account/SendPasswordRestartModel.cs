using System.ComponentModel.DataAnnotations;
using WebAPICore.ValidationAttributes;

namespace WebAPICore.Models.Account
{
    public class SendPasswordRestartModel
    {
        [UserNameValidation]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; } 
    }
}
