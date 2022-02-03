using System.Collections.Generic;

namespace DBCommunication.Permisions
{
    public class ApiRoles
    {
        public static List<string> UserSignUpRoles = new List<string> { ADMIN, PROFESSOR, STUDENT };

        public static Dictionary<string, List<string>> RolesWithClaims = new Dictionary<string, List<string>>
        {
            { 
                STUDENT, 
                new List<string>
                {
                    ApiClaims.ACCOUNT,
                    ApiClaims.STUDENT
                }},
            {
                PROFESSOR,
                new List<string>
                {
                    ApiClaims.ACCOUNT,
                    ApiClaims.PROFESSOR,
                }
            },
            { 
                ADMIN,
                new List<string>
                {
                    ApiClaims.ACCOUNT, 
                    ApiClaims.USERS, 
                    ApiClaims.ROLES,
                    ApiClaims.ADMIN
                }
            }
        };

        //reseller
        public const string STUDENT = "Student";

        //organizer
        public const string PROFESSOR = "Professor";

        //admin
        public const string ADMIN = "Admin";
    }
}
