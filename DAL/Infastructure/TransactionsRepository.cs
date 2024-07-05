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
    public class TransactionsRepository
    {
        private readonly DataBaseContext _dbContext;
        public TransactionsRepository(DataBaseContext context) 
        {
            _dbContext = context;
        }

       
    }
}
