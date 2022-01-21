using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Ocena
    {
        public int Id { get; set; }
        public int? Ocena1 { get; set; }
        public int? StudentId { get; set; }
        public int? KursId { get; set; }
        public DateTime? Datum { get; set; }
        public string Komentar { get; set; }
    }
}
