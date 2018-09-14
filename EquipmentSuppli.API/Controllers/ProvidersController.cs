using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EquipmentSupply.API.Controllers
{
    [Route("api/Providers")]
    public class ProvidersController : Controller
    {
        private readonly Domain.Contracts.Services.IProviderService providerService;

        public ProvidersController(Domain.Contracts.Services.IProviderService providerService)
        {
            this.providerService = providerService;
        }

        // GET: api/Providers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dbProviders = await this.providerService.GetAsync();
            return Ok(dbProviders.Select(x => new Models.ViewModels.ProviderModel(x)));
        }

        // GET: api/Providers/5
        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var dbProvider = await this.providerService.GetAsync(id);
            return Ok(new Models.ViewModels.ProviderModel(dbProvider));
        }

        // POST: api/Providers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.ViewModels.ProviderModel provider)
        {
            if (provider == null)
            {
                ModelState.AddModelError(nameof(provider), new ArgumentNullException(nameof(provider)).ToString());
            }

            if (ModelState.IsValid)
            {
                //await this.providerService.CreateAsync(new Domain.Models.DB.Provider()
                //{
                //    Address = provider.Address,
                //    Email = provider.Email,
                //    Name = provider.Name
                //});
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Providers/5
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Put(long id, Models.ViewModels.ProviderModel provider)
        {
            if (provider == null)
            {
                ModelState.AddModelError(nameof(provider), new ArgumentNullException(nameof(provider)).ToString());
            }

            if (ModelState.IsValid)
            {
                await this.providerService.ModifyAsync(new Domain.Models.DB.Provider()
                {
                    Id = id,
                    Address = provider.Address,
                    Email = provider.Email,
                    Name = provider.Name
                });
                return Ok();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var dbProvider = await this.providerService.GetAsync(id);
            if (dbProvider != null)
            {
                await this.providerService.RemoveAsync(dbProvider);
                return Ok();

            }
            return NotFound();
        }
    }
}
