using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class PredmetService : IPredmetService
    {
        APICoreDBContext dbContext;
        public PredmetService(APICoreDBContext _db)
        {
            dbContext = _db;
        }

        public Predmet AddPredmet(Predmet predmet)
        {
            if (predmet != null)
            {
                dbContext.Predmet.Add(predmet);
                dbContext.SaveChanges();
                return predmet;
            }
            return null;
        }

        public Predmet DeletePredmet(int id)
        {
            var predmet = dbContext.Predmet.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(predmet).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return predmet;
        }

        public IEnumerable<Predmet> GetPredmet()
        {
            var predmet = dbContext.Predmet.ToList();
            return predmet;
        }

        public Predmet GetPredmetById(int id)
        {
            var predmet = dbContext.Predmet.FirstOrDefault(x => x.Id == id);
            return predmet;
        }

        public Predmet UpdatePredmet(Predmet predmet)
        {
            dbContext.Entry(predmet).State = EntityState.Modified;
            dbContext.SaveChanges();
            return predmet;
        }

    }
}
