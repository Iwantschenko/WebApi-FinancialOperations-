using Models.Entities;
namespace Models.Dto
{
    public class TransactionReportDto 
    {
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public List<TransactionsEntity> Transactions { get; set; }
    }
}
