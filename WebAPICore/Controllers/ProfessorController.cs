using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBCommunication.DbModels;
using Aspose.Cells;
using System.Net.Http;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using DBCommunication.Services;
using WebAPICore.UIModels;
using Microsoft.AspNetCore.Authorization;
using DBCommunication.Permisions;

namespace WebAPICore.Controllers
{
    [Authorize(ApiClaims.PROFESSOR)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorService professorService;
        public ProfessorController(ProfessorService professor)
        {
            professorService = professor;
        }

        [HttpGet("get-professors")]
        public IEnumerable<Professor> GetProfessor()
        {
            return professorService.GetProfessor();
        }


        [HttpPost("add-professor")]
        public Professor AddProfessor(Professor professor)
        {
            return professorService.AddProfessor(professor);
        }


        [HttpPut("update-professor")]
        public Professor EditProfessor(Professor professor)
        {
            return professorService.UpdateProfessor(professor);
        }


        [HttpDelete("delete-professor")]
        public Professor DeleteProfessor(int id)
        {
            return professorService.DeleteProfessor(id);
        }

        [HttpPost("get-student-reports")]
        public FileResult ExportXlsx(Course course)
        {
            return professorService.ExportXlsx(course);
        }

        [HttpGet("get-professor-by-id")]
        public Professor GetProfessorId(int id)
        {
            return professorService.GetProfessorById(id);
        }

        [HttpPost("add-mark")]
        public Mark AddMark(AddMarkModel model)
        {
            return professorService.AddMark(model.StudentId, model.CourseId, model.Mark, model.Date, model.Comment);
        }

        [HttpGet("teaching-courses")]
        public IEnumerable<Course> TeachingCourses(int id)
        {
            return professorService.TeachingCourses(id);
        }

        [HttpGet("teaching-students")]
        public IEnumerable<Student> GetAllTeachingStudents(int id)
        {
            return professorService.GetAllTeachingStudents(id);
        }

        [HttpGet("get-all-students-per-course")]
        public Dictionary<int?, IEnumerable<Student>> GetAllStudentsPerCourse(int id)
        {
            return professorService.GetAllStudentsPerCourse(id);
        }

        [HttpPut("edit-mark")]
        public bool EditMark(EditMarkModel model) // fromquery bilo
        {
            return professorService.EditMark(model.Id, model.StudentId, model.CourseId, model.Mark, model.Date, model.Comment);
        }
        [HttpGet("get-students-by-course/{courseId}")]
        public IEnumerable<Student> GetStudentsByCourse(int courseId)
        {
            return professorService.GetStudentsByCourse(courseId);
        }
        
    }
}
