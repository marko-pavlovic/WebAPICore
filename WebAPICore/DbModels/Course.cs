using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebAPICore.DbModels
{
    public partial class Course
    {
        public Course()
        {
            Mark = new HashSet<Mark>();
            ProfessorCourse = new HashSet<ProfessorCourse>();
            StudentCourse = new HashSet<StudentCourse>();
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("subjectid")]
        public int? SubjectId { get; set; }
        [JsonPropertyName("professorid")]
        public int? ProfessorId { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
        public virtual ICollection<ProfessorCourse> ProfessorCourse { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
