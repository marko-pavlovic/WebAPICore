using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class ProfessorService: IProfessorService
    {
        APICoreDBContext dbContext;
        public ProfessorService(APICoreDBContext _db)
        {
            dbContext = _db;
        }

        public Professor AddProfessor(Professor professor)
        {
            if (professor != null)
            {
                dbContext.Professor.Add(professor);
                dbContext.SaveChanges();
                return professor;
            }
            return null;
        }

        public Professor DeleteProfessor(int id)
        {
            var professor = dbContext.Professor.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(professor).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return professor;
        }

        public IEnumerable<Professor> GetProfessor()
        {
            var professor = dbContext.Professor.ToList();
            return professor;
        }

        public Professor GetProfessorById(int id)
        {
            var professor = dbContext.Professor.FirstOrDefault(x => x.Id == id);
            return professor;
        }

        public Professor UpdateProfessor(Professor professor)
        {
            dbContext.Entry(professor).State = EntityState.Modified;
            dbContext.SaveChanges();
            return professor;
        }
    }
}
