using System.ComponentModel.DataAnnotations;

namespace DBCommunication.Models.Account
{
    public class SignInModel
    {
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }
    }
}
