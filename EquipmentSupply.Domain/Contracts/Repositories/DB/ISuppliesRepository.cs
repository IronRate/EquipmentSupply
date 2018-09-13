using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    public interface ISuppliesRepository:IDbRepository<Models.DB.Supply,long>
    {
        Task<IEnumerable<Models.DB.Supply>> GetAllExtendedAsync();
    }
}
