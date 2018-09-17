#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentSupply.DAL.UnitOfWorks;
using EquipmentSupply.DAL.UnitTests.Contexts;
using EquipmentSupply.Domain.Models;
using EquipmentSupply.Domain.Models.DB;
using NSubstitute;
using Xunit;

#endregion

namespace EquipmentSupply.DAL.UnitTests.Repositories
{
    public class SuppliesRepositoryTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(2)]
        public async Task HasForEquipmentType_ExistsOneRowIntoTable_ReturnsFalse(long equipmentTypeId)
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10));

            await suppliesUnitOfWork.CommitAsync();


            //Act
            bool hasForProvider =
                await suppliesUnitOfWork.Supplies.HasForEquipmentType(new EquipmentType(equipmentTypeId, string.Empty));


            //Assert
            Assert.False(hasForProvider);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(2)]
        public async Task HasForProvider_ExistsOneRowIntoTable_ReturnsFalse(long providerId)
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10));

            await suppliesUnitOfWork.CommitAsync();


            //Act
            bool hasForProvider = await suppliesUnitOfWork.Supplies.HasForProvider(new Provider { Id = providerId });


            //Assert
            Assert.False(hasForProvider);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(2)]
        public async Task GetAsync_ExistsOneRowIntoTable_ReturnsNull(long id)
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10));

            await suppliesUnitOfWork.CommitAsync();


            //Act
            Supply supply = await suppliesUnitOfWork.Supplies.GetAsync(id);


            //Assert
            Assert.Null(supply);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(20)]
        public async Task GetExtendedAsync_ExistsOneRowIntoTable_ReturnsIsNullSupply(long id)
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10));
            suppliesUnitOfWork.Supplies.Add(new Supply(5, 5, DateTimeOffset.Now, 10));

            await suppliesUnitOfWork.CommitAsync();


            //Act
            Supply supply = await suppliesUnitOfWork.Supplies.GetExtendedAsync(id);


            //Assert
            Assert.Null(supply);
        }

        [Fact]
        public async Task GetAllExtendedAsync_ExistsOneRowIntoTable_ReturnsSupply()
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            //suppliesUnitOfWork.Providers.Add(new Provider() { Name = "ООО Лютик" });
            //suppliesUnitOfWork.EqupmentTypes.Add(new EquipmentType("Молоток"));
            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10)
            {
                IsDelete = true,
                Provider = new Provider() { Name = "ООО Лютик" },
                EquipmentType = new EquipmentType("Молоток")
            });

            await suppliesUnitOfWork.CommitAsync();


            //Act
            IEnumerable<Supply> supplies =
                await suppliesUnitOfWork.Supplies.GetAllExtendedAsync(true, new DatePeriod(null));


            //Assert
            Assert.True(supplies.Any());
        }

        [Fact]
        public async Task GetAsync_ExistsOneRowIntoTable_ReturnsSupply()
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10));

            await suppliesUnitOfWork.CommitAsync();


            //Act
            Supply supply = await suppliesUnitOfWork.Supplies.GetAsync(1);


            //Assert
            Assert.NotNull(supply);
        }

        [Fact]
        public async Task GetExtendedAsync_ExistsOneRowIntoTable_ReturnsNotNullSupply()
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10)
            {
                Provider = new Provider() { Name = "Лютик" }
                ,
                EquipmentType = new EquipmentType("Молоток")
            });
            suppliesUnitOfWork.Supplies.Add(new Supply(5, 5, DateTimeOffset.Now, 10)
            {
                Provider = new Provider() { Name = "Рога и Копыта" }
                ,
                EquipmentType = new EquipmentType("Ножницы")
            });

            await suppliesUnitOfWork.CommitAsync();


            //Act
            Supply supply = await suppliesUnitOfWork.Supplies.GetExtendedAsync(2);


            //Assert
            Assert.NotNull(supply);
        }

        [Fact]
        public async Task GetExtendedAsync_ExistsOneRowIntoTable_ReturnsSupply()
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10)
            {
                Provider = new Provider() { Name = "Лютик" },
                EquipmentType = new EquipmentType("Молоток")
            });

            await suppliesUnitOfWork.CommitAsync();


            //Act
            Supply supply = await suppliesUnitOfWork.Supplies.GetExtendedAsync(1);


            //Assert
            Assert.Equal(1, supply.ProviderId);
            Assert.Equal(1, supply.EquipmentTypeId);
            Assert.Equal(10, supply.Count);
        }

        [Fact]
        public async Task HasForEquipmentType_ExistsOneRowIntoTable_ReturnsTrue()
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10));

            await suppliesUnitOfWork.CommitAsync();


            //Act
            bool hasForProvider =
                await suppliesUnitOfWork.Supplies.HasForEquipmentType(new EquipmentType(1, string.Empty));


            //Assert
            Assert.True(hasForProvider);
        }

        [Fact]
        public async Task HasForProvider_ExistsOneRowIntoTable_ReturnsTrue()
        {
            //Arrange
            SuppliesUnitOfWork suppliesUnitOfWork =
                Substitute.ForPartsOf<SuppliesUnitOfWork>(new DbSuppliesContextFake());

            suppliesUnitOfWork.Supplies.Add(new Supply(1, 1, DateTimeOffset.Now, 10));

            await suppliesUnitOfWork.CommitAsync();


            //Act
            bool hasForProvider = await suppliesUnitOfWork.Supplies.HasForProvider(new Provider { Id = 1 });


            //Assert
            Assert.True(hasForProvider);
        }
    }
}