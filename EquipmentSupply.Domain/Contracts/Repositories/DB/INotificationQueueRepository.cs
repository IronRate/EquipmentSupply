using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    /// <summary>
    /// Репозиторий нотификаций
    /// </summary>
    public interface INotificationQueueRepository:IDbRepository<Models.DB.NotificationQueue,long>
    {
        /// <summary>
        /// Вернет список поступлений, готовых к отправке
        /// </summary>
        /// <param name="limit">указывает лимитированное количество отправок, которое стоит вернуть</param>
        /// <returns></returns>
        Task<IEnumerable<Models.DB.NotificationQueue>> GetReadyForSendingAsync(int limit);
    }
}
