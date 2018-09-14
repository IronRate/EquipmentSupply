using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Services
{
    public interface INotificationWorkerService
    {
        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <returns></returns>
        Task DoWorkAsync();
    }
}
