using System;
using System.Collections.Generic;

namespace WebAPICore.DbModels
{
    public partial class ProfessorCourse
    {
        public int Id { get; set; }
        public int? ProfessorId { get; set; }
        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Professor Professor { get; set; }
    }
}
