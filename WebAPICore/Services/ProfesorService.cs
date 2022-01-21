using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class ProfesorService: IProfesorService
    {
        APICoreDBContext dbContext;
        public ProfesorService(APICoreDBContext _db)
        {
            dbContext = _db;
        }

        public Profesor AddProfesor(Profesor profesor)
        {
            if (profesor != null)
            {
                dbContext.Profesor.Add(profesor);
                dbContext.SaveChanges();
                return profesor;
            }
            return null;
        }

        public Profesor DeleteProfesor(int id)
        {
            var profesor = dbContext.Profesor.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(profesor).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return profesor;
        }

        public IEnumerable<Profesor> GetProfesor()
        {
            var profesor = dbContext.Profesor.ToList();
            return profesor;
        }

        public Profesor GetProfesorById(int id)
        {
            var profesor = dbContext.Profesor.FirstOrDefault(x => x.Id == id);
            return profesor;
        }

        public Profesor UpdateProfesor(Profesor profesor)
        {
            dbContext.Entry(profesor).State = EntityState.Modified;
            dbContext.SaveChanges();
            return profesor;
        }
    }
}
