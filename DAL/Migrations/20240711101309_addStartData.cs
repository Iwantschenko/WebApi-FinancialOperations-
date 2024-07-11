using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addStartData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "operationTypes",
                columns: new[] { "ID", "IsIncome", "Name" },
                values: new object[,]
                {
                    { new Guid("3eab599a-ff06-4818-828e-42d49f12405a"), false, "expenses" },
                    { new Guid("551e0ac4-8fba-4342-ab69-9a74c33f8639"), true, "income" }
                });

            migrationBuilder.InsertData(
                table: "transactions",
                columns: new[] { "Transaction_Id", "Amount", "DateTime", "Description", "OperationTypeID" },
                values: new object[,]
                {
                    { new Guid("1267e377-192b-49a1-97ea-0eb276b84187"), 300.00m, new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Income from investments", new Guid("551e0ac4-8fba-4342-ab69-9a74c33f8639") },
                    { new Guid("32a3009f-f23e-4d72-85b6-bf5b87361294"), 100.00m, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Income from sales", new Guid("551e0ac4-8fba-4342-ab69-9a74c33f8639") },
                    { new Guid("4d12e83f-ad37-4b68-9391-9363578d5337"), 150.00m, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Freelance work", new Guid("551e0ac4-8fba-4342-ab69-9a74c33f8639") },
                    { new Guid("9fcc66c0-6fa4-4d05-adf9-017f297bea58"), 125.00m, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing expenses", new Guid("3eab599a-ff06-4818-828e-42d49f12405a") },
                    { new Guid("d65ab685-3a61-4a76-ab81-896cec734c98"), 200.00m, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consulting services", new Guid("551e0ac4-8fba-4342-ab69-9a74c33f8639") },
                    { new Guid("db9577db-8eea-42e2-8c39-42ac379fb981"), 100.00m, new DateTime(2024, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Travel expenses", new Guid("3eab599a-ff06-4818-828e-42d49f12405a") },
                    { new Guid("e28b528d-20cc-47a1-8692-8570b35b05cf"), 50.00m, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Office supplies", new Guid("3eab599a-ff06-4818-828e-42d49f12405a") },
                    { new Guid("fe6d52af-c390-4438-a7d5-e58470fd1b85"), 75.00m, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility bill", new Guid("3eab599a-ff06-4818-828e-42d49f12405a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Transaction_Id",
                keyValue: new Guid("1267e377-192b-49a1-97ea-0eb276b84187"));

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Transaction_Id",
                keyValue: new Guid("32a3009f-f23e-4d72-85b6-bf5b87361294"));

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Transaction_Id",
                keyValue: new Guid("4d12e83f-ad37-4b68-9391-9363578d5337"));

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Transaction_Id",
                keyValue: new Guid("9fcc66c0-6fa4-4d05-adf9-017f297bea58"));

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Transaction_Id",
                keyValue: new Guid("d65ab685-3a61-4a76-ab81-896cec734c98"));

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Transaction_Id",
                keyValue: new Guid("db9577db-8eea-42e2-8c39-42ac379fb981"));

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Transaction_Id",
                keyValue: new Guid("e28b528d-20cc-47a1-8692-8570b35b05cf"));

            migrationBuilder.DeleteData(
                table: "transactions",
                keyColumn: "Transaction_Id",
                keyValue: new Guid("fe6d52af-c390-4438-a7d5-e58470fd1b85"));

            migrationBuilder.DeleteData(
                table: "operationTypes",
                keyColumn: "ID",
                keyValue: new Guid("3eab599a-ff06-4818-828e-42d49f12405a"));

            migrationBuilder.DeleteData(
                table: "operationTypes",
                keyColumn: "ID",
                keyValue: new Guid("551e0ac4-8fba-4342-ab69-9a74c33f8639"));
        }
    }
}
