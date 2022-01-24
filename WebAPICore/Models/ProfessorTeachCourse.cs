using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class ProfessorTeachCourse
    {
        public int Id { get; set; }
        public int? ProfessorId { get; set; }
        public int? CourseId { get; set; }
    }
}
