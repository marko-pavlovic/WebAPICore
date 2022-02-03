using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DBCommunication.DbModels;
using System.Text.Json;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using WebAPICore.UIModels;

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

        
        [HttpGet("attending-courses")]
        public async Task<IEnumerable<Course>> AttendingCourses(int id)
        {
            var query = new Dictionary<string, string>() { ["id"] = id.ToString() };
            var uri = QueryHelpers.AddQueryString("https://localhost:44312/api/Student/attending-courses", query);
            var streamTask = client.GetStreamAsync(uri);
            var courses = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Course>>(await streamTask);

            return courses;
        }

        
        [HttpGet("course-marks")]  //ne vraca lepo
        public async Task<IEnumerable<Mark>> CourseMarks(int id, int cId)
        {
            var query = new Dictionary<string, string>() { 
                ["id"] = id.ToString(),
                ["cId"] = cId.ToString()
            };
            var uri = QueryHelpers.AddQueryString("https://localhost:44312/api/Student/attending-courses", query);
            var streamTask = client.GetStreamAsync(uri);
            var marks = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Mark>>(await streamTask);

            return marks;
        }

        
        [HttpPost("get-course-professor")]
        public async Task<Professor> GetCourseProfessor(Course course)
        {
            var json = JsonConvert.SerializeObject(course);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var streamTask = client.PostAsync("https://localhost:44312/api/Student/get-course-professor", data);
            var professor = JsonConvert.DeserializeObject<Professor>(await streamTask.Result.Content.ReadAsStringAsync());

            return professor;
        }

        #endregion


        #region professor

        
        [HttpGet("teaching-courses")]
        public async Task<IEnumerable<Course>> TeachingCourses(int id)
        {
            var query = new Dictionary<string, string>() { ["id"] = id.ToString() };
            var uri = QueryHelpers.AddQueryString("https://localhost:44312/api/Student/teaching-courses", query);
            var streamTask = client.GetStreamAsync(uri);
            var courses = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Course>>(await streamTask);

            return courses;
        }

        
        [HttpGet("teaching-students")]
        public async Task<IEnumerable<Student>> GetStudentsAsync(int id)
        {
            var query = new Dictionary<string, string>() { ["id"] = id.ToString() };
            var uri = QueryHelpers.AddQueryString("https://localhost:44312/api/Student/teaching-students", query);
            var streamTask = client.GetStreamAsync("query");
            var students = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Student>>(await streamTask);

            return students;
        }


        
        [HttpPost("add-mark")]
        public async Task<Mark> AddMark(AddMarkModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var streamTask = client.PostAsync("https://localhost:44312/api/Student/add-mark",data);
            var mark = JsonConvert.DeserializeObject<Mark>(await streamTask.Result.Content.ReadAsStringAsync());

            return mark;
        }

        
        [HttpPut("edit-mark")]
        public async Task<bool> EditMark(EditMarkModel model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var streamTask = client.PutAsync("https://localhost:44312/api/Student/edit-mark", data);
            bool ret = JsonConvert.DeserializeObject<bool>(await streamTask.Result.Content.ReadAsStringAsync());

            return ret;
        }
        
        
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

        #region Admin

        [HttpGet("get-students")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var streamTask = client.GetStreamAsync("https://localhost:44312/api/Admin/get-students");
            var students = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Student>>(await streamTask);

            return students;
        }

        [HttpGet("get-courses")]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            var streamTask = client.GetStreamAsync("https://localhost:44312/api/Admin/get-courses");
            var courses = await System.Text.Json.JsonSerializer.DeserializeAsync<IEnumerable<Course>>(await streamTask);

            return courses;
        }

        [HttpPost("add-student")]
        public async Task<Student> AddStudent(Student student)
        {
            var json = JsonConvert.SerializeObject(student);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var streamTask = client.PostAsync("https://localhost:44312/api/Admin/add-student", data);
            var student1 = JsonConvert.DeserializeObject<Student>(await streamTask.Result.Content.ReadAsStringAsync());

            return student1;
        }

        [HttpDelete("delete-student")]
        public async Task<bool> DeleteStudent(int studentId)
        {
            var query = new Dictionary<string, string>()
            {
                ["studentId"] = studentId.ToString()
            };
            var uri = QueryHelpers.AddQueryString("https://localhost:44312/api/Admin/delete-student", query);
            var streamTask = client.DeleteAsync(uri);
            bool ret = JsonConvert.DeserializeObject<bool>(await streamTask.Result.Content.ReadAsStringAsync());

            return ret;
        }

        [HttpPut("edit-student")]
        public async Task<Student> EditStudent(Student student)
        {
            var json = JsonConvert.SerializeObject(student);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var streamTask = client.PutAsync("https://localhost:44312/api/Admin/delete-student", data);
            var student1 = JsonConvert.DeserializeObject<Student>(await streamTask.Result.Content.ReadAsStringAsync());

            return student1;
        }

        [HttpGet("enroll-student")]
        public async Task<StudentCourse> EnrollStudent(int studentId, int courseId)
        {
            var query = new Dictionary<string, string>()
            {
                ["studentId"] = studentId.ToString(),
                ["courseId"] = courseId.ToString()
            };
            var uri = QueryHelpers.AddQueryString("https://localhost:44312/api/Admin/enroll-student", query);
            var streamTask = client.GetStreamAsync(uri);
            var studentcourse = await System.Text.Json.JsonSerializer.DeserializeAsync<StudentCourse>(await streamTask);

            return studentcourse;
        }

        [HttpGet("unenroll-student")]
        public async Task<StudentCourse> UnEnrollStudent(int studentId, int courseId)
        {
            var query = new Dictionary<string, string>()
            {
                ["studentId"] = studentId.ToString(),
                ["courseId"] = courseId.ToString()
            };
            var uri = QueryHelpers.AddQueryString("https://localhost:44312/api/Admin/unenroll-student", query);
            var streamTask = client.GetStreamAsync(uri);
            var studentcourse = await System.Text.Json.JsonSerializer.DeserializeAsync<StudentCourse>(await streamTask);

            return studentcourse;
        }

        #endregion
    }
}
