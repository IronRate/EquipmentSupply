﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

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
        Task<IEnumerable<Models.DB.Supply>> GetAllAsync(bool isRemoved,Domain.Models.DatePeriod datePeriod);

        /// <summary>
        /// Вернет поставку по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Models.DB.Supply> GetAsync(long id);


        /// <summary>
        /// Создает поставки в хранилище
        /// </summary>
        /// <param name="dbSupplies">поставки</param>
        /// <returns></returns>
        Task CreateRangeAsync(IEnumerable<Supply> dbSupplies);
    }
}
