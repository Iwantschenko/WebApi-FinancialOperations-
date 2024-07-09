﻿using DAL.DB.Configuration;
using Microsoft.EntityFrameworkCore;
using Models.Entities;


namespace DAL.DB
{
    public class DataBaseContext : DbContext
    {
        public DbSet<OperationTypeEntity> operationTypes {  get; set; }
        public DbSet<TransactionsEntity> transactions { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options ):base(options) 
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OperationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
