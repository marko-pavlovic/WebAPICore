using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourse();
        Course GetCourseById(int id);
        Course AddCourse(Course course);
        Course UpdateCourse(Course course);
        Course DeleteCourse(int id);
    }
}
