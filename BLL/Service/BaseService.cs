
using DAL.Infastructure;
using BLL.Mapping;

namespace BLL.Service
{
    public class BaseService<Entity , Dto> 
        where Entity : class
        where Dto : class
    {
        private readonly IRepository<Entity> _operationRepository;
        private readonly IMapping<Entity, Dto> _mapping;
        public BaseService(IRepository<Entity> repository , IMapping<Entity,Dto> mapping)
        {
            _operationRepository = repository;
            _mapping = mapping;
        }
        public async Task Add(Dto dto) 
        {
            await _operationRepository.Add(_mapping.ToEntity(dto));
        } 
        public async Task AddRange(IEnumerable<Dto> list)
        {
            await _operationRepository.AddRange(_mapping.ToListEntity(list.ToList()));
        }
        public async Task Delete(Guid Id) => await _operationRepository.Delete(Id);
        public void RemoveEntity(Entity entity)
        {
            _operationRepository.RemoveEntity(entity);
        }
        public void Update(Dto dto , Guid Id) 
        {
            _operationRepository.Update(_mapping.ToEntity(dto , Id));
        }
        public async Task<Entity> GetByID(Guid Id) => await _operationRepository.GetByID(Id);
        public async Task<List<Entity>> GetAll() => await _operationRepository.GetAll();
    }
}
