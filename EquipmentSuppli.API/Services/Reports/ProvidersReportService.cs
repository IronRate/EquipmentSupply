using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Services.Reports
{
    public class ProvidersReportService
    {
        private readonly DAL.Contexts.DbSuppliesViewContext viewContext;

        public ProvidersReportService(DAL.Contexts.DbSuppliesViewContext viewContext)
        {
            this.viewContext = viewContext;
        }

        public async Task<IEnumerable<Models.Reports.ProviderReportModel>> GetAsync() {
            var now = DateTimeOffset.Now;
            //считаем количество едениц товара всего
            var maxCount=this.viewContext.Supplies.Where(x => x.IsDelete == false && x.ProvideDate.Year == now.Year).Sum(x => x.Count);

            var q = this.viewContext.Supplies.Where(x => x.IsDelete == false && x.ProvideDate.Year == now.Year)
                .GroupBy(x => x.Provider)
                .Select(x => new Models.Reports.ProviderReportModel()
                {
                    Provider = new Models.ViewModels.ProviderModel(x.Key),
                    Percentage = x.Sum(z => z.Count) * 100 / maxCount
                }).OrderByDescending(x=>x.Percentage);

            var result =await  q.ToListAsync();
            return result;
        }
    }
}
