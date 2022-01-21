using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class ListaOcena
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string IdOcena { get; set; }
    }
}
