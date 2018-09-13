using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class SendNotificationService : Domain.Contracts.Services.ISendNotificationService
    {
        private readonly Contracts.Repositories.DB.ISuppliesbUnitOfWork unitOfWork;

        public SendNotificationService(Domain.Contracts.Repositories.DB.ISuppliesbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task SendAsync()
        {
            var notifications=await unitOfWork.NotificationQueues.GetReadyForSendingAsync(20);
            
            
        }
    }
}
