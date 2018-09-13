using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class NotificationWorkerService : Domain.Contracts.Services.INotificationWorkerService
    {
        private readonly Contracts.Repositories.DB.ISuppliesbUnitOfWork unitOfWork;
        private readonly Contracts.Repositories.IConfigRepository configRepository;

        public NotificationWorkerService(
            Domain.Contracts.Repositories.DB.ISuppliesbUnitOfWork unitOfWork,
            Domain.Contracts.Repositories.IConfigRepository configRepository
            )
        {
            this.unitOfWork = unitOfWork;
            this.configRepository = configRepository;
        }
        public async Task SendAsync()
        {
            var notifications=await unitOfWork.NotificationQueues.GetReadyForSendingAsync(20);
            if (notifications != null) {
                )
            }
            
        }
    }
}
