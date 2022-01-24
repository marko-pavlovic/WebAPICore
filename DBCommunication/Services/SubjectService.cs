using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class SubjectService : ISubjectService
    {
        APICoreDBContext dbContext;
        public SubjectService(APICoreDBContext _db)
        {
            dbContext = _db;
        }

        public Subject AddSubject(Subject subject)
        {
            if (subject != null)
            {
                dbContext.Subject.Add(subject);
                dbContext.SaveChanges();
                return subject;
            }
            return null;
        }

        public Subject DeleteSubject(int id)
        {
            var subject = dbContext.Subject.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(subject).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return subject;
        }

        public IEnumerable<Subject> GetSubject()
        {
            var subject = dbContext.Subject.ToList();
            return subject;
        }

        public Subject GetSubjectById(int id)
        {
            var subject = dbContext.Subject.FirstOrDefault(x => x.Id == id);
            return subject;
        }

        public Subject UpdateSubject(Subject subject)
        {
            dbContext.Entry(subject).State = EntityState.Modified;
            dbContext.SaveChanges();
            return subject;
        }

    }
}
