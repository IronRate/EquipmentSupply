using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Models.ViewModels
{
    public class SupplyModifyModel
    {
        #region Properties

        /// <summary>
        /// Идентфикатор
        /// </summary>
        [Required]
        public long Id { get; set; }

        /// <summary>
        /// Дата поставки
        /// </summary>
        [Required]
        public DateTimeOffset ProvideDate { get; set; }

        /// <summary>
        /// Количество поставленных единиц
        /// </summary>
        [Required,Range(0,long.MaxValue)]
        public long Count { get; set; }

        /// <summary>
        /// Признак удаленной поставки
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// Идентификатор поставщика
        /// </summary>
        [Required]
        public long ProviderId { get; set; }

        /// <summary>
        /// Тип оборудования
        /// </summary>
        [Required]
        public long EquipmentTypeId { get; set; }


        #endregion
    }
}
