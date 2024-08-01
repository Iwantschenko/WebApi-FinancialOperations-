using DAL.DB;
using DAL.Infastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.Entities;
using Moq;
using System.Diagnostics.Contracts;
using System.Transactions;

namespace TestsApp
{
    public class RepositoryTesting
    {
        private BaseRepository<OperationTypeEntity> _baseRepository { get; set; }
        public RepositoryTesting()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "TestsDataBase")
                .Options;

            _baseRepository = new BaseRepository<OperationTypeEntity>(new DataBaseContext(options));
        }
        [Fact]
        public async Task AddCorrectDataToDb()
        {
            // Arrange
            var operationType = new OperationTypeEntity
            {
                ID = Guid.NewGuid(),
                Name = "Test Operation",
                IsIncome = true
            };

            // Act
            await _baseRepository.Add(operationType);

            // Assert
            var result = await _baseRepository.GetByID(operationType.ID);

            Assert.NotNull(result);
            Assert.Equal(operationType.Name, result.Name);
            Assert.Equal(operationType.IsIncome, result.IsIncome);
        }


        [Fact]
        public async Task GetByID_NotFound()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act
            var result = await _baseRepository.GetByID(nonExistentId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetAll_ReturnsCorrectData()
        {
            // Arrange
            var operationTypes = new List<OperationTypeEntity>
            {
                new OperationTypeEntity { ID = Guid.NewGuid(), Name = "Operation 1", IsIncome = true },
                new OperationTypeEntity { ID = Guid.NewGuid(), Name = "Operation 2", IsIncome = false }
            };
            await _baseRepository.AddRange(operationTypes);

            // Act
            var result = await _baseRepository.GetAll();

            // Assert
            Assert.Contains(result, x => x.Name == "Operation 1");
            Assert.Contains(result, x => x.Name == "Operation 2");
        }

        [Fact]
        public async Task Update_Entity()
        {
            // Arrange
            var operationType = new OperationTypeEntity
            {
                ID = Guid.NewGuid(),
                Name = "Initial Name",
                IsIncome = true
            };
            await _baseRepository.Add(operationType);

            // Act
            operationType.Name = "Updated Name";
            _baseRepository.Update(operationType);

            // Assert
            var result = await _baseRepository.GetByID(operationType.ID);
            Assert.NotNull(result);
            Assert.Equal("Updated Name", result.Name);
        }

        [Fact]
        public async Task Delete_Entity()
        {
            // Arrange
            var operationType = new OperationTypeEntity
            {
                ID = Guid.NewGuid(),
                Name = "Test Operation",
                IsIncome = true
            };
            await _baseRepository.Add(operationType);

            // Act
            await _baseRepository.Delete(operationType.ID);

            // Assert
            var result = await _baseRepository.GetByID(operationType.ID);
            Assert.Null(result);
        }

        [Fact]
        public async Task RemoveEntity()
        {
            // Arrange
            var operationType = new OperationTypeEntity
            {
                ID = Guid.NewGuid(),
                Name = "Test Operation",
                IsIncome = true
            };
            await _baseRepository.Add(operationType);

            // Act
            _baseRepository.RemoveEntity(operationType);

            // Assert
            var result = await _baseRepository.GetByID(operationType.ID);
            Assert.Null(result);
        }
    }
}