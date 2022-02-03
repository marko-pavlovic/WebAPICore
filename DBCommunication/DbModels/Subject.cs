using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBCommunication.DbModels
{
    public partial class Subject
    {
        public Subject()
        {
            Course = new HashSet<Course>();
        }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("year")]
        public int? Year { get; set; }
        [JsonPropertyName("obligatory")]
        public bool? Obligatory { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
