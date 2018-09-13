using EquipmentSupply.Domain.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentSupply.DAL.Mappings
{
    public class NotoficationQueueMapping : IEntityTypeConfiguration<Domain.Models.DB.NotificationQueue>
    {
        public void Configure(EntityTypeBuilder<NotificationQueue> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Supply);
        }
    }
}
