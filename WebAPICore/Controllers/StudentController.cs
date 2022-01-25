using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.IServices;
using WebAPICore.Models;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        public StudentController(IStudentService student)
        {
            studentService = student;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Student/GetStudent")]
        public IEnumerable<Student> GetStudent()
        {
            return studentService.GetStudent();
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Student/AddStudent")]
        public int AddStudent(Student student)
        {
            return studentService.AddStudent(student);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Student/EditStudent")]
        public bool EditStudent(Student student)
        {
            return studentService.UpdateStudent(student);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Student/DeleteStudent")]
        public bool DeleteStudent(Student student)
        {
            return studentService.DeleteStudent(student);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Student/GetStudentId")]
        public Student GetStudentId(int id)
        {
            return studentService.GetStudentById(id);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Student/AttendingCourses")]
        public IEnumerable<Course> AttendingCourses(int id)
        {
            return studentService.AttendingCourses(id);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Student/CourseMark")]
        public IEnumerable<Mark> CourseMark(int id, int cId)
        {
            return studentService.Marks(id, cId);
        }
        
    }
}
