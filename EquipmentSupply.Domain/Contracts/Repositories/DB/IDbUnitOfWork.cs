using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Contracts.Repositories.DB
{
    public interface IDbUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Поставки
        /// </summary>
        ISuppliesRepository Supplies { get; }

        /// <summary>
        /// Виды оборудования
        /// </summary>
        IEqupmentTypesRepository EqupmentTypes { get; }

        /// <summary>
        /// Нотификации
        /// </summary>
        INotificationQueueRepository NotificationQueues { get; }

        /// <summary>
        /// Поставщики
        /// </summary>
        IProvidersRepository Providers { get; }
    }
}
