using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Models.DB
{
    /// <summary>
    /// Поставка
    /// </summary>
    public class Supply
    {
        #region Constructor

        public Supply()
        {

        }

        public Supply(long providerId,long equipmentTypeId,long count)
        {
            Id = 0;
            ProvideDate = DateTimeOffset.Now;
            ProviderId = providerId;
            EquipmentTypeId = equipmentTypeId;
            Count = count;
            IsDelete = false;
        }

        #endregion

        /// <summary>
        /// Идентфикатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата поставки
        /// </summary>
        public DateTimeOffset ProvideDate { get; set; }

        /// <summary>
        /// Количество поставленных единиц
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// Признак удаленной поставки
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// Идентификатор поставщика
        /// </summary>
        public long ProviderId { get; set; }

        /// <summary>
        /// Тип оборудования
        /// </summary>
        public long EquipmentTypeId { get; set; }

        /// <summary>
        /// Наименование вида оборудования
        /// </summary>
        public string EquipmentTypeName { get; set; }

        /// <summary>
        /// Наименование поставщика
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// Поставщик
        /// </summary>
        public virtual Provider Provider { get; set; }

        /// <summary>
        /// Вид оборудования
        /// </summary>
        public virtual EquipmentType EquipmentType { get; set; }


        /// <summary>
        /// Нотификации по данной поставке
        /// </summary>
        public virtual ICollection<NotificationQueue> Notifications {get;set;}
    }
}
