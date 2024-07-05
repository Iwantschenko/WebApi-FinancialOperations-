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
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationsType>
    {
        public void Configure(EntityTypeBuilder<OperationsType> builder)
        {
            builder.HasKey(o => o.ID);
            builder
                .HasMany(o => o.transactions)
                .WithOne(t => t.OperationType);
        }
    }
}
