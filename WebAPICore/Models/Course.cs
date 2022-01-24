using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Course
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? ProfessorId { get; set; }
        public int? Year { get; set; }

        public List<int> students; //id studenata koji slusaju kurs
        public KeyValuePair<int, List<Mark>> marks; //kljuc=Id studenta value=lista ocena tog studenta
    }
}
