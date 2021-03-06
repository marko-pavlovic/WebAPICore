using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBCommunication.DbModels;
using DBCommunication.Models;
using DBCommunication.Permisions;
using DBCommunication.Services;

namespace WebAPICore.Controllers
{
    [Authorize(ApiClaims.STUDENT)]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService studentService;
        public StudentController(StudentService student)
        {
            studentService = student;
        }

        
        [HttpGet("get-students")]
        public IEnumerable<Student> GetStudent()
        {
            return studentService.GetStudent();
        }

        [HttpPost("add-student")]
        public int AddStudent(Student student)
        {
            return studentService.AddStudent(student);
        }


        [HttpPut("edit-student")]
        public bool EditStudent(Student student)
        {
            return studentService.UpdateStudent(student);
        }


        [HttpDelete("delete-student")]
        public bool DeleteStudent(Student student)
        {
            return studentService.DeleteStudent(student);
        }


        [HttpGet("get-student-by-id/{id}")]
        public Student GetStudentById(int id)
        {
            return studentService.GetStudentById(id);
        }

        [HttpGet("attending-courses")]
        public IEnumerable<Course> AttendingCourses(int id)
        {
            return studentService.AttendingCourses(id);
        }

        [HttpGet("course-marks")]
        public IEnumerable<Mark> CourseMarks(int id, int cId)
        {
            return studentService.Marks(id, cId);
        }

        [HttpPost("get-course-professor")]
        public Professor GetCourseProfessor(Course course)
        {
            return studentService.GetCourseProfessor(course);
        }

    }
}
