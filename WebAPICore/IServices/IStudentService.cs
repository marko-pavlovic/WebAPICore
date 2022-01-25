using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;

namespace WebAPICore.IServices
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudent();
        Student GetStudentById(int id);
        int AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        IEnumerable<Course> AttendingCourses(int id);
        public IEnumerable<Mark> Marks(int id, int cId);
    }
}
