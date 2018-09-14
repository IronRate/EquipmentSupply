using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSupply.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Reports")]
    public class ReportsController : Controller
    {
        public ReportsController()
        {

        }

        // GET: api/Reports
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

    }
}
