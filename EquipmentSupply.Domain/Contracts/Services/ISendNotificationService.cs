using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Services
{
    public interface ISendNotificationService
    {
        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <returns></returns>
        Task SendAsync();
    }
}
