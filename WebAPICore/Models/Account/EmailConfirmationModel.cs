using System.ComponentModel.DataAnnotations;

namespace WebAPICore.Models.Account
{
    public class EmailConfirmationModel
    {
        [Required(ErrorMessage = "Token Required")]
        public string Token { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
    }
}
