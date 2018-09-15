using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Models.DB
{
    /// <summary>
    /// Поставщик
    /// </summary>
    public class Provider
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Электронная почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Юридический адрес
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        /// Поставки данного поставщика
        /// </summary>
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
