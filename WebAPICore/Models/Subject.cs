using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public bool? Obligatory { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
