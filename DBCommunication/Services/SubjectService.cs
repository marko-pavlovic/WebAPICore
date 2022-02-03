using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBCommunication.DbModels;

namespace DBCommunication.Services
{
    public class SubjectService
    {
        APICoreDBContext _dbContext;
        public SubjectService(APICoreDBContext db)
        {
            _dbContext = db;
        }

        public Subject AddSubject(Subject subject)
        {
            if (subject != null)
            {
                _dbContext.Subject.Add(subject);
                _dbContext.SaveChanges();
                return subject;
            }
            return null;
        }

        public Subject DeleteSubject(int id)
        {
            var subject = _dbContext.Subject.FirstOrDefault(x => x.Id == id);
            _dbContext.Entry(subject).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return subject;
        }

        public IEnumerable<Subject> GetSubject()
        {
            var subject = _dbContext.Subject.ToList();
            return subject;
        }

        public Subject GetSubjectById(int id)
        {
            var subject = _dbContext.Subject.FirstOrDefault(x => x.Id == id);
            return subject;
        }

        public Subject UpdateSubject(Subject subject)
        {
            _dbContext.Entry(subject).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return subject;
        }

    }
}
