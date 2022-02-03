using System.ComponentModel.DataAnnotations;
using DBCommunication.ValidationAttributes;

namespace DBCommunication.Models.User
{
    public class UserUpdateModel
    {
        [UserNameValidation]
        public string UserName { get; set; }
        [PasswordValidation]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
