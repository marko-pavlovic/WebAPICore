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
    public class SubjectController : ControllerBase
    {
        private readonly SubjectService subjectService;
        public SubjectController(SubjectService subject)
        {
            subjectService = subject;
        }

        [HttpGet("get-subjects")]
        public IEnumerable<Subject> GetSubject()
        {
            return subjectService.GetSubject();
        }


        [HttpPost("add-subject")]
        public Subject AddSubject(Subject subject)
        {
            return subjectService.AddSubject(subject);
        }


        [HttpPut("edit-subject")]
        public Subject EditSubject(Subject subject)
        {
            return subjectService.UpdateSubject(subject);
        }


        [HttpDelete("delete-subject")]
        public Subject DeleteSubject(int id)
        {
            return subjectService.DeleteSubject(id);
        }


        [HttpGet("get-subject-by-id")]
        public Subject GetSubjectId(int id)
        {
            return subjectService.GetSubjectById(id);
        }

    }
}
