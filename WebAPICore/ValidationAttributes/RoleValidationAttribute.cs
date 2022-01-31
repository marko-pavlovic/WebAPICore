using System.ComponentModel.DataAnnotations;
using WebAPICore.Permisions;

namespace WebAPICore.ValidationAttributes
{
    public class SignUpRoleValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessage = "Role can't be NULL";
                return false;
            }

            var valueString = value.ToString();

            if (!ApiRoles.UserSignUpRoles.Contains(valueString))
            {
                ErrorMessage = "Role must from provided set of roles";
                return false;
            }

            return true;
        }
    }
}
