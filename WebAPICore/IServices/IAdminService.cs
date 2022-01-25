using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IAdminService
    {
        IEnumerable<Course> GetCourse();
        Course AddCourse(Course course);
        IEnumerable<Student> GetStudent();
        Student AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        bool EnrollStudent(Student student, Course course);
        bool UnEnrollStudent(Student student, Course course);
    }
}
