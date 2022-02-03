using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBCommunication.DbModels
{
    public partial class Professor
    {
        public Professor()
        {
            ProfessorCourse = new HashSet<ProfessorCourse>();
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
        [JsonPropertyName("userid")]
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<ProfessorCourse> ProfessorCourse { get; set; }
    }
}
