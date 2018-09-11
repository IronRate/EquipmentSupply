using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Services
{
    public interface ISupplyService
    {
        /// <summary>
        /// Создание поставки
        /// </summary>
        /// <param name="supply"></param>
        /// <returns></returns>
        Task<long> CreateAsync(Models.DB.Supply supply);

        /// <summary>
        /// Модификация поставки
        /// </summary>
        /// <param name="supply"></param>
        /// <returns></returns>
        Task ModifyAsync(Models.DB.Supply supply);

        /// <summary>
        /// Удаление поставки
        /// </summary>
        /// <param name="supply"></param>
        /// <returns></returns>
        Task RemoveAsync(Models.DB.Supply supply);

       
    }
}
