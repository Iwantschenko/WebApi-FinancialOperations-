using DAL.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infastructure
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly DataBaseContext _dbcontext;
        public BaseRepository(DataBaseContext context) 
        {
            _dbcontext = context;
        }

        public async Task Add(Entity entity)
        {
            await _dbcontext.Set<Entity>().AddAsync(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<Entity> entities)
        {
            await _dbcontext.Set<Entity>().AddRangeAsync(entities);
            await _dbcontext.SaveChangesAsync();
        }

        public Task Delete(Guid ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Entity>> GetAll()
        {
            return await _dbcontext
                .Set<Entity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Entity> GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task RemoveEntity(Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
