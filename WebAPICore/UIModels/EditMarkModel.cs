using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPICore.UIModels
{   
    public class EditMarkModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("studentid")]
        public int StudentId { get; set; }
        [JsonPropertyName("courseid")]
        public int CourseId { get; set; }
        [JsonPropertyName("mark")]
        public int Mark { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}
