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
    public class PredmetController : ControllerBase
    {
        private readonly IPredmetService predmetService;
        public PredmetController(IPredmetService predmet)
        {
            predmetService = predmet;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Predmet/GetPredmet")]
        public IEnumerable<Predmet> GetPredmet()
        {
            return predmetService.GetPredmet();
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/Predmet/AddPredmet")]
        public Predmet AddPredmet(Predmet predmet)
        {
            return predmetService.AddPredmet(predmet);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Predmet/EditPredmet")]
        public Predmet EditPredmet(Predmet predmet)
        {
            return predmetService.UpdatePredmet(predmet);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Predmet/DeletePredmet")]
        public Predmet DeletePredmet(int id)
        {
            return predmetService.DeletePredmet(id);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Predmet/GetPredmetId")]
        public Predmet GetPredmetId(int id)
        {
            return predmetService.GetPredmetById(id);
        }
    }
}
