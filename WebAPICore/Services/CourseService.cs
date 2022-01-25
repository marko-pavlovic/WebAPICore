using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Services
{
    public class CourseService:ICourseService
    {
        APICoreDBContext _dbContext;
        public CourseService(APICoreDBContext db)
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

        public Course DeleteCourse(int id)
        {
            var course = _dbContext.Course.FirstOrDefault(x => x.Id == id);
            _dbContext.Entry(course).State = EntityState.Deleted;
            _dbContext.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetCourse()
        {
            var course = _dbContext.Course.ToList();
            return course;
        }

        public Course GetCourseById(int id)
        {
            var course = _dbContext.Course.FirstOrDefault(x => x.Id == id);
            return course;
        }

        public Course UpdateCourse(Course course)
        {
            _dbContext.Entry(course).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return course;
        }
    }
}
