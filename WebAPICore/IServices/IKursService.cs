using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IKursService
    {
        IEnumerable<Kurs> GetKurs();
        Kurs GetKursById(int id);
        Kurs AddKurs(Kurs kurs);
        Kurs UpdateKurs(Kurs kurs);
        Kurs DeleteKurs(int id);
    }
}
