using Models.Entities;
using Models.Dto;
using DAL.Infastructure;
using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.Service
{
    public  class ReportService 
    {
        private readonly BaseService<TransactionsEntity , TransactionDto> _transactionService;
        private readonly BaseService<OperationTypeEntity , OperationTypeDto> _operationService;
        private readonly ReportRepository _reportRepository;
       
        public ReportService(ReportRepository reportRepository , BaseService<TransactionsEntity,TransactionDto> transaction , BaseService<OperationTypeEntity ,OperationTypeDto> opeartion)
        {
            _reportRepository = reportRepository;
            _transactionService = transaction;
            _operationService = opeartion;

        }
        public TransactionReportDto GetByDate(DateTime date)
        {
            var transactions = _reportRepository.GetByDate(date).Result;
            if (transactions != null)
            {
                return GetTransactionDbo(transactions);
            }
            else 
                return GetNullTransactionDbo();
        }
        public TransactionReportDto GetbyDateRange(DateTime start , DateTime end)
        {
            var transactions = _reportRepository.GetRangeDate(start , end).Result;
            if (transactions != null)
            {
                return GetTransactionDbo(transactions);
            }
            else
                return GetNullTransactionDbo();
        }
        private TransactionReportDto GetTransactionDbo(List<TransactionsEntity> transactions) 
        {
                var totalValue = TotalIncomeAndExpense(transactions);
                return new TransactionReportDto()
                {
                    Income = totalValue[0] , 
                    Expenses = totalValue[1] ,
                    Transactions = transactions
                };
        }
        private TransactionReportDto GetNullTransactionDbo()
        {
            return new TransactionReportDto()
            {
                Income = 0,
                Expenses = 0,
                Transactions = new List<TransactionsEntity>()
            };
        }
        private  List<decimal> TotalIncomeAndExpense(List<TransactionsEntity> transactions )
        {
            decimal totalIncome = 0;
            decimal totalExpense = 0;
            foreach (var item in transactions)
            {
                if (_operationService.GetByID(item.OperationTypeID).Result.IsIncome)
                {
                    totalIncome += item.Amount;
                    
                }
                else
                {
                    totalExpense += item.Amount;
                }
                    
            }
            return new List<decimal>() 
            {
                totalIncome,
                totalExpense
            };
        }
    }
}
