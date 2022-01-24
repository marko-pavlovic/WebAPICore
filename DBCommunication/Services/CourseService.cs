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
        APICoreDBContext dbContext;
        public CourseService(APICoreDBContext _db)
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

        public Course DeleteCourse(int id)
        {
            var course = dbContext.Course.FirstOrDefault(x => x.Id == id);
            dbContext.Entry(course).State = EntityState.Deleted;
            dbContext.SaveChanges();
            return course;
        }

        public IEnumerable<Course> GetCourse()
        {
            var course = dbContext.Course.ToList();
            return course;
        }

        public Course GetCourseById(int id)
        {
            var course = dbContext.Course.FirstOrDefault(x => x.Id == id);
            return course;
        }

        public Course UpdateCourse(Course course)
        {
            dbContext.Entry(course).State = EntityState.Modified;
            dbContext.SaveChanges();
            return course;
        }
    }
}
