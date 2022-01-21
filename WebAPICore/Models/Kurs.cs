using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICore.Models
{
    public class Kurs
    {
        public int Id { get; set; }
        public int IdPredmeta { get; set; }
        
        public int IdProfesora { get; set; }
        public int godina { get; set; }

        public List<int> studenti; //id studenata koji slusaju kurs
        public KeyValuePair<int, List<Ocena>> ocene; //kljuc=Id studenta value=lista ocena tog studenta
    }
}
