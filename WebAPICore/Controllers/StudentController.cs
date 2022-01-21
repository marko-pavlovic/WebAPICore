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
        public Student AddStudent(Student student)
        {
            return studentService.AddStudent(student);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Student/EditStudent")]
        public Student EditStudent(Student student)
        {
            return studentService.UpdateStudent(student);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Student/DeleteStudent")]
        public Student DeleteStudent(int id)
        {
            return studentService.DeleteStudent(id);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Student/GetStudentId")]
        public Student GetStudentId(int id)
        {
            return studentService.GetStudentById(id);
        }
    }
}
