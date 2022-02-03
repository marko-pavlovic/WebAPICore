using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBCommunication.DbModels
{
    public partial class Student
    {
        public Student()
        {
            Mark = new HashSet<Mark>();
            StudentCourse = new HashSet<StudentCourse>();
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
        [JsonPropertyName("year")]
        public int? Year { get; set; }
        [JsonPropertyName("averagerating")]
        public decimal? AverageRating { get; set; }
        [JsonPropertyName("pin")]
        public string Pin { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("userid")]
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Mark> Mark { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
