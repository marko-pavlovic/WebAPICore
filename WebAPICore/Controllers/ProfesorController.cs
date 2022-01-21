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
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService profesorService;
        public ProfesorController(IProfesorService profesor)
        {
            profesorService = profesor;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Profesor/GetProfesor")]
        public IEnumerable<Profesor> GetProfesor()
        {
            return profesorService.GetProfesor();
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/Profesor/AddProfesor")]
        public Profesor AddProfesor(Profesor profesor)
        {
            return profesorService.AddProfesor(profesor);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Profesor/EditProfesor")]
        public Profesor EditProfesor(Profesor profesor)
        {
            return profesorService.UpdateProfesor(profesor);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Profesor/DeleteProfesor")]
        public Profesor DeleteProfesor(int id)
        {
            return profesorService.DeleteProfesor(id);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Profesor/GetProfesorId")]
        public Profesor GetProfesorId(int id)
        {
            return profesorService.GetProfesorById(id);
        }
    }
}
