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
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService professorService;
        public ProfessorController(IProfessorService professor)
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
        [Route("api/Professor/GetProfessorId")]
        public Professor GetProfessorId(int id)
        {
            return professorService.GetProfessorById(id);
        }
    }
}
