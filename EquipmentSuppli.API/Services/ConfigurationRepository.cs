using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.Config;

namespace EquipmentSupply.API.Services
{
    public class ConfigurationRepository : Domain.Contracts.Repositories.IConfigRepository
    {
        public Task<Configuration> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
