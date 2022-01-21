using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class ProfesorPredajeKurs
    {
        public int Id { get; set; }
        public int? ProfesorId { get; set; }
        public int? KursId { get; set; }
    }
}
