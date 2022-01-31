using System.ComponentModel.DataAnnotations;
using WebAPICore.ValidationAttributes;

namespace WebAPICore.Models.Token
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
