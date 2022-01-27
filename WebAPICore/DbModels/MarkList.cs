using System;
using System.Collections.Generic;

namespace WebAPICore.Models
{
    public partial class MarkList
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string MarkId { get; set; }
    }
}
