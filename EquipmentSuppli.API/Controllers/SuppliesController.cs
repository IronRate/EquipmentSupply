using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSupply.API.Controllers
{
    [Produces("application/json")]
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
        public async Task<IActionResult> Get()
        {
            var supplies = await this.suppliesService.GetAllAsync();
            return Ok(supplies.Select(x => new Models.ViewModels.SupplyModel(x)));
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTimeOffset dateFrom, [FromQuery] DateTimeOffset? dateTo = null)
        {
            var supplies = await this.suppliesService.GetAsync(new Domain.Models.DatePeriod(dateFrom, dateTo));
            return Ok(supplies.Select(x => new Models.ViewModels.SupplyModel(x)));
        }

        // GET: api/Supplies/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(long id)
        {
            return "value";
        }

        // POST: api/Supplies
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.ViewModels.SupplyModel supply)
        {
            if (ModelState.IsValid) {

            }
            return BadRequest(ModelState);

        }

        // PUT: api/Supplies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Models.ViewModels.SupplyModifyModel supply)
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

                }

                throw new NotImplementedException();

            }

            return BadRequest(ModelState);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
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
