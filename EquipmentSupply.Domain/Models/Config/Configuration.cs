using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Models.Config
{
    public class Configuration:ConfigValidatatbleObject
    {

        public EmailConfiguration EmailConfiguration{get;set;}

        /// <summary>
        /// Периодичность опроса очереди на отправку в секунду
        /// </summary>
        public int Interval { get; set; }

        /// <summary>
        /// Количество нотификационных сообщений отправляемых за одну траназкцию - 0 нелемитировано
        /// </summary>
        public int NotificationLimit { get; set; }


        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
