#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentSupply.API.Controllers;
using EquipmentSupply.API.Models.ViewModels;
using EquipmentSupply.Domain.Contracts.Services;
using EquipmentSupply.Domain.Models.DB;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

#endregion

namespace EquipmentSupply.API.UnitTests.Controllers
{
    public class SuppliesControllerTests
    {
        [Fact]
        public async Task Post_BadParams_ReturnBadRequest()
        {
            //Arrange
            ISupplyService supplyServiceStub =
                Substitute.For<ISupplyService>();


            //Act
            IActionResult badRequestObjectResult = await new SuppliesController(supplyServiceStub).Post(null);


            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequestObjectResult);
        }
        
        [Fact]
        public async Task Put_BadParams_ReturnBadRequest()
        {
            //Arrange
            ISupplyService supplyServiceStub =
                Substitute.For<ISupplyService>();


            //Act
            IActionResult badRequestObjectResult = await new SuppliesController(supplyServiceStub).Put(0,null);


            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequestObjectResult);
        }
        
        [Fact]
        public async Task Post_BadParamsInvalid_BadRequest()
        {
            //Arrange
            ISupplyService supplyServiceStub =
                Substitute.For<ISupplyService>();

            SupplyCreateModel supplyCreateModel = new SupplyCreateModel()
            {
                Provider = null,
                ProvideDate =  DateTimeOffset.Now
            };
            
            SuppliesController suppliesController = new SuppliesController(supplyServiceStub);
            suppliesController.ModelState.AddModelError("Name", "Required");

            
            //Act
            IActionResult badRequestObjectResult = await suppliesController.Post(supplyCreateModel);


            //Assert
            Assert.IsType<BadRequestObjectResult>(badRequestObjectResult);
        }
        
        [Fact]
        public async Task Post_GoodParams_ReturnOk()
        {
            //Arrange
            ISupplyService supplyServiceStub =
                Substitute.For<ISupplyService>();

            SupplyCreateModel supplyCreateModel = new SupplyCreateModel()
            {
                Provider = new ProviderModel(new Provider()),
                Supplies = new List<SupplyCreateModel.SupplyCreateRowModel>(),
                ProvideDate =  DateTimeOffset.Now
            };

            //Act
            IActionResult okResult = await new SuppliesController(supplyServiceStub).Post(supplyCreateModel);


            //Assert
            Assert.IsType<OkResult>(okResult);
        }
        
        [Fact]
        public async Task Delete_GoodParams_ReturnOk()
        {
            //Arrange
            ISupplyService supplyServiceStub =
                Substitute.For<ISupplyService>();

            supplyServiceStub.GetAsync(Arg.Any<long>()).Returns(x => new Supply(1, 1, DateTimeOffset.Now, 10));
            supplyServiceStub.RemoveAsync(Arg.Any<Supply>()).Returns(Task.FromResult(true));

            //Act
            IActionResult okResult = await new SuppliesController(supplyServiceStub).Delete(1);


            //Assert
            Assert.IsType<OkResult>(okResult);
        }
        
        [Fact]
        public async Task Delete_GoodParams_ReturnNotFound()
        {
            //Arrange
            ISupplyService supplyServiceStub =
                Substitute.For<ISupplyService>();

            supplyServiceStub.GetAsync(Arg.Any<long>()).Returns(x => (Supply)null);
            supplyServiceStub.RemoveAsync(Arg.Any<Supply>()).Returns(Task.FromResult(true));

            //Act
            IActionResult notFoundObjectResult = await new SuppliesController(supplyServiceStub).Delete(1);


            //Assert
            Assert.IsType<NotFoundObjectResult>(notFoundObjectResult);
        }

        [Fact]
        public async Task Get_GoodParams_ReturnOk()
        {
            //Arrange
            ISupplyService supplyServiceStub =
                Substitute.For<ISupplyService>();

            supplyServiceStub.GetAsync(Arg.Any<long>()).Returns(x => new Supply(1, 1, DateTimeOffset.Now, 10));

            

            //Act
            IActionResult okResult = await new SuppliesController(supplyServiceStub).Get(1);


            //Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}