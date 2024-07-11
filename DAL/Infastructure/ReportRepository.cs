using DAL.DB;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DAL.Infastructure
{
    public class ReportRepository 
    {
        private readonly DataBaseContext _dbContext;
        public ReportRepository(DataBaseContext dbContext ) 
        {
            _dbContext = dbContext;
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
