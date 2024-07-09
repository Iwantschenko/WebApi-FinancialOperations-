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
namespace DAL.DB.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Models.Entities.TransactionsEntity>
    {
        public void Configure(EntityTypeBuilder<Models.Entities.TransactionsEntity> builder)
        {
            builder.
                HasKey(t => t.Transaction_Id);
            builder.
                HasOne(t => t.OperationType).
                WithMany(o => o.transactions).
                HasForeignKey(t => t.OperationTypeID);
        }
    }
}
