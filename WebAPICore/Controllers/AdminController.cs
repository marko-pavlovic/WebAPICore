using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.DbModels;
using WebAPICore.Services;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private AdminService adminService;

        public AdminController(AdminService admin)
        {
            adminService = admin;
        }

        [HttpGet("add-course")]
        public Course AddCourse(int subjectId, int professorId)
        {
            return adminService.AddCourse(subjectId, professorId);
        }

        [HttpPost("add-student")]
        public Student AddStudent(Student student)
        {
            return adminService.AddStudent(student);
        }

        [HttpGet("get-students")]
        public IEnumerable<Student> GetStudent()
        {
            return adminService.GetStudent();
        }

        [HttpGet("get-courses")]
        public IEnumerable<Course> GetCourse()
        {
            return adminService.GetCourse();
        }

        [HttpPut("edit-student")]
        public bool EditStudent(Student student)
        {
            return adminService.UpdateStudent(student);
        }


        [HttpDelete("delete-student")]
        public bool DeleteStudent(Student student)
        {
            return adminService.DeleteStudent(student);
        }

        [HttpPost("add-professor")]
        public Professor AddProfessor(Professor professor)
        {
            return adminService.AddProfessor(professor);
        }

        [HttpGet("enroll-student")]
        public StudentCourse EnrollStudent(int studentId, int courseId)
        {
            return adminService.EnrollStudent(studentId, courseId);
        }

        [HttpGet("unenroll-Student")]
        public StudentCourse UnEnrollStudent(int studentId, int courseId)
        {
            return adminService.EnrollStudent(studentId, courseId);
        }
    }
}
