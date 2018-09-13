using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Models.DB
{
    /// <summary>
    /// Очередь нотификаций
    /// </summary>
    public class NotificationQueue
    {
        #region COnstructor

        /// <summary>
        /// Конструктор
        /// </summary>
        protected NotificationQueue()
        {

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="supply">поставка</param>
        /// <param name="operationType">тип операции</param>
        public NotificationQueue(Models.DB.Supply supply, Enums.OperationType operationType)
        {
            this.Supply = supply;
            this.OperationType = operationType;
            this.Date = DateTimeOffset.Now;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Первичный ключь
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор поступления
        /// </summary>
        public long SupplyId { get; set; }


        /// <summary>
        /// Время произведенной операции
        /// </summary>
        public DateTimeOffset Date { get; set; }

        /// <summary>
        /// Вид операции
        /// </summary>
        public Enums.OperationType OperationType { get; set; }

        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTimeOffset? SendDate { get; set; }


        /// <summary>
        /// Поставка
        /// </summary>
        public virtual Supply Supply { get; set; }

        #endregion
    }
}
