using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    public interface IEqupmentTypesRepository:IDbRepository<Models.DB.EquipmentType,long>
    {
    }
}
