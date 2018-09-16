using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Models.Reports
{
    public class EquipmentReportModel
    {
        public ViewModels.EquipmentTypeModel EquipmentType { get; set; }

        public long Count { get; set; }
    }
}
