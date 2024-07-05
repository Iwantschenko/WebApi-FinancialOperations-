using DAL.DB;
using Microsoft.EntityFrameworkCore.Storage;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Infastructure
{
    public class TransactionsRepository : IRepository<Transactions>
    {
        private readonly DataBaseContext _dbContext;
        public TransactionsRepository(DataBaseContext context) 
        {
            _dbContext = context;
        }

        public void Add(Transactions entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Transactions entity)
        {
            throw new NotImplementedException();
        }

        public List<Transactions> GetAll()
        {
            throw new NotImplementedException();
        }

        public Transactions GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public void Update(Transactions entity)
        {
            throw new NotImplementedException();
        }
    }
}
