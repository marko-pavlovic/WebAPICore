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

        public Course AddCourse(int subjectId, int professorId)
        {
            Course course = new Course();
            course.ProfessorId = subjectId;
            course.SubjectId = professorId;
            _dbContext.Course.Add(course);
            _dbContext.SaveChanges();

            return course;
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

        public StudentCourse EnrollStudent(int studentId, int courseId)
        {
            var studentCourse = new StudentCourse { CourseId = courseId, StudentId = studentId };
            _dbContext.StudentCourse.Add(studentCourse);
            _dbContext.SaveChanges();
            return studentCourse;
        }

        public StudentCourse UnEnrollStudent(int studentId, int courseId)
        {
            var studentCourse = new StudentCourse { CourseId = courseId, StudentId = studentId };
            _dbContext.StudentCourse.Remove(studentCourse);
            _dbContext.SaveChanges();
            return studentCourse;
        }

        public IEnumerable<Subject> GetSubject()
        {
            var subject = _dbContext.Subject.ToList();
            return subject;
        }

        public Professor AddProfessor(Professor professor)
        {
            if (professor != null)
            {
                _dbContext.Professor.Add(professor);
                _dbContext.SaveChanges();
                return professor;
            }
            return null;
        }
    }
}
