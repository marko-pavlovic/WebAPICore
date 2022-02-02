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
    public class CourseController : ControllerBase
    {
        private readonly CourseService courseService;
        public CourseController(CourseService course)
        {
            courseService = course;
        }

        [HttpGet("get-courses")]
        public IEnumerable<Course> GetCourse()
        {
            return courseService.GetCourse();
        }


        [HttpPost("add-course")]
        public Course AddCourse(Course course)
        {
            return courseService.AddCourse(course);
        }


        [HttpPut("edit-course")]
        public Course EditCourse(Course course)
        {
            return courseService.UpdateCourse(course);
        }


        [HttpDelete("delete-course")]
        public Course DeleteCourse(int id)
        {
            return courseService.DeleteCourse(id);
        }


        [HttpGet("get-course-by-id")]
        public Course GetCourseId(int id)
        {
            return courseService.GetCourseById(id);
        }

    }
}
