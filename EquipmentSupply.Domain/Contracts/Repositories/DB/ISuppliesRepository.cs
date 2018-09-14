using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    public interface ISuppliesRepository:IDbRepository<Models.DB.Supply,long>
    {
        Task<IEnumerable<Models.DB.Supply>> GetAllExtendedAsync();

        Task<Supply> GetExtendedAsync(long id);

        /// <summary>
        /// Получение информации о наличии поставок для этого поставщика
        /// </summary>
        /// <param name="provider">поставщик</param>
        /// <returns>true - если такие поставки есть, false - если таких поставок нет</returns>
        Task<bool> HasSuppliesForProvider(Domain.Models.DB.Provider provider);
    }
}
