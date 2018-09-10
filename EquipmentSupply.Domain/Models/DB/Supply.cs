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
        /// Поставщик
        /// </summary>
        public virtual Provider Provider { get; set; }

        /// <summary>
        /// Тип оборудования
        /// </summary>
        public virtual EquipmentType EquipmentType { get; set; }




    }
}
