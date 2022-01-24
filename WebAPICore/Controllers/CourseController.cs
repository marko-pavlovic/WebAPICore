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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;
        public CourseController(ICourseService course)
        {
            courseService = course;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Course/GetCourse")]
        public IEnumerable<Course> GetCourse()
        {
            return courseService.GetCourse();
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/Course/AddCourse")]
        public Course AddCourse(Course course)
        {
            return courseService.AddCourse(course);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Course/EditCourse")]
        public Course EditCourse(Course course)
        {
            return courseService.UpdateCourse(course);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Course/DeleteCourse")]
        public Course DeleteCourse(int id)
        {
            return courseService.DeleteCourse(id);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Course/GetCourseId")]
        public Course GetCourseId(int id)
        {
            return courseService.GetCourseById(id);
        }

    }
}
