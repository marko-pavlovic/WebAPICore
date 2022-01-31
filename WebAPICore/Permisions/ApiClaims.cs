using System.Collections.Generic;

namespace WebAPICore.Permisions
{
    public class ApiClaims
    {
        public static List<string> All = new List<string>
        {
            ACCOUNT, ROLES, USERS, STUDENT, PROFESSOR, ADMINISTRERING
        };

        public const string ACCOUNT = "account";

        public const string ROLES = "roles";

        public const string USERS = "users";

        public const string STUDENT = "student";

        public const string PROFESSOR = "professor";

        public const string ADMINISTRERING = "administering";

        
    }
}
