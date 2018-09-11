using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class SuppliesService : Domain.Contracts.Services.ISupplyService
    {
        private readonly Contracts.Repositories.DB.IDbUnitOfWork unitOfWork;



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
        }

        public async Task RemoveAsync(Supply supply)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
