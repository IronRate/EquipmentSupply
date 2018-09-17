#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentSupply.DAL.UnitOfWorks;
using EquipmentSupply.Domain.Contracts.Repositories.DB;
using EquipmentSupply.Domain.Imp.Services;
using EquipmentSupply.Domain.Models;
using EquipmentSupply.Domain.Models.DB;
using NSubstitute;
using Xunit;

#endregion

namespace EquipmentSupply.Domain.Imp.UnitTests.Services
{
    public class SuppliesServiceTests
    {
        [Fact]
        public async Task CreateAsync_BadParams_AlwaysException()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();


            //Act
            SuppliesService suppliesService = new SuppliesService(suppliesUnitOfWorkStub);

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => suppliesService.CreateAsync(null));
        }

        [Fact]
        public async Task CreateAsync_GoodParams_ReturnSupplyId()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            Supply supply = new Supply
            {
                Id = 1,
                Count = 1,
                ProvideDate = DateTimeOffset.Now,
                Provider = new Provider() { Name = "Лютик" },
                EquipmentType = new EquipmentType("Молоток"),
                ProviderId = 1,
                EquipmentTypeId = 1
            };


            //Act
            long supplyId = await new SuppliesService(suppliesUnitOfWorkStub)
                .CreateAsync(supply);

            //Assert
            Assert.True(supply.Id == supplyId);
        }

        [Fact]
        public async Task CreateRangeAsync_BadParams_AlwaysException()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();


            //Act
            SuppliesService suppliesService = new SuppliesService(suppliesUnitOfWorkStub);

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => suppliesService.CreateAsync(null));
        }

        [Fact]
        public async Task GetAllAsync_GoodParams_ReturnEmpty()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            suppliesUnitOfWorkStub.Supplies.GetAllExtendedAsync(Arg.Any<bool>(), Arg.Any<DatePeriod>())
                .Returns(info => new List<Supply>());


            //Act
            IEnumerable<Supply> supplies = await new SuppliesService(suppliesUnitOfWorkStub)
                .GetAllAsync(true, new DatePeriod(DateTimeOffset.Now));

            //Assert
            Assert.Empty(supplies);
        }

        [Fact]
        public async Task GetAllAsync_GoodParams_ReturnOnlyOnes()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            suppliesUnitOfWorkStub.Supplies.GetAllExtendedAsync(Arg.Any<bool>(), Arg.Any<DatePeriod>())
                .Returns(info => new List<Supply> { new Supply(1,1,DateTimeOffset.Now,10) {
                    Id = 1,Provider=new Provider(){Name="Лютик" },
                    EquipmentType=new EquipmentType("Молоток")
                } });


            //Act
            IEnumerable<Supply> supplies = await new SuppliesService(suppliesUnitOfWorkStub)
                .GetAllAsync(true, null);

            //Assert
            Assert.Single(supplies);
        }

        [Fact]
        public async Task GetAsync_GoodParams_ReturnEmpty()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            suppliesUnitOfWorkStub.Supplies.GetExtendedAsync(Arg.Any<long>())
                .Returns(info => (Supply)null);


            //Act
            Supply supply = await new SuppliesService(suppliesUnitOfWorkStub)
                .GetAsync(5);

            //Assert
            Assert.Null(supply);
        }

        [Fact]
        public async Task GetAsync_GoodParams_ReturnNotNull()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            suppliesUnitOfWorkStub.Supplies.GetExtendedAsync(Arg.Any<long>())
                .Returns(info => new Supply { Id = 5, EquipmentTypeName = "Наименование" });


            //Act
            Supply supply = await new SuppliesService(suppliesUnitOfWorkStub)
                .GetAsync(5);

            //Assert
            Assert.NotNull(supply);
        }

        [Fact]
        public async Task GetAsync_GoodParams_ReturnOnlyOnes()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            suppliesUnitOfWorkStub.Supplies.GetExtendedAsync(Arg.Any<long>())
                .Returns(info => new Supply { Id = 5, EquipmentTypeName = "Наименование" });


            //Act
            Supply supply = await new SuppliesService(suppliesUnitOfWorkStub)
                .GetAsync(5);

            //Assert
            Assert.Equal("Наименование", supply.EquipmentTypeName);
        }

        [Fact]
        public async Task ModifyAsync_BadParams_AlwaysException()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();


            //Act
            SuppliesService suppliesService = new SuppliesService(suppliesUnitOfWorkStub);

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => suppliesService.ModifyAsync(null));
        }

        [Fact]
        public async Task ModifyAsync_GoodParams_ReturnOk()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<SuppliesUnitOfWork>();

            Supply supply = new Supply(1, 1, DateTimeOffset.Now, 10)
            {
                Id = 1,
                IsDelete = false,
                Provider=new Provider() {Name="Лютик" },
                EquipmentType = new EquipmentType("Молоток")
            };

            //Act
            SuppliesService suppliesService = new SuppliesService(suppliesUnitOfWorkStub);

            //Assert
            Exception ex = await Record.ExceptionAsync(() => suppliesService.ModifyAsync(supply));

            Assert.Null(ex);
        }

        [Fact]
        public async Task ModifyAsync_GoodParamsButHasDeleted_AlwaysException()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            Supply supply = new Supply { Id = 5, EquipmentTypeName = "Наименование", IsDelete = true };

            //Act
            SuppliesService suppliesService = new SuppliesService(suppliesUnitOfWorkStub);

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => suppliesService.ModifyAsync(supply));
        }

        [Fact]
        public async Task ModifyAsync_GoodParamsButHasDeleted_AlwaysExceptionWithMessage()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            Supply supply = new Supply { Id = 5, EquipmentTypeName = "Наименование", IsDelete = true };

            //Act
            SuppliesService suppliesService = new SuppliesService(suppliesUnitOfWorkStub);

            //Assert
            InvalidOperationException ex =
                await Assert.ThrowsAsync<InvalidOperationException>(() => suppliesService.ModifyAsync(supply));

            Assert.Contains("Операция редактирования отменена. Запрещено модифицировать удаленную поставку",
                ex.Message);
        }

        //RemoveAsync

        [Fact]
        public async Task RemoveAsync_BadParams_AlwaysException()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();


            //Act
            SuppliesService suppliesService = new SuppliesService(suppliesUnitOfWorkStub);

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => suppliesService.RemoveAsync(null));
        }

        [Fact]
        public async Task RemoveAsync_GoodParams_ReturnOk()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            Supply supply = new Supply { Id = 5, EquipmentTypeName = "Наименование" };

            //Act
            SuppliesService suppliesService = new SuppliesService(suppliesUnitOfWorkStub);

            //Assert
            Exception ex = await Record.ExceptionAsync(() => suppliesService.RemoveAsync(supply));

            Assert.Null(ex);
            Assert.True(supply.IsDelete);
        }

        [Fact]
        public async Task RemoveAsync_GoodParams_ReturnOkAndSupplyIsDeleted()
        {
            //Arrange
            ISuppliesUnitOfWork suppliesUnitOfWorkStub = Substitute.For<ISuppliesUnitOfWork>();

            Supply supply = new Supply { Id = 5, EquipmentTypeName = "Наименование" };

            //Act
            await new SuppliesService(suppliesUnitOfWorkStub).RemoveAsync(supply);

            //Assert
            Assert.True(supply.IsDelete);
        }
    }
}