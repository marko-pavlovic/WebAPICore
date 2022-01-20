using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICore.Models
{
    public class Kurs
    {
        public string Naziv;
        public Predmet predmet;
        public int godina;
        public Profesor profesor;
    }
}
