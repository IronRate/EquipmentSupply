using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Services.Reports
{
    public class EquipmentReport
    {
        private readonly DAL.Contexts.DbSuppliesViewContext viewContext;

        public EquipmentReport(DAL.Contexts.DbSuppliesViewContext viewContext)
        {
            this.viewContext = viewContext;
        }

        public async Task<IEnumerable<EquipmentSupply.API.Models.Reports.EquipmentReportModel>> GetAsync(long providerId) {
            return await this.viewContext.Supplies.Where(x => x.ProviderId == providerId && x.IsDelete == false)
                .Select(x=>new Models.Reports.EquipmentReportModel() { })
                .ToListAsync();
        }
    }
}
