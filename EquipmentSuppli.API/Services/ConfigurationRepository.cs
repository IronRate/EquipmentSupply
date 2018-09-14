using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.Config;
using Microsoft.Extensions.Configuration;

namespace EquipmentSupply.API.Services
{
    public class ConfigurationRepository : Domain.Contracts.Repositories.IConfigRepository
    {
        private readonly IConfiguration _config;
        private Configuration _configuration;

        public ConfigurationRepository(IConfiguration configuration)
        {
            this._config = configuration;
            this.Init();

        }
        public Configuration Get()
        {

            return _configuration;
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        private void Init()
        {
            _configuration = new Configuration();
            this._config.GetSection("Configuration").Bind(_configuration);
        }
    }
}
