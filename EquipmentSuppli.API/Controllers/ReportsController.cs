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
        private readonly Services.Reports.EquipmentsReportService equipmentReport;
        private readonly Services.Reports.ProvidersReportService providersReport;

        public ReportsController(Services.Reports.EquipmentsReportService equipmentReport,Services.Reports.ProvidersReportService providersReport)
        {
            this.equipmentReport = equipmentReport;
            this.providersReport = providersReport;
        }

      


        [HttpGet("providers/{providerId:long}/equipments")]
        public async Task<IActionResult> Get([FromRoute]long providerId)
        {
            return Ok(await equipmentReport.GetAsync(providerId));
        }

        [HttpGet("providers")]
        public async Task<IActionResult> Get()
        {
            return Ok( await this.providersReport.GetAsync());
        }

    }
}
