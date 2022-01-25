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
        APICoreDBContext _dbContext;
        public AdminService(APICoreDBContext db)
        {
            _dbContext = db;
        }
        public Course AddCourse(Course course)
        {
            if (course != null)
            {
                _dbContext.Course.Add(course);
                _dbContext.SaveChanges();
                return course;
            }
            return null;
        }

        public Student AddStudent(Student student)
        {
            if (student != null)
            {
                _dbContext.Student.Add(student);
                _dbContext.SaveChanges();
                return student;
            }
            return null;
        }

        public IEnumerable<Course> GetCourse()
        {
            var course = _dbContext.Course.ToList();
            return course;
        }

        public IEnumerable<Student> GetStudent()
        {
            var student = _dbContext.Student.ToList();
            return student;
        }

        public bool DeleteStudent(Student student)
        {
            _dbContext.Remove(student);
            _dbContext.SaveChanges();

            return true;
        }

        public bool UpdateStudent(Student student)
        {
            _dbContext.Update(student);
            _dbContext.SaveChanges();

            return true;
        }

        public bool EnrollStudent(Student student, Course course)
        {
            throw new NotImplementedException();
        }

        public bool UnEnrollStudent(Student student, Course course)
        {
            throw new NotImplementedException();
        }
    }
}
