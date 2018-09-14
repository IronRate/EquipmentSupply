using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class NotificationWorkerService : Domain.Contracts.Services.INotificationWorkerService
    {
        private readonly Contracts.Repositories.DB.ISuppliesUnitOfWork unitOfWork;
        private readonly Contracts.Services.INotificationSender notificationSender;

        public NotificationWorkerService(
            Domain.Contracts.Repositories.DB.ISuppliesUnitOfWork unitOfWork,
            Domain.Contracts.Services.INotificationSender notificationSender
            )
        {
            this.unitOfWork = unitOfWork;
            this.notificationSender = notificationSender;
        }
        public async Task DoWorkAsync()
        {
            var notifications=await unitOfWork.NotificationQueues.GetReadyForSendingAsync(20);
            if (notifications != null) {
                await this.notificationSender.SendAsync(notifications);
            }
            
        }
    }
}
