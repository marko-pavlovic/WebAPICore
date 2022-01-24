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
    }
}
