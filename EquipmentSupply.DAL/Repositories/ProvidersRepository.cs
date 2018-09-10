using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.DAL.Repositories
{
    public class ProvidersRepository:DbRepository<Domain.Models.DB.Provider,long>,Domain.Contracts.Repositories.DB.IProvidersRepository
    {
        public ProvidersRepository(Contexts.DbSuppliesContext context):base(context)
        {

        }
    }
}
