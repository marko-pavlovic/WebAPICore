using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Mark
    {
        public int Id { get; set; }
        public int? Mark1 { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? Date { get; set; }
        public string Comment { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
