using EquipmentSupply.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.DAL.Repositories
{
    public class NotificationQueueRepository:DbRepository<Domain.Models.DB.NotificationQueue,long>,Domain.Contracts.Repositories.DB.INotificationQueueRepository
    {
        public NotificationQueueRepository(DbSuppliesContext context):base(context)
        {

        }
    }
}
