using EquipmentSupply.DAL.Contexts;
using EquipmentSupply.Domain.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.DAL.Repositories
{
    public class NotificationQueueRepository : DbRepository<Domain.Models.DB.NotificationQueue, long>, Domain.Contracts.Repositories.DB.INotificationQueueRepository
    {
        #region Constructor

        public NotificationQueueRepository(DbSuppliesContext context) : base(context)
        {

        }

        #endregion



        public async Task<IEnumerable<NotificationQueue>> GetReadyForSendingAsync(int limit)
        {
            return await context.NotificationQueues
                .Where(x => x.SendDate == null)
                .OrderBy(x => x.Id)
                .Take(limit)
                .ToListAsync();
        }
    }
}
