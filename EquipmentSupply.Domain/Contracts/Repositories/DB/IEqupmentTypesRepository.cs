using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    public interface IEqupmentTypesRepository:IDbRepository<Models.DB.EquipmentType,long>
    {
        
    }
}
