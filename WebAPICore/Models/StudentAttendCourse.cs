using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class StudentAttendCourse
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
    }
}
