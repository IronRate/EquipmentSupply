﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.DAL.Contexts;
using EquipmentSupply.Domain.Models.DB;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Supply>> GetAllExtendedAsync()
        {
            return await context.Supplies.Select(x => new Supply
            {
                Count = x.Count,
                EquipmentTypeId = x.EquipmentTypeId,
                EquipmentTypeName = x.EquipmentTypeName,
                Id = x.Id,
                IsDelete = x.IsDelete,
                ProvideDate = x.ProvideDate,
                ProviderId = x.ProviderId,
                ProviderName = x.ProviderName
            }).ToListAsync();
        }

        public Task<Supply> GetExtendedAsync(long id)
        {
            return context.Supplies
                .Where(x => x.Id == id)
                .Select(x => new Supply
                {
                    Count = x.Count,
                    EquipmentTypeId = x.EquipmentTypeId,
                    EquipmentTypeName = x.EquipmentTypeName,
                    Id = x.Id,
                    IsDelete = x.IsDelete,
                    ProvideDate = x.ProvideDate,
                    ProviderId = x.ProviderId,
                    ProviderName = x.ProviderName
                }).FirstOrDefaultAsync();
        }
    }
}
