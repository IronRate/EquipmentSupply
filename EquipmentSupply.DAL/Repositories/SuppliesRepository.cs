using System;
using System.Collections.Generic;
using System.Text;
using EquipmentSupply.DAL.Contexts;

namespace EquipmentSupply.DAL.Repositories
{
    public class SuppliesRepository : DbRepository<Domain.Models.DB.Supply, long>, Domain.Contracts.Repositories.DB.ISuppliesRepository
    {
        /// <summary>
        /// Коснтруток
        /// </summary>
        /// <param name="context">контекст</param>
        public SuppliesRepository(DbSuppliesContext context) : base(context)
        {
        }
    }
}
