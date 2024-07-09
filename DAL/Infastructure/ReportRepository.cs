using DAL.DB;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Infastructure
{
    public class ReportRepository :  BaseRepository<TransactionsEntity>
    {
        public ReportRepository(DataBaseContext dbContext ) : base(dbContext) 
        {
            
        }
        public async Task<List<TransactionsEntity>> GetByDate(DateTime findDate)
        {
            return await _dbContext.transactions
                .AsNoTracking()
                .Where(tr => tr.DateTime.Date  == findDate.Date)
                .ToListAsync() ;
        }
        public async Task<List<TransactionsEntity>> GetRangeDate(DateTime startDate , DateTime endDate)
        {
            return await _dbContext.transactions
                .AsNoTracking() 
                .Where(t => t.DateTime.Date >= startDate.Date && t.DateTime.Date <= endDate.Date)
                .ToListAsync();
        }
    }
}
