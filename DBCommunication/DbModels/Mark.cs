using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DBCommunication.DbModels
{
    public partial class Mark
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("mark1")]
        public int? Mark1 { get; set; }
        [JsonPropertyName("studentid")]
        public int? StudentId { get; set; }
        [JsonPropertyName("courseid")]
        public int? CourseId { get; set; }
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }
        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
