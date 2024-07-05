using DAL.DB;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infastructure
{
    public class OperationRepository : IRepository<OperationsType>
    {
        private readonly DataBaseContext _dbContext;
        public OperationRepository(DataBaseContext context)
        {
            _dbContext = context;
        } 

        public void Add(OperationsType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OperationsType entity)
        {
            throw new NotImplementedException();
        }

        public List<OperationsType> GetAll()
        {
            throw new NotImplementedException();
        }

        public   Task<OperationsType> GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public void Update(OperationsType entity)
        {
            throw new NotImplementedException();
        }

        OperationsType IRepository<OperationsType>.GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }
    }
    
}
