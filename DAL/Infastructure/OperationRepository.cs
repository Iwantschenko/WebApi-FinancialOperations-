using DAL.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infastructure
{
    public class OperationRepository 
    {
        private readonly DataBaseContext _dbContext;
        public OperationRepository(DataBaseContext context)
        {
            _dbContext = context;
        }
        
        public async Task Add(OperationsType entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<OperationsType> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(OperationsType entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<OperationsType>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationsType> GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task Update(OperationsType entity)
        {
            throw new NotImplementedException();
        }
    }
    
}
