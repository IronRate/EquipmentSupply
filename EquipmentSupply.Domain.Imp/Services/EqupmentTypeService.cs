using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class EqupmentTypeService : Domain.Contracts.Services.IEquipmentTypeService
    {
        public Task<bool> CanRemove(EquipmentType equipmentType)
        {
            throw new NotImplementedException();
        }

        public Task<long> CreateAsync(EquipmentType provider)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EquipmentType>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentType> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(EquipmentType equipmentType)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(EquipmentType equipmentType, bool force = false)
        {
            throw new NotImplementedException();
        }
    }
}
