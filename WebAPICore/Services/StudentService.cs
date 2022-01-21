using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class StudentService :IStudentService
    {
        APICoreDBContext dbContext;
        public StudentService(APICoreDBContext _db)
        {
            dbContext = _db;
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

        public Student DeleteStudent(int id)
        {
            var student = dbContext.Student.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(student).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return student;
        }

        public IEnumerable<Student> GetStudent()
        {
            var student = dbContext.Student.ToList();
            return student;
        }

        public Student GetStudentById(int id)
        {
            var student = dbContext.Student.FirstOrDefault(x => x.Id == id);
            return student;
        }

        public Student UpdateStudent(Student student)
        {
            dbContext.Entry(student).State = EntityState.Modified;
            dbContext.SaveChanges();
            return student;
        }
    }
}
