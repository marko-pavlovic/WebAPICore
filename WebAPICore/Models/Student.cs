using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? Godina { get; set; }
        public decimal? Prosek { get; set; }
        public string Jmbg { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
