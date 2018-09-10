using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    public interface ISuppliesRepository:IDbRepository<Models.DB.Supply,long>
    {
    }
}
