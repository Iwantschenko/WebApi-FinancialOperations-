using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Models;
using Models.Entities;
namespace DAL.DB.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Models.Entities.TransactionsEntity>
    {
        public void Configure(EntityTypeBuilder<Models.Entities.TransactionsEntity> builder)
        {

            builder.HasKey(t => t.Transaction_Id);
            builder.Property(t => t.Transaction_Id).HasColumnName("Transaction_Id");
            builder.Property(t => t.Amount).HasColumnType("decimal(18, 2)");

            builder.HasOne(t => t.OperationType)
                   .WithMany(o => o.transactions)
                   .HasForeignKey(t => t.OperationTypeID);

            builder.ToTable("transactions");

            builder.HasData(
                new TransactionsEntity
                {
                    Transaction_Id = Guid.NewGuid(),
                    DateTime = new DateTime(2024, 7, 1),
                    Amount = 100.00m,
                    Description = "Income from sales",
                    OperationTypeID = InitialData.IncomeOperationTypeId
                },
                new TransactionsEntity
                {
                    Transaction_Id = Guid.NewGuid(),
                    DateTime = new DateTime(2024, 7, 1),
                    Amount = 50.00m,
                    Description = "Office supplies",
                    OperationTypeID = InitialData.ExpensesOperationTypeId
                },
                new TransactionsEntity
                {
                    Transaction_Id = Guid.NewGuid(),
                    DateTime = new DateTime(2024, 7, 2),
                    Amount = 200.00m,
                    Description = "Consulting services",
                    OperationTypeID = InitialData.IncomeOperationTypeId
                },
                new TransactionsEntity
                {
                    Transaction_Id = Guid.NewGuid(),
                    DateTime = new DateTime(2024, 7, 2),
                    Amount = 75.00m,
                    Description = "Utility bill",
                    OperationTypeID = InitialData.ExpensesOperationTypeId
                },
                new TransactionsEntity
                {
                    Transaction_Id = Guid.NewGuid(),
                    DateTime = new DateTime(2024, 7, 3),
                    Amount = 150.00m,
                    Description = "Freelance work",
                    OperationTypeID = InitialData.IncomeOperationTypeId
                },
                new TransactionsEntity
                {
                    Transaction_Id = Guid.NewGuid(),
                    DateTime = new DateTime(2024, 7, 3),
                    Amount = 100.00m,
                    Description = "Travel expenses",
                    OperationTypeID = InitialData.ExpensesOperationTypeId
                },
                new TransactionsEntity
                {
                    Transaction_Id = Guid.NewGuid(),
                    DateTime = new DateTime(2024, 7, 4),
                    Amount = 300.00m,
                    Description = "Income from investments",
                    OperationTypeID = InitialData.IncomeOperationTypeId
                },
                new TransactionsEntity
                {
                    Transaction_Id = Guid.NewGuid(),
                    DateTime = new DateTime(2024, 7, 5),
                    Amount = 125.00m,
                    Description = "Marketing expenses",
                    OperationTypeID = InitialData.ExpensesOperationTypeId
                }
            );
        }
    }
}
