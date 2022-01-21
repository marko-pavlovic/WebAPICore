using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IPredmetService
    {
        IEnumerable<Predmet> GetPredmet();
        Predmet GetPredmetById(int id);
        Predmet AddPredmet(Predmet predmet);
        Predmet UpdatePredmet(Predmet predmet);
        Predmet DeletePredmet(int id);

    }
}
