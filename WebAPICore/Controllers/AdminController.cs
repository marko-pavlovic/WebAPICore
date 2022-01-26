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
    public class AdminController : ControllerBase
    {
        private IAdminService adminService;

        public AdminController(IAdminService admin)
        {
            adminService = admin;
        }

        [HttpGet("AddCourse")]
        public Course AddCourse(int subjectId, int professorId)
        {
            return adminService.AddCourse(subjectId, professorId);
        }

        [HttpPost("AddStudent")]
        public Student AddStudent(Student student)
        {
            return adminService.AddStudent(student);
        }

        [HttpGet("GetStudents")]
        public IEnumerable<Student> GetStudent()
        {
            return adminService.GetStudent();
        }

        [HttpGet("GetCourses")]
        public IEnumerable<Course> GetCourse()
        {
            return adminService.GetCourse();
        }

        [HttpPut("EditStudent")]
        public bool EditStudent(Student student)
        {
            return adminService.UpdateStudent(student);
        }


        [HttpDelete("DeleteStudent")]
        public bool DeleteStudent(Student student)
        {
            return adminService.DeleteStudent(student);
        }

        [HttpPost("AddProfessor")]
        public Professor AddProfessor(Professor professor)
        {
            return adminService.AddProfessor(professor);
        }

        [HttpGet("EnrollStudent")]
        public StudentCourse EnrollStudent(int studentId, int courseId)
        {
            return adminService.EnrollStudent(studentId, courseId);
        }

        [HttpGet("UnEnrollStudent")]
        public StudentCourse UnEnrollStudent(int studentId, int courseId)
        {
            return adminService.EnrollStudent(studentId, courseId);
        }
    }
}
