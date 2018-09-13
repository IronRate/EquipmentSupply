using EquipmentSupply.Domain.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.DAL.Mappings
{
    public class SupplyMapping : IEntityTypeConfiguration<Domain.Models.DB.Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.EquipmentType);
            builder.OwnsOne(x => x.Provider);
            builder.HasMany(x => x.Notifications).WithOne(x=>x.Supply);
            builder.Ignore(x => x.ProviderName);
            builder.Ignore(x => x.EquipmentTypeName);
        }
    }
}
