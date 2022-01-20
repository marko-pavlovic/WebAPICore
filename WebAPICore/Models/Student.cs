using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICore.Models
{
    public class Student
    {
        public int Id;
        public string Ime;
        public string Prezime;
        public int godina;
        public decimal prosecnaOcena;
        public List<Kurs> kursevi;
    }
}
