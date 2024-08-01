using BLL.Mapping;
using BLL.Service;
using DAL.DB;
using DAL.Infastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Dto;
using Models.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace TestsApp
{
    public class OperationTypeControllerTests
    {
        private readonly Mock<IRepository<OperationTypeEntity>> _mockRepository;
        private readonly Mock<IMapping<OperationTypeEntity, OperationTypeDto>> _mockMapping;
        private readonly BaseService<OperationTypeEntity, OperationTypeDto> _service;
        private readonly OperationsController _operationsController;
        public OperationTypeControllerTests()
        {
            _mockRepository = new Mock<IRepository<OperationTypeEntity>>();
            _mockMapping = new Mock<IMapping<OperationTypeEntity, OperationTypeDto>>();
            _service = new BaseService<OperationTypeEntity, OperationTypeDto>(_mockRepository.Object, _mockMapping.Object);
            _operationsController = new OperationsController(_service);
        }
        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfItems()
        {

            var entities = new List<OperationTypeEntity>
            {
                new OperationTypeEntity { ID = Guid.NewGuid(), Name = "Test", IsIncome = true }
            };
            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(entities);

            var result = await _operationsController.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<OperationTypeEntity>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WhenModelIsValid()
        {
            // Arrange
            var operationDto = new OperationTypeDto { Name = "Valid Name", IsIncome = true };
            _operationsController.ModelState.Clear(); // Clear model state to simulate a valid model

            // Act
            var result = await _operationsController.Create(operationDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Successful add", okResult.Value);
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenModelIsInvalid()
        {

            var operationDto = new OperationTypeDto { Name = "T" };
            _operationsController.ModelState.AddModelError("Name", "MinLength 5");


            var result = await _operationsController.Create(operationDto);


            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetId_ReturnsOkResult_WithItem()
        {

            var id = Guid.NewGuid();
            var entity = new OperationTypeEntity { ID = id, Name = "Test", IsIncome = true };


            _mockRepository.Setup(repo => repo.GetByID(id)).ReturnsAsync(entity);


            // Act
            var result = await _operationsController.GetId(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<OperationTypeEntity>(okResult.Value);

        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WhenEntityExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var entity = new OperationTypeEntity { ID = id, Name = "Test", IsIncome = true };

            _mockRepository.Setup(repo => repo.GetByID(id)).ReturnsAsync(entity);

            // Act
            var result = await _operationsController.Delete(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Successful remove", okResult.Value);
        }

        [Fact]
        public void Update_ReturnsOkResult_WhenModelIsValid()
        {

            var id = Guid.NewGuid();
            var operationDto = new OperationTypeDto { Name = "Updated Name", IsIncome = false };
            var entity = new OperationTypeEntity { ID = id, Name = "Name", IsIncome = true };

            _operationsController.ModelState.Clear();
            _mockRepository.Setup(repo => repo.GetByID(id)).ReturnsAsync(entity);
            _mockMapping.Setup(mapping => mapping.ToEntity(operationDto, id)).Returns(entity);
            _mockRepository.Setup(repo => repo.Update(It.IsAny<OperationTypeEntity>()));


            var result = _operationsController.Update(id, operationDto);


            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public void Update_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var operationDto = new OperationTypeDto { Name = "T" }; // Invalid Name
            _operationsController.ModelState.AddModelError("Name", "MinLength 5");

            // Act
            var result = _operationsController.Update(id, operationDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
