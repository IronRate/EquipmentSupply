using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Services
{
    public interface IEquipmentTypeService
    {
        /// <summary>
        /// Добавит вид оборудования
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        Task<long> CreateAsync(Models.DB.EquipmentType provider);

        /// <summary>
        /// Вернет спписок видов оборудования
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.DB.EquipmentType>> GetAsync();

        /// <summary>
        /// Вернет вид оборудования по динетификатору
        /// </summary>
        /// <param name="id">идентификатор вида оборудования</param>
        /// <returns></returns>
        Task<Models.DB.EquipmentType> GetAsync(long id);

        /// <summary>
        /// Редактирование вида оборудования
        /// </summary>
        /// <param name="equipmentType"></param>
        /// <returns></returns>
        Task ModifyAsync(Models.DB.EquipmentType equipmentType);

        /// <summary>
        /// Удаление вида оборудования в месте с поставками, в котром этот вид оборудования используется
        /// </summary>
        /// <param name="equipmentType">поставщик</param>
        /// <param name="force">Принудительно удаление вида оборудования</param>
        /// <returns></returns>
        Task RemoveAsync(Models.DB.EquipmentType equipmentType, bool force = false);

        /// <summary>
        /// Вернет - возможно ли удаление вида оборудования
        /// </summary>
        /// <param name="equipmentType">вид оборудования</param>
        /// <returns></returns>
        Task<bool> CanRemove(Models.DB.EquipmentType equipmentType);
    }
}
