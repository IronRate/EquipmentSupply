using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Models.ViewModels
{
    public class EquipmentTypeModel
    {
        public EquipmentTypeModel()
        {

        }

        public EquipmentTypeModel(Domain.Models.DB.EquipmentType equipmentType)
        {
            this.Id = equipmentType.Id;
            this.Name = equipmentType.Name;
        }

        #region Properites

        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        #endregion
    }
}
