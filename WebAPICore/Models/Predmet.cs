using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class Predmet
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int? Godina { get; set; }
        public string Tip { get; set; }
    }
}
