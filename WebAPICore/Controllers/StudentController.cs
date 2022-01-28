using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;
using WebAPICore.Services;

namespace WebAPICore.Controllers
{
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


        [HttpGet("get-student-by-id")]
        public Student GetStudentId(int id)
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
        
    }
}
