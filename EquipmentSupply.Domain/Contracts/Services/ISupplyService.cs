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

        /// <summary>
        /// Вернет все поставки
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.DB.Supply>> GetAllAsync();

        /// <summary>
        /// Вернет поставку по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Models.DB.Supply> GetAsync(long id);

        /// <summary>
        /// Вернет список поставок в указаный период времени
        /// </summary>
        /// <param name="datePeriod"></param>
        /// <returns></returns>
        Task<IEnumerable<Models.DB.Supply>> GetAsync(Models.DatePeriod datePeriod);

       
    }
}
