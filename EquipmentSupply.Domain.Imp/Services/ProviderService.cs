using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class ProviderService : Domain.Contracts.Services.IProviderService
    {
        public Task<bool> CanRemove(Provider provider)
        {
            throw new NotImplementedException();
        }

        public Task<long> CreateAsync(Provider provider)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Provider>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Provider> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(Provider provider)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Provider provider, bool force = false)
        {
            throw new NotImplementedException();
        }
    }
}
