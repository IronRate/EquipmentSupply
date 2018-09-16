using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSupply.API.Controllers
{
    [Route("api/Reports")]
    public class ReportsController : Controller
    {
        private readonly Services.Reports.EquipmentReport equipmentReport;

        public ReportsController(Services.Reports.EquipmentReport equipmentReport)
        {
            this.equipmentReport = equipmentReport;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok();
        }


        [HttpGet("providers/{providerId:long}/equipments")]
        public async Task<IActionResult> Get([FromRoute]long providerId)
        {
            return Ok(await equipmentReport.GetAsync(providerId));
        }

    }
}
