using System.ComponentModel.DataAnnotations;


namespace DBCommunication.ValidationAttributes
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        private const string NON_ALPHANUMERIC = "!@#$%^&*-+=_/";
        private const int MINIMUM_PASSWORD_LENGTH = 6;

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                ErrorMessage = "Password can't be NULL";
                return false;
            }

            var valueString = value.ToString();

            //min length
            if (valueString.Length < MINIMUM_PASSWORD_LENGTH)
            {
                ErrorMessage = "Minimum password length is " + MINIMUM_PASSWORD_LENGTH;
                return false;
            }

            var containsUpperCase = false;
            var containsLowerCase = false;
            var containsDigit = false;
            var containsNonAlphanumeric = false;

            for (var i = 0; i < valueString.Length; i++)
            {
                if (valueString[i] >= '0' && valueString[i] <= '9')
                    containsDigit = true;
                else if (valueString[i] >= 'a' && valueString[i] <= 'z')
                    containsLowerCase = true;
                else if (valueString[i] >= 'A' && valueString[i] <= 'Z')
                    containsUpperCase = true;
                else if (NON_ALPHANUMERIC.Contains(valueString[i]))
                    containsNonAlphanumeric = true;
            }

            ErrorMessage = "";

            if (!containsUpperCase)
            {
                ErrorMessage = "Password must contain upper case";
            }
            if (!containsLowerCase)
            {
                ErrorMessage = ErrorMessage.Equals("") ? ErrorMessage = "Password must contain lower case"
                    : ErrorMessage = ErrorMessage + ", Password must contain upper case";
            }
            if (!containsDigit)
            {
                ErrorMessage = ErrorMessage.Equals("") ? ErrorMessage = "Password must contain digit"
                    : ErrorMessage = ErrorMessage + ", Password must contain digit";
            }
            if (!containsNonAlphanumeric)
            {
                ErrorMessage = ErrorMessage.Equals("") ? ErrorMessage = "Password must contain special symbol"
                    : ErrorMessage = ErrorMessage + ", Password must contain sppecial symbol";
            }

            return (containsUpperCase && containsLowerCase && containsDigit && containsNonAlphanumeric);
        }
    }

}
