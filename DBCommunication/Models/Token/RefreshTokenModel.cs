using System.ComponentModel.DataAnnotations;
using DBCommunication.ValidationAttributes;

namespace DBCommunication.Models.Token
{
    public class RefreshTokenModel
    {
        [UserNameValidation]
        [Required(ErrorMessage = "UserName Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "AccessToken Required")]
        public string AccessToken { get; set; }
        [Required(ErrorMessage = "RefreshTokenClientSide Required")]
        public string RefreshTokenClientSide { get; set; }
    }
}
