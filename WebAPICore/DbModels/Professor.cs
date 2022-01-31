using System;
using System.Collections.Generic;

namespace WebAPICore.DbModels
{
    public partial class Professor
    {
        public Professor()
        {
            ProfessorCourse = new HashSet<ProfessorCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<ProfessorCourse> ProfessorCourse { get; set; }
    }
}
