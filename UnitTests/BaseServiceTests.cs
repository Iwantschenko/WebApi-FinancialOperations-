using BLL.Mapping;
using BLL.Service;
using DAL.Infastructure;
using Models.Dto;
using Models.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsApp
{
    public class BaseServiceTests
    {
        private readonly Mock<IRepository<OperationTypeEntity>> _mockRepository;
        private readonly Mock<IMapping<OperationTypeEntity, OperationTypeDto>> _mockMapping;
        private readonly BaseService<OperationTypeEntity, OperationTypeDto> _service;

        public BaseServiceTests()
        {
            _mockRepository = new Mock<IRepository<OperationTypeEntity>>();
            _mockMapping = new Mock<IMapping<OperationTypeEntity, OperationTypeDto>>();
            _service = new BaseService<OperationTypeEntity, OperationTypeDto>(_mockRepository.Object, _mockMapping.Object);
        }

        [Fact]
        public async Task Add_Should_Call_Repository_Add()
        {
            // Arrange
            var dto = new OperationTypeDto { Name = "Test Operation", IsIncome = true };
            var entity = new OperationTypeEntity { ID = Guid.NewGuid(), Name = "Test Operation", IsIncome = true };

            _mockMapping.Setup(m => m.ToEntity(dto)).Returns(entity);

            // Act
            await _service.Add(dto);

            // Assert
            _mockRepository.Verify(r => r.Add(It.IsAny<OperationTypeEntity>()), Times.Once);
        }


        [Fact]
        public async Task Delete_Should_Call_Repository_Delete()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _service.Delete(id);

            // Assert
            _mockRepository.Verify(r => r.Delete(It.Is<Guid>(i => i == id)), Times.Once);
        }

        [Fact]
        public void RemoveEntity_Should_Call_Repository_RemoveEntity()
        {
            // Arrange
            var entity = new OperationTypeEntity { ID = Guid.NewGuid(), Name = "Test Operation", IsIncome = true };

            // Act
            _service.RemoveEntity(entity);

            // Assert
            _mockRepository.Verify(r => r.RemoveEntity(It.IsAny<OperationTypeEntity>()), Times.Once);
        }

        [Fact]
        public void Update_Should_Call_Repository_Update()
        {
            // Arrange
            var dto = new OperationTypeDto { Name = "Updated Operation", IsIncome = true };
            var entity = new OperationTypeEntity { ID = Guid.NewGuid(), Name = "Updated Operation", IsIncome = true };

            _mockMapping.Setup(m => m.ToEntity(dto, entity.ID)).Returns(entity);

            // Act
            _service.Update(dto, entity.ID);

            // Assert
            _mockRepository.Verify(r => r.Update(It.IsAny<OperationTypeEntity>()), Times.Once);
        }

        [Fact]
        public async Task GetByID_Should_Call_Repository_GetByID()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _service.GetByID(id);

            // Assert
            _mockRepository.Verify(r => r.GetByID(It.Is<Guid>(i => i == id)), Times.Once);
        }

        [Fact]
        public async Task GetAll_Should_Call_Repository_GetAll()
        {
            // Act
            await _service.GetAll();

            // Assert
            _mockRepository.Verify(r => r.GetAll(), Times.Once);
        }
    }
}
