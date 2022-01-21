using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPICore.Services
{
    public class AdminService : IAdminService
    {
        APICoreDBContext dbContext;
        public AdminService(APICoreDBContext _db)
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

        public Student AddStudent(Student student)
        {
            if (student != null)
            {
                dbContext.Student.Add(student);
                dbContext.SaveChanges();
                return student;
            }
            return null;
        }

        public IEnumerable<Kurs> GetKurs()
        {
            var kurs = dbContext.Kurs.ToList();
            return kurs;
        }

        public IEnumerable<Student> GetStudent()
        {
            var student = dbContext.Student.ToList();
            return student;
        }
    }
}
