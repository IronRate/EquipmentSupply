using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    /// <summary>
    /// Репозиторий нотификаций
    /// </summary>
    public interface INotificationQueueRepository:IDbRepository<Models.DB.NotificationQueue,long>
    {
    }
}
