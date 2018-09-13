using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Repositories
{
    public interface IConfigRepository
    {
        Task<Models.Config.Configuration> GetAsync();

        Task SaveAsync();
    }
}
