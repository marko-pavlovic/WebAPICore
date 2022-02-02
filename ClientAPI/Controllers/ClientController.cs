using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAPICore.DbModels;
using System.Text.Json;
using NuGet.Protocol.Core.Types;
using Microsoft.AspNetCore.Authorization;
using WebAPICore.Permisions;
using Newtonsoft.Json;
using System.Text;
using System.IO;

namespace ClientAPI.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private HttpClient client = new HttpClient();
        public ClientController()
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region student

        [Authorize(ApiClaims.STUDENT)]
        [HttpGet("attending-courses")]
        public async Task<IEnumerable<Course>> AttendingCourses()
        {
            var streamTask = client.GetStreamAsync("https://localhost:44312/api/Student/attending-courses");
            var courses = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Course>>(await streamTask);

            return courses;
        }

        [Authorize(ApiClaims.STUDENT)]
        [HttpGet("course-marks")]
        public async Task<IEnumerable<Mark>> CourseMarks()
        {
            var streamTask = client.GetStreamAsync("https://localhost:44312/api/Student/course-marks");
            var marks = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Mark>>(await streamTask);

            return marks;
        }

        [Authorize(ApiClaims.STUDENT)]
        [HttpGet("get-course-professor")]
        public async Task<Professor> GetCourseProfessor()
        {
            var streamTask = client.GetStreamAsync("https://localhost:44312/api/Student/get-course-professor");
            var professor = await System.Text.Json.JsonSerializer.DeserializeAsync<Professor>(await streamTask);

            return professor;
        }

        #endregion


        #region professor

        [Authorize(ApiClaims.PROFESSOR)]
        [HttpGet("teaching-courses")]
        public async Task<IEnumerable<Course>> TeachingCourses()
        {
            var streamTask = client.GetStreamAsync("https://localhost:44312/api/Professor/teaching-courses");
            var courses = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Course>>(await streamTask);

            return courses;
        }

        [Authorize(ApiClaims.PROFESSOR)]
        [HttpGet("get-all-teaching-students")]
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            var streamTask = client.GetStreamAsync("https://localhost:44312/api/Professor/get-all-teaching-students");
            var students = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Student>>(await streamTask);

            return students;
        }


        [Authorize(ApiClaims.PROFESSOR)]
        [HttpGet("add-mark")]
        public async Task<Mark> AddMark()
        {
            var streamTask = client.GetStreamAsync("https://localhost:44312/api/Student/add-mark");
            var mark = await System.Text.Json.JsonSerializer.DeserializeAsync<Mark>(await streamTask);

            return mark;
        }

        [Authorize(ApiClaims.PROFESSOR)]
        [HttpPut("edit-mark")]
        public async Task<bool> EditMark(Mark mark)
        {
            var json = JsonConvert.SerializeObject(mark);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var streamTask = client.PutAsync("https://localhost:44312/api/Student/edit-mark", data);
            bool ret = JsonConvert.DeserializeObject<bool>(await streamTask.Result.Content.ReadAsStringAsync());

            return ret;
        }
        
        [Authorize(ApiClaims.PROFESSOR)]
        [HttpPost("get-student-reports")]
        public async Task<FileContentResult> ExportXlsx(Course course)
        {
            var json = JsonConvert.SerializeObject(course);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var streamTask = client.PostAsync("https://localhost:44312/api/Student/get-student-reports", data);

            var bytes = await streamTask.Result.Content.ReadAsByteArrayAsync();
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileContentResult = new FileContentResult(bytes, contentType)
            {
                FileDownloadName = "report.xlsx"
            };

            return fileContentResult;
        }
        #endregion
    }
}
