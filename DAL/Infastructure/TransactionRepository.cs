using DAL.DB;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Infastructure
{
    public class TransactionRepository :  BaseRepository<Transactions>
    {
        public TransactionRepository(DataBaseContext dbContext ) : base(dbContext) 
        {
            
        }
        public async Task<List<Transactions>> GetByDate(DateTime findDate)
        {
            return await _dbContext.transactions
                .AsNoTracking()
                .Where(tr => tr.DateTime.Date  == findDate.Date)
                .ToListAsync() ;
        }
        public async Task<List<Transactions>> GetRangeDate(DateTime startDate , DateTime endDate)
        {
            return await _dbContext.transactions
                .AsNoTracking() 
                .Where(t => t.DateTime.Date >= startDate.Date && t.DateTime.Date <= endDate.Date)
                .ToListAsync();
        }
    }
}
