using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Models.DB
{
    /// <summary>
    /// Тип оборудования
    /// </summary>
    public class EquipmentType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование типа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Поставки данного типа оборудования
        /// </summary>
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
