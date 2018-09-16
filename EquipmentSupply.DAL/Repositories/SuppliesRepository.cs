using System;
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

        public async Task<IEnumerable<Supply>> GetAllExtendedAsync(bool isRemoved, DateTimeOffset? dateFrom, DateTimeOffset? dateTo)
        {


            var q = context.Supplies
                .Where(x => x.IsDelete == isRemoved);

            if (dateFrom.HasValue && dateTo.HasValue)
            {
                q = q.Where(x => x.ProvideDate >= dateFrom && x.ProvideDate <= dateTo);
            }
            q.Select(x => new Supply
            {
                Count = x.Count,
                EquipmentTypeId = x.EquipmentTypeId,
                EquipmentTypeName = x.EquipmentType.Name,
                Id = x.Id,
                IsDelete = x.IsDelete,
                ProvideDate = x.ProvideDate,
                ProviderId = x.ProviderId,
                ProviderName = x.Provider.Name
            });

            return await q.ToListAsync();
        }

        public Task<Supply> GetExtendedAsync(long id)
        {
            return context.Supplies
                .Where(x => x.Id == id)
                .Select(x => new Supply
                {
                    Count = x.Count,
                    EquipmentTypeId = x.EquipmentTypeId,
                    EquipmentTypeName = x.EquipmentType.Name,
                    Id = x.Id,
                    IsDelete = x.IsDelete,
                    ProvideDate = x.ProvideDate,
                    ProviderId = x.ProviderId,
                    ProviderName = x.Provider.Name
                }).FirstOrDefaultAsync();
        }

        public Task<bool> HasForEquipmentType(EquipmentType equipmentType)
        {
            return context.Supplies
                .AnyAsync(x => x.EquipmentTypeId == equipmentType.Id);
        }

        public Task<bool> HasForProvider(Provider provider)
        {
            return context.Supplies
                .AnyAsync(x => x.ProviderId == provider.Id);
        }
    }
}
