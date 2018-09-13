using EquipmentSupply.Domain.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.DAL.Mappings
{
    public class EquipmentTypeMapping : IEntityTypeConfiguration<Domain.Models.DB.EquipmentType>
    {
        public void Configure(EntityTypeBuilder<EquipmentType> builder)
        {
            builder.HasIndex(X => X.Id);
            builder.HasMany(x => x.Supplies).WithOne(x => x.EquipmentType);
        }
    }
}
