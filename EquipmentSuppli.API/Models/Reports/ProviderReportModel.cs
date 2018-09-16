using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Models.Reports
{
    public class ProviderReportModel
    {
        public Models.ViewModels.ProviderModel Provider { get; set; }

        public decimal Percentage { get; set; }
    }
}
