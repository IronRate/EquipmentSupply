using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Contracts.Services
{
    public interface INotificationSender
    {
        /// <summary>
        /// Отправка сообщения
        /// </summary>
        /// <param name="data">данные для отправки</param>
        /// <returns></returns>
        Task<bool> SendAsync(object data);
    }
}
