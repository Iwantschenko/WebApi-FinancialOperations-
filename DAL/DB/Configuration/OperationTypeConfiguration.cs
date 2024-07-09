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
            builder
                .HasMany(o => o.transactions)
                .WithOne(t => t.OperationType); 

            builder.HasData(
                new OperationTypeEntity { ID = Guid.NewGuid(), Name = "income", IsIncome = true },
                new OperationTypeEntity { ID = Guid.NewGuid(), Name = "expenses", IsIncome = false }
            );
        }
    }
}
