
using System.ComponentModel.DataAnnotations;

namespace WebAPICore.ValidationAttributes
{
    public class UserNameValidationAttribute : ValidationAttribute
    {
        private const string VALID_CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessage = "UserName can't be NULL";
                return false;
            }

            var valueString = value.ToString();

            for (var i = 0; i < valueString.Length; i++)
            {
                if (!VALID_CHARACTERS.Contains(valueString[i]))
                {
                    ErrorMessage = "UserName can't contain invalid characters";
                    return false;
                }
            }

            return true;
        }
    }
}
