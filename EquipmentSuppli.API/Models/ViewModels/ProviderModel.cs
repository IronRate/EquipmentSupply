using System;
using System.Collections.Generic;
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
        }

        #endregion

        #region Properies

        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        #endregion

    }
}
