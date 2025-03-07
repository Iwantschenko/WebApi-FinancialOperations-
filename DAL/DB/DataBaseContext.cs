﻿using Azure.Identity;
using DAL.DB.Configuration;
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
            if (Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
            {
                Database.Migrate();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OperationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            base.OnModelCreating(modelBuilder);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder); 
        }
    }
}
