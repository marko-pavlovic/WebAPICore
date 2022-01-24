using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Year { get; set; }
        public decimal? AverageRating { get; set; }
        public string Pin { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
