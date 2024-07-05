﻿// <auto-generated />
using System;
using DAL.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.Entities.Transactions", b =>
                {
                    b.Property<Guid>("Transaction_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OperationTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Transaction_Id");

                    b.HasIndex("OperationTypeID");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("Models.Entities.TransactionsType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Operation_ID");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Operation_Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Operation_Name");

                    b.HasKey("ID");

                    b.ToTable("operationTypes");

                    b.HasData(
                        new
                        {
                            ID = new Guid("39b06ec4-2253-491c-9a0c-ca9738cf9255"),
                            Description = "Income operations",
                            Name = "income"
                        },
                        new
                        {
                            ID = new Guid("4cd995c6-0f1a-4983-aa74-d666b81c7ac8"),
                            Description = "Expenses operations",
                            Name = "expenses"
                        });
                });

            modelBuilder.Entity("Models.Entities.Transactions", b =>
                {
                    b.HasOne("Models.Entities.TransactionsType", "OperationType")
                        .WithMany("transactions")
                        .HasForeignKey("OperationTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationType");
                });

            modelBuilder.Entity("Models.Entities.TransactionsType", b =>
                {
                    b.Navigation("transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
