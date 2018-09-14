using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class EqupmentTypeService : Domain.Contracts.Services.IEquipmentTypeService
    {
        private readonly Contracts.Repositories.DB.ISuppliesbUnitOfWork unitOfWork;

        public EqupmentTypeService(Domain.Contracts.Repositories.DB.ISuppliesbUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> CanRemove(EquipmentType equipmentType)
        {
            return this.unitOfWork.Supplies.HasForEquipmentType(equipmentType);
        }

        public async Task<long> CreateAsync(EquipmentType equipmentType)
        {
            this.unitOfWork.EqupmentTypes.Add(equipmentType);
            await this.unitOfWork.CommitAsync();
            return equipmentType.Id;
        }

        public Task<IEnumerable<EquipmentType>> GetAsync()
        {
            return this.unitOfWork.EqupmentTypes.GetAllAsync();
        }

        public Task<EquipmentType> GetAsync(long id)
        {
            return this.unitOfWork.EqupmentTypes.GetAsync(id);
        }

        public async Task ModifyAsync(EquipmentType equipmentType)
        {
            this.unitOfWork.EqupmentTypes.Modify(equipmentType);
            await this.unitOfWork.CommitAsync();
        }

        public async Task RemoveAsync(EquipmentType equipmentType, bool force = false)
        {
            if (force == false)
            {
                var hasSupplies = await unitOfWork.Supplies.HasForEquipmentType(equipmentType);
                if (hasSupplies)
                {
                    throw new InvalidOperationException("Невозможно удалить вид оборудования, так как имеются поставки");
                }
                else
                {
                    unitOfWork.EqupmentTypes.Remove(equipmentType);
                }
            }
            else
            {
                unitOfWork.Supplies.RemoveRange(equipmentType.Supplies);
                unitOfWork.EqupmentTypes.Remove(equipmentType);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
