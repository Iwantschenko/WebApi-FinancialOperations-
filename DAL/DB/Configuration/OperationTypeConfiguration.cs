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
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationTypeEntity>
    {
        public void Configure(EntityTypeBuilder<OperationTypeEntity> builder)
        {
            builder.HasKey(o => o.ID);
            builder.Property(o => o.ID).HasColumnName("ID");
            builder.Property(o => o.Name).IsRequired();
            builder.Property(o => o.IsIncome).IsRequired();

            builder
                .HasMany(o => o.transactions)
                .WithOne(t => t.OperationType);
            builder.ToTable("operationTypes");

            builder.HasData(
                new OperationTypeEntity { ID = InitialData.IncomeOperationTypeId, Name = "income", IsIncome = true },
                new OperationTypeEntity { ID = InitialData.ExpensesOperationTypeId, Name = "expenses", IsIncome = false }
            );


        }
    }
}
