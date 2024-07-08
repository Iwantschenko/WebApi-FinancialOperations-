using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB.Configuration
{
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder.HasKey(o => o.ID);
            builder
                .HasMany(o => o.transactions)
                .WithOne(t => t.OperationType); 

            builder.HasData(
                new OperationType { ID = Guid.NewGuid(), Name = "income", Description = "Income operations" },
                new OperationType { ID = Guid.NewGuid(), Name = "expenses", Description = "Expenses operations" }
            );
        }
    }
}
