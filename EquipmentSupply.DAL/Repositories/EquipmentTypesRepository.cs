using System;
using System.Collections.Generic;
using System.Text;
using EquipmentSupply.DAL.Contexts;

namespace EquipmentSupply.DAL.Repositories
{
    public class EquipmentTypesRepository : DbRepository<Domain.Models.DB.EquipmentType, long>, Domain.Contracts.Repositories.DB.IEqupmentTypesRepository
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">контекст</param>
        public EquipmentTypesRepository(DbSuppliesContext context) : base(context)
        {
        }
    }
}
