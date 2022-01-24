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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        public SubjectController(ISubjectService subject)
        {
            subjectService = subject;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Subject/GetSubject")]
        public IEnumerable<Subject> GetSubject()
        {
            return subjectService.GetSubject();
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/Subject/AddSubject")]
        public Subject AddSubject(Subject subject)
        {
            return subjectService.AddSubject(subject);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Subject/EditSubject")]
        public Subject EditSubject(Subject subject)
        {
            return subjectService.UpdateSubject(subject);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Subject/DeleteSubject")]
        public Subject DeleteSubject(int id)
        {
            return subjectService.DeleteSubject(id);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Subject/GetSubjectId")]
        public Subject GetSubjectId(int id)
        {
            return subjectService.GetSubjectById(id);
        }

    }
}
