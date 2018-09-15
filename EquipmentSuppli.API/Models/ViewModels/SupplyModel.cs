using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.API.Models.ViewModels
{
    public class SupplyModel
    {
        #region Constructor


        public SupplyModel(Domain.Models.DB.Supply supply)
        {
            this.Id = supply.Id;
            this.Count = supply.Count;
            this.EquipmentTypeId = supply.EquipmentTypeId;
            this.IsDelete = supply.IsDelete;
            this.ProvideDate = supply.ProvideDate;
            this.ProviderId = supply.ProviderId;
            this.Provider = new ProviderModel()
            {
                Id = supply.ProviderId,
                Name = supply.ProviderName
            };
            this.EquipmentType = new EquipmentTypeModel
            {
                Id = supply.EquipmentTypeId,
                Name = supply.EquipmentTypeName
            };
        }

        #endregion


        #region Properties

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
        [Required]
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

        public EquipmentTypeModel EquipmentType { get; set; }

        public ProviderModel Provider { get; set; }


        #endregion
    }
}
