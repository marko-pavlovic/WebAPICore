using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICore.Models
{
    public class Profesor
    {
        public string ime;
        public string prezime;
        public List<Predmet> predmeti;
        public List<Kurs> Kursevi;
    }
}
