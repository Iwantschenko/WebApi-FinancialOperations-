using Models.Entities;
using Models.Dto;
using DAL.Infastructure;
using System.Runtime.CompilerServices;
using Microsoft.Identity.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Models.Models;

namespace BLL.Service
{
    public class ReportService
    {
        private readonly BaseService<TransactionsEntity, TransactionDto> _transactionService;
        private readonly BaseService<OperationTypeEntity, OperationTypeDto> _operationService;
        private readonly ReportRepository _reportRepository;

        public ReportService(ReportRepository reportRepository, BaseService<TransactionsEntity, TransactionDto> transaction, BaseService<OperationTypeEntity, OperationTypeDto> operation)
        {
            _reportRepository = reportRepository;
            _transactionService = transaction;
            _operationService = operation;
        }

        public async Task<TransactionReportDto?> GetByDateAsync(DateTime date)
        {
            var transactions = await _reportRepository.GetByDate(date);
            if (transactions != null && transactions.Count != 0)
            {
                return GetTransactionDboAsync(transactions);
            }
            return null;
        }

        public async Task<TransactionReportDto?> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            var transactions = await _reportRepository.GetRangeDate(start, end);
            if (transactions != null && transactions.Count != 0)
            {
                return  GetTransactionDboAsync(transactions);
            }
            return null;
        }

        private TransactionReportDto GetTransactionDboAsync(List<TransactionsEntity> transactions)
        {
            var amount = TotalIncomeAndExpenseAsync(transactions);
            return new TransactionReportDto()
            {
                Income = amount.totalIncome ,
                Expenses = amount.totalExpance,
                Transactions = transactions
            };
        }

        private TotalAmount TotalIncomeAndExpenseAsync(List<TransactionsEntity> transactions)
        {
            TotalAmount amount = new TotalAmount();
            foreach (var item in transactions)
            {
                if (item.OperationType.IsIncome)
                {
                    amount.totalIncome += item.Amount;
                }
                else
                {
                    amount.totalExpance += item.Amount;
                }
            }
            return amount;
        }
    }
    
}
