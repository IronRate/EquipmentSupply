﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class ProviderService : Domain.Contracts.Services.IProviderService
    {
        private readonly Contracts.Repositories.DB.ISuppliesbUnitOfWork unitOfWork;

        #region Constructor

        public ProviderService(Domain.Contracts.Repositories.DB.ISuppliesbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        public Task<bool> CanRemove(Provider provider)
        {
            return unitOfWork.Supplies.HasSuppliesForProvider(provider);
        }

        public async Task<long> CreateAsync(Provider provider)
        {
            unitOfWork.Providers.Add(provider);
            await unitOfWork.CommitAsync();
            return provider.Id;
        }

        public Task<IEnumerable<Provider>> GetAsync()
        {
            return unitOfWork.Providers.GetAllAsync();
        }

        public Task<Provider> GetAsync(long id)
        {
            return unitOfWork.Providers.GetAsync(id);
        }

        public async Task ModifyAsync(Provider provider)
        {
            unitOfWork.Providers.Modify(provider);
            await unitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(Provider provider, bool force = false)
        {
            if (force == false)
            {
                var hasSupplies = await unitOfWork.Supplies.HasSuppliesForProvider(provider);
                if (hasSupplies)
                {
                    throw new InvalidOperationException("Невозможно удалить поставщика, так как имеются поставки");
                }
                else
                {
                    unitOfWork.Providers.Remove(provider);
                }
            }
            else {
                unitOfWork.Supplies.RemoveRange(provider.Supplies);
                unitOfWork.Providers.Remove(provider);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
