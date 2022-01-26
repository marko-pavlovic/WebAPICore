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
        Course AddCourse(int subjectId, int professorId);
        IEnumerable<Student> GetStudent();
        Student AddStudent(Student student);
        bool UpdateStudent(Student student);
        bool DeleteStudent(Student student);
        StudentCourse EnrollStudent(int studentId, int courseId);
        StudentCourse UnEnrollStudent(int studentId, int courseId);
        IEnumerable<Subject> GetSubject();
        Professor AddProfessor(Professor professor);
    }
}
