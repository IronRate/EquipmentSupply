using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EquipmentSupply.API.Models.ViewModels
{
    public class ProviderModel
    {

        #region Constructor

        public ProviderModel()
        {

        }

        public ProviderModel(Domain.Models.DB.Provider provider)
        {
            this.Id = provider.Id;
            this.Email = provider.Email;
            this.Name = provider.Name;
            this.Address = provider.Address;
            this.Phone = provider.Phone;
        }

        #endregion

        #region Properies

        public long? Id { get; set; }

        [Required,MinLength(4)]
        public string Name { get; set; }

        [Required, RegularExpression(@"^.*@.*\..{2,}$")]
        public string Email { get; set; }

        [Required,MinLength(5)]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        #endregion

    }
}
