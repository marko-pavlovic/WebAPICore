using System.ComponentModel.DataAnnotations;
using DBCommunication.ValidationAttributes;

namespace DBCommunication.Models.User
{
    public class UserEnableModel
    {
        [UserNameValidation]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
    }
}
