using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EquipmentSupply.Domain.Models.DB;

namespace EquipmentSupply.Domain.Imp.Services
{
    public class EquipmentTypeService : Domain.Contracts.Services.IEquipmentTypeService
    {
        private readonly Contracts.Repositories.DB.ISuppliesUnitOfWork unitOfWork;

        public EquipmentTypeService(Domain.Contracts.Repositories.DB.ISuppliesUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> CanRemove(EquipmentType equipmentType)
        {
            return this.unitOfWork.Supplies.HasForEquipmentType(equipmentType);
        }

        public async Task<long> CreateAsync(EquipmentType equipmentType)
        {
            //Защита от дурака - вид оборудования в единственном экземпляре - сделаем это кодом, хотя можно сделать и на уровне SQL
            if (await this.HasWithNameAsync(equipmentType.Name) == true)
            {
                throw new InvalidOperationException($"Вид оборудования с именем {equipmentType.Name} уже существует в хранилище");
            }

            this.unitOfWork.EqupmentTypes.Add(equipmentType);
            await this.unitOfWork.CommitAsync();
            return equipmentType.Id;
        }

        public Task<IEnumerable<EquipmentType>> FindAsync(string name)
        {
            return this.unitOfWork.EqupmentTypes.FindAsync(x => x.Name.Contains(name));
        }

        public Task<IEnumerable<EquipmentType>> GetAsync()
        {
            return this.unitOfWork.EqupmentTypes.GetAllAsync();
        }

        public Task<EquipmentType> GetAsync(long id)
        {
            return this.unitOfWork.EqupmentTypes.GetAsync(id);
        }

        public async Task<bool> HasWithNameAsync(string name)
        {
            return await this.unitOfWork.EqupmentTypes.AnyAsync(x => x.Name == name);
        }

        public async Task<bool> HasWithNameAsync(EquipmentType equipmentType)
        {
            return await this.unitOfWork.EqupmentTypes.AnyAsync(x => x.Name == equipmentType.Name && x.Id != equipmentType.Id);
        }

        public async Task ModifyAsync(EquipmentType equipmentType)
        {
            //Защита от дурака при редактировании - проверка на существование вида оборудования по имени
            if (await this.HasWithNameAsync(equipmentType) == true)
            {
                throw new InvalidOperationException($"Вид оборудования с именем {equipmentType.Name} уже существует в хранилище");
            }

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
                    await unitOfWork.CommitAsync();
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
