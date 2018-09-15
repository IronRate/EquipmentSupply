using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Services
{
    public interface IProviderService
    {
        /// <summary>
        /// Добавит поставщика
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<long> CreateAsync(Models.DB.Provider provider);

        /// <summary>
        /// Вернет список поставщиков
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.DB.Provider>> GetAsync();

        /// <summary>
        /// Вернет поставщика по динетификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Models.DB.Provider> GetAsync(long id);

        /// <summary>
        /// Редактирование поставщика
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task ModifyAsync(Models.DB.Provider provider);

        /// <summary>
        /// Осуществляет поиск поставщика по части его наименования
        /// </summary>
        /// <param name="name">наименование</param>
        /// <returns></returns>
        Task<IEnumerable<Models.DB.Provider>> FindAsync(string name);

        /// <summary>
        /// Удаление поставщика в месте с его поставками
        /// </summary>
        /// <param name="provider">поставщик</param>
        /// <param name="force">Принудительно удаление поставщика</param>
        /// <returns></returns>
        Task RemoveAsync(Models.DB.Provider provider,bool force=false);

        /// <summary>
        /// Вернет - возможно ли удаление поставщика
        /// </summary>
        /// <param name="provider">поставщик</param>
        /// <returns></returns>
        Task<bool> CanRemove(Models.DB.Provider provider);


    }
}
