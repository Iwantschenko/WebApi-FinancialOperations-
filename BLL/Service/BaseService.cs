
using Models.Entities;
using DAL.Infastructure;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel;
using System.Diagnostics;
namespace BLL.Service
{
    public class BaseService<Entity> where Entity : class
    {
        private readonly IRepository<Entity> _operationRepository;

        public BaseService(IRepository<Entity> repository)
        {
            _operationRepository = repository;
        }
        public async Task Add(Entity entity) => await _operationRepository.Add(entity);
        public async Task AddRange(IEnumerable<Entity> list) => await _operationRepository.AddRange(list);
        public async Task Delete(Guid Id) => await _operationRepository.Delete(Id);
        public async Task RemoveEntity(Entity entity) => await _operationRepository.RemoveEntity(entity);
        public async Task Update(Entity entity) => await _operationRepository.Update(entity);
        public async Task<Entity> GetByID(Guid Id) => await _operationRepository.GetByID(Id);
        public async Task<List<Entity>> GetAll() => await _operationRepository.GetAll();
    }
}
