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
    public class KursController : ControllerBase
    {
        private readonly IKursService kursService;
        public KursController(IKursService kurs)
        {
            kursService = kurs;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Kurs/GetKurs")]
        public IEnumerable<Kurs> GetKurs()
        {
            return kursService.GetKurs();
        }


        [HttpPost]
        [Route("[action]")]
        [Route("api/Kurs/AddKurs")]
        public Kurs AddKurs(Kurs kurs)
        {
            return kursService.AddKurs(kurs);
        }


        [HttpPut]
        [Route("[action]")]
        [Route("api/Kurs/EditKurs")]
        public Kurs EditKurs(Kurs kurs)
        {
            return kursService.UpdateKurs(kurs);
        }


        [HttpDelete]
        [Route("[action]")]
        [Route("api/Kurs/DeleteKurs")]
        public Kurs DeleteKurs(int id)
        {
            return kursService.DeleteKurs(id);
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/Kurs/GetKursId")]
        public Kurs GetKursId(int id)
        {
            return kursService.GetKursById(id);
        }

    }
}
