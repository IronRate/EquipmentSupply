using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSupply.API.Controllers
{
    [Route("api/[controller]")]
    public class SuppliesController : Controller
    {
        #region Fields

        private readonly Domain.Contracts.Services.ISupplyService suppliesService;

        #endregion

        #region Constructor

        public SuppliesController(Domain.Contracts.Services.ISupplyService suppliesService)
        {
            this.suppliesService = suppliesService;
        }

        #endregion

        // GET: api/Supplies
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool isRemoved = false, [FromQuery] DateTimeOffset? dateFrom = null, [FromQuery] DateTimeOffset? dateTo=null)
        {

            var supplies = await this.suppliesService.GetAllAsync(isRemoved,new Domain.Models.DatePeriod(dateFrom,dateTo));
            return Ok(supplies.Select(x => new Models.ViewModels.SupplyModel(x)));
        }
        
        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var supply = await this.suppliesService.GetAsync(id);
            return Ok(supply);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.ViewModels.SupplyCreateModel supply)
        {
            if (supply == null)
            {
                ModelState.AddModelError(nameof(supply), new ArgumentNullException(nameof(supply)).ToString());
            }

            if (ModelState.IsValid)
            {
                var dbSupplies = supply.Supplies.Select(x => new Domain.Models.DB.Supply(supply.Provider.Id.GetValueOrDefault(), x.Equipment.Id.GetValueOrDefault(),supply.ProvideDate, x.Count));
                await this.suppliesService.CreateRangeAsync(dbSupplies);
                return Ok();
            }
            return BadRequest(ModelState);

        }


        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put([FromRoute]long id, [FromBody]Models.ViewModels.SupplyModifyModel supply)
        {
            if (supply == null)
            {
                ModelState.AddModelError(nameof(supply), new ArgumentNullException(nameof(supply)).Message);
            }

            if (ModelState.IsValid)
            {
                var dbSupply = await this.suppliesService.GetAsync(id);
                if (dbSupply != null)
                {
                    dbSupply.Count = supply.Supplies[0].Count;
                    dbSupply.EquipmentTypeId = supply.Supplies[0].Equipment.Id.Value;
                    dbSupply.ProvideDate = supply.ProvideDate;
                    dbSupply.ProviderId = supply.Provider.Id;
                    await this.suppliesService.ModifyAsync(dbSupply);
                    return Ok();
                }
                return NotFound();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            var supply = await this.suppliesService.GetAsync(id);
            if (supply != null)
            {
                await this.suppliesService.RemoveAsync(supply);
                return Ok();
            }
            else
                return NotFound("Entity not found");
        }
    }
}
