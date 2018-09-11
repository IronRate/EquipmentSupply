using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.Domain.Imp.Services
{
    /// <summary>
    /// Сервис работы с поставками
    /// </summary>
    public class SuppliesService : Domain.Contracts.Services.ISupplyService
    {
        #region Fields

        private readonly Contracts.Repositories.DB.IDbUnitOfWork unitOfWork;

        #endregion

        #region Constructor

        public SuppliesService(Domain.Contracts.Repositories.DB.IDbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion


        #region Methods

        public async Task<long> CreateAsync(Supply supply)
        {
            if (supply == null)
            {
                throw new ArgumentNullException(nameof(supply));
            }
            this.unitOfWork.Supplies.Add(supply);

            var notification = new NotificationQueue(supply, Enums.OperationType.Create);
            this.unitOfWork.NotificationQueues.Add(notification);

            await this.unitOfWork.CommitAsync();

            return supply.Id;
        }

        public async Task ModifyAsync(Supply supply)
        {
            if (supply == null)
            {
                throw new ArgumentNullException(nameof(supply));
            }
            this.unitOfWork.Supplies.Modify(supply);
            this.unitOfWork.NotificationQueues.Add(new NotificationQueue(supply, Enums.OperationType.Modify));
            await this.unitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Supply supply)
        {
            if (supply == null)
            {
                throw new ArgumentNullException(nameof(supply));
            }
            //Делаем отметку об удалении
            supply.IsDelete = true;
            this.unitOfWork.Supplies.Modify(supply);
            this.unitOfWork.NotificationQueues.Add(new NotificationQueue(supply, Enums.OperationType.Delete));
            await this.unitOfWork.CommitAsync();
        }

        #endregion
    }
}
