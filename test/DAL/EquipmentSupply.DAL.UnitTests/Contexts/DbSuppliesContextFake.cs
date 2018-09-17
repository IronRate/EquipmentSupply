#region

using System;
using EquipmentSupply.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace EquipmentSupply.DAL.UnitTests.Contexts
{
    public sealed class DbSuppliesContextFake : DbSuppliesContext
    {
        public DbSuppliesContextFake() : base(CreateNewContextOptions())
        {
        }

        private static DbContextOptions<DbSuppliesContext> CreateNewContextOptions()
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            DbContextOptionsBuilder<DbSuppliesContext> builder = new DbContextOptionsBuilder<DbSuppliesContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}