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
        private readonly Contracts.Repositories.IConfigRepository configRepository;

        public NotificationWorkerService(
            Domain.Contracts.Repositories.DB.ISuppliesUnitOfWork unitOfWork,
            Domain.Contracts.Services.INotificationSender notificationSender,
            Domain.Contracts.Repositories.IConfigRepository configRepository
            )
        {
            this.unitOfWork = unitOfWork;
            this.notificationSender = notificationSender;
            this.configRepository = configRepository;
        }
        public async Task DoWorkAsync()
        {
            var config = configRepository.Get();
            var notifications=await unitOfWork.NotificationQueues.GetReadyForSendingAsync(config.Interval);
            if (notifications != null) {
                var b=await this.notificationSender.SendAsync(notifications);
                if (b)
                {
                    foreach (var notification in notifications)
                    {
                        notification.SendDate = DateTimeOffset.Now;
                    }
                    await this.unitOfWork.CommitAsync();
                }
                else {
                    //Здесь обработка невозможно сти отправки
                }
            }
            
        }
    }
}
