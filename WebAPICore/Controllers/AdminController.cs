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
    public class AdminController : ControllerBase
    {
        private object adminService;

        public AdminController(IAdminService admin)
        {
            adminService = admin;
        }

      

        [HttpPost]
        [Route("[action]")]
        [Route("api/Admin/AddKurs")]
        public Kurs AddKurs(Kurs kurs)
        {
            return new Kurs();
        }
    }
}
