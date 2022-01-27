using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Models;
using Aspose.Cells;
using System.Net.Http;
using System.IO;
using System.Data;
using ClosedXML.Excel;
using WebAPICore.Services;
using WebAPICore.UIModels;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorService professorService;
        public ProfessorController(ProfessorService professor)
        {
            professorService = professor;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Professor/GetProfessor")]
        public IEnumerable<Professor> GetProfessor()
        {
            return professorService.GetProfessor();
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/Professor/AddProfessor")]
        public Professor AddProfessor(Professor professor)
        {
            return professorService.AddProfessor(professor);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Professor/EditProfessor")]
        public Professor EditProfessor(Professor professor)
        {
            return professorService.UpdateProfessor(professor);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Professor/DeleteProfessor")]
        public Professor DeleteProfessor(int id)
        {
            return professorService.DeleteProfessor(id);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Professor/ExportToExcell")]
        public FileResult ExportToExcel()
        {
            return professorService.ExportToExcell();
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Professor/GetProfessorId")]
        public Professor GetProfessorId(int id)
        {
            return professorService.GetProfessorById(id);
        }

        [HttpPost]
        [Route("[action]")]
        [Route("api/Professor/CreateSheet")]
        public HttpResponseMessage CreateSheet(int id)
        {
            return professorService.CreateSheet(id);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Professor/AddMark")]
        public Mark AddMark([FromQuery] AddMarkModel model)
        {
            return professorService.AddMark(model.StudentId, model.CourseId, model.Mark, model.Date, model.Comment);
        }
    }
}
