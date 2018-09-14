using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSupply.API.Controllers
{
    [Produces("application/json")]
    [Route("api/EquipmentTypes")]
    public class EquipmentTypesController : Controller
    {
        private readonly Domain.Contracts.Services.IEquipmentTypeService equipmentTypeService;

        public EquipmentTypesController(Domain.Contracts.Services.IEquipmentTypeService equipmentTypeService)
        {
            this.equipmentTypeService = equipmentTypeService;
        }

        // GET: api/EquipmentTypes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var equipmentTypes = await this.equipmentTypeService.GetAsync();
            return Ok(equipmentTypes.Select(x => new Models.ViewModels.EquipmentTypeModel(x)));
        }

        // GET: api/EquipmentTypes/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var equipmentType = await this.equipmentTypeService.GetAsync(id);
            return Ok(new Models.ViewModels.EquipmentTypeModel(equipmentType));
        }

        // POST: api/EquipmentTypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Models.ViewModels.EquipmentTypeModel equipment)
        {
            if (equipment == null)
            {
                ModelState.AddModelError(nameof(equipment), new ArgumentNullException(nameof(equipment)).ToString());
            }

            if (ModelState.IsValid)
            {

                Domain.Models.DB.EquipmentType dbEquipment = new Domain.Models.DB.EquipmentType(equipment.Name);
                await equipmentTypeService.CreateAsync(dbEquipment);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT: api/EquipmentTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.ViewModels.EquipmentTypeModel equipment)
        {
            if (equipment == null)
            {
                ModelState.AddModelError(nameof(equipment), new ArgumentNullException(nameof(equipment)).ToString());
            }

            if (ModelState.IsValid)
            {
                var dbEquipment = await equipmentTypeService.GetAsync(id);
                if (dbEquipment != null)
                {
                    dbEquipment.Name = equipment.Name;
                    await equipmentTypeService.ModifyAsync(dbEquipment);
                    return Ok();
                }
                else
                    return NotFound();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dbEquipment = await equipmentTypeService.GetAsync(id);
            if (dbEquipment != null)
            {
                await equipmentTypeService.RemoveAsync(dbEquipment);
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
