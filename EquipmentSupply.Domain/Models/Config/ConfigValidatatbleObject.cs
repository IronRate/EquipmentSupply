using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.Domain.Models.Config
{
    public abstract class ConfigValidatatbleObject
    {
        public bool TryValidate()
        {
            try
            {
                this.Validate();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public abstract void Validate();
    }
}
