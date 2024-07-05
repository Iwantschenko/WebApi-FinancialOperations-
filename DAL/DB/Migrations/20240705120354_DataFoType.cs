using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class DataFoType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "operationTypes",
                columns: new[] { "Operation_ID", "Operation_Description", "Operation_Name" },
                values: new object[,]
                {
                    { new Guid("39b06ec4-2253-491c-9a0c-ca9738cf9255"), "Income operations", "income" },
                    { new Guid("4cd995c6-0f1a-4983-aa74-d666b81c7ac8"), "Expenses operations", "expenses" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "operationTypes",
                keyColumn: "Operation_ID",
                keyValue: new Guid("39b06ec4-2253-491c-9a0c-ca9738cf9255"));

            migrationBuilder.DeleteData(
                table: "operationTypes",
                keyColumn: "Operation_ID",
                keyValue: new Guid("4cd995c6-0f1a-4983-aa74-d666b81c7ac8"));
        }
    }
}
