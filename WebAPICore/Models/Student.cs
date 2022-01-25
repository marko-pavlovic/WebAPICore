using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Student
    {
        public Student()
        {
            Mark = new HashSet<Mark>();
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Year { get; set; }
        public decimal? AverageRating { get; set; }
        public string Pin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Mark> Mark { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
