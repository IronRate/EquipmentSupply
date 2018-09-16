using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Services.Reports
{
    public class EquipmentsReportService
    {
        private readonly DAL.Contexts.DbSuppliesViewContext viewContext;

        public EquipmentsReportService(DAL.Contexts.DbSuppliesViewContext viewContext)
        {
            this.viewContext = viewContext;
        }

        public async Task<IEnumerable<EquipmentSupply.API.Models.Reports.EquipmentReportModel>> GetAsync(long providerId)
        {
            var now = DateTimeOffset.Now;
            return await this.viewContext.Supplies.Where(x => x.ProviderId == providerId && x.IsDelete == false && x.ProvideDate.Year==now.Year && x.ProvideDate.Month==now.Month)
               .GroupBy(x => x.EquipmentType)
                .Select(x => new Models.Reports.EquipmentReportModel()
                {
                    EquipmentType = new Models.ViewModels.EquipmentTypeModel(x.Key),
                    Count = x.Sum(z => z.Count)
                })
                .OrderByDescending(x=>x.Count)
                .ToListAsync();
        }
    }
}
