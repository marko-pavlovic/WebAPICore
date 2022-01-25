using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Course
    {
        public Course()
        {
            Mark = new HashSet<Mark>();
            ProfessorCourse = new HashSet<ProfessorCourse>();
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? ProfessorId { get; set; }
        public int? Year { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
        public virtual ICollection<ProfessorCourse> ProfessorCourse { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
