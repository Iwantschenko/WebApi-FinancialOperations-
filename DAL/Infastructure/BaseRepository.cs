using DAL.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infastructure
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : class
    {
        protected readonly DataBaseContext _dbContext;
        public BaseRepository(DataBaseContext context)
        {
            _dbContext = context;
        }
        public async Task Add(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Entity> entities)
        {
            await _dbContext.Set<Entity>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid ID)
        {
            var item = await _dbContext.Set<Entity>().FindAsync(ID);
            if (item != null) 
            {
                _dbContext.Set<Entity>().Remove(item);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Entity>> GetAll()
        {
            return await _dbContext
                .Set<Entity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Entity> GetByID(Guid ID)
        {
            return  await _dbContext
               .Set<Entity>()
               .FindAsync(ID);
        }

        public async Task RemoveEntity(Entity entity)
        {
             _dbContext.Set<Entity>().Remove(entity);
            await _dbContext .SaveChangesAsync();
        }

        public async Task Update(Entity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        
    }
}
