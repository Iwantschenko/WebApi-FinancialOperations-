using DAL.DB;
using Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infastructure
{
    public  class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataBaseContext _dbContext;
        public BaseRepository(DataBaseContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid ID)
        {
            var item = await _dbContext.Set<TEntity>().FindAsync(ID);
            if (item != null) 
            {
                _dbContext.Set<TEntity>().Remove(item);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            //return await _dbContext
            //    .Set<TEntity>()
            //    .AsNoTracking()
            //    .ToListAsync();
            var query = _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();

            if (typeof(TEntity) == typeof(TransactionsEntity))
            {
                query = query.Include("OperationType");
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByID(Guid ID)
        {
            return  await _dbContext
               .Set<TEntity>()
               .FindAsync(ID);
        }

        public void RemoveEntity(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        
    }
}
