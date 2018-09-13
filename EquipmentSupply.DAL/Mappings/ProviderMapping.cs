using EquipmentSupply.Domain.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.DAL.Mappings
{
    public class ProviderMapping : IEntityTypeConfiguration<Domain.Models.DB.Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Supplies).WithOne(x => x.Provider);
        }
    }
}
