using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class KursService:IKursService
    {
        APICoreDBContext dbContext;
        public KursService(APICoreDBContext _db)
        {
            dbContext = _db;
        }

        public Kurs AddKurs(Kurs kurs)
        {
            if (kurs != null)
            {
                dbContext.Kurs.Add(kurs);
                dbContext.SaveChanges();
                return kurs;
            }
            return null;
        }

        public Kurs DeleteKurs(int id)
        {
            var kurs = dbContext.Kurs.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(kurs).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return kurs;
        }

        public IEnumerable<Kurs> GetKurs()
        {
            var kurs = dbContext.Kurs.ToList();
            return kurs;
        }

        public Kurs GetKursById(int id)
        {
            var kurs = dbContext.Kurs.FirstOrDefault(x => x.Id == id);
            return kurs;
        }

        public Kurs UpdateKurs(Kurs kurs)
        {
            dbContext.Entry(kurs).State = EntityState.Modified;
            dbContext.SaveChanges();
            return kurs;
        }
    }
}
