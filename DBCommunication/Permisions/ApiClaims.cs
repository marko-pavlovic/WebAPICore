using System.Collections.Generic;

namespace DBCommunication.Permisions
{
    public class ApiClaims
    {
        public static List<string> All = new List<string>
        {
            ACCOUNT, ROLES, USERS, STUDENT, PROFESSOR, ADMIN
        };

        public const string ACCOUNT = "account";

        public const string ROLES = "roles";

        public const string USERS = "users";

        public const string STUDENT = "student";

        public const string PROFESSOR = "professor";

        public const string ADMIN = "admin";

        
    }
}
