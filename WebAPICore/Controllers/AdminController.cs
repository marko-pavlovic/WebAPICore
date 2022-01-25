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

        [HttpPost]
        [Route("[action]")]
        [Route("api/Admin/AddCourse")]
        public Course AddKurs(Course course)
        {
            return adminService.AddCourse(course);
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Admin/AddStudent")]
        public Student AddStudent(Student student)
        {
            return adminService.AddStudent(student);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Admin/GetStudent")]
        public IEnumerable<Student> GetStudent()
        {
            return adminService.GetStudent();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Admin/GetCourse")]
        public IEnumerable<Course> GetCourse()
        {
            return adminService.GetCourse();
        }

        [HttpPut]
        [Route("[action]")]
        [Route("api/Admin/EditStudent")]
        public bool EditStudent(Student student)
        {
            return adminService.UpdateStudent(student);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Admin/DeleteStudent")]
        public bool DeleteStudent(Student student)
        {
            return adminService.DeleteStudent(student);
        }
    }
}
