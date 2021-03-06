using System.ComponentModel.DataAnnotations;

namespace DBCommunication.Models.Account
{
    public class SignOutModel
    {
        [MinLength(32)]
        [MaxLength(40)]
        [Required(ErrorMessage = "RefreshToken Required")]
        public string RefreshToken { get; set; }
    }
}
