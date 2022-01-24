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
        public Course AddCourse(Course course)
        {
            if (course != null)
            {
                dbContext.Course.Add(course);
                dbContext.SaveChanges();
                return course;
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

        public IEnumerable<Course> GetCourse()
        {
            var course = dbContext.Course.ToList();
            return course;
        }

        public IEnumerable<Student> GetStudent()
        {
            var student = dbContext.Student.ToList();
            return student;
        }
    }
}
