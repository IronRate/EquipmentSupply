using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Models.ViewModels
{
    public class SupplyCreateModel
    {
        public SupplyCreateModel()
        {

        }

        /// <summary>
        /// Поставщик
        /// </summary>
        [Required]
        public ProviderModel Provider { get; set; }

        /// <summary>
        /// Поставки
        /// </summary>
        [Required]
        public List<SupplyCreateRowModel> Supplies { get; set; }

        /// <summary>
        /// Дата поставки
        /// </summary>
        [Required]
        public DateTimeOffset ProvideDate { get; set; }


        public class SupplyCreateRowModel
        {
            [Required]
            public long Count { get; set; }


            public EquipmentTypeModel Equipment { get; set; }

        }
    }
}
