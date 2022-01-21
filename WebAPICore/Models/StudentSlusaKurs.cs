using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class StudentSlusaKurs
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? KursId { get; set; }
    }
}
