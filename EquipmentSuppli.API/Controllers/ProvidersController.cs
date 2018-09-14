using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentSupply.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Providers")]
    public class ProvidersController : Controller
    {
        // GET: api/Providers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            return Ok();
        }

        // GET: api/Providers/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Providers
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Providers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
