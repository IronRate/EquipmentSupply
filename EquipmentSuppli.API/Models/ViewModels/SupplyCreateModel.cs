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

        [Required]
        public ProviderModel Provider { get; set; }

        [Required]
        public List<SupplyCreateRowModel> Supplies { get; set; }


        public class SupplyCreateRowModel
        {
            [Required]
            public long Count { get; set; }


            public EquipmentTypeModel Equipment { get; set; }

        }
    }
}
