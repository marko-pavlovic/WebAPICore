using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICore.UIModels
{   
    public class EditMarkModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
