using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Init_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operationTypes",
                columns: table => new
                {
                    Operation_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Operation_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operationTypes", x => x.Operation_ID);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Transaction_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Transaction_Id);
                    table.ForeignKey(
                        name: "FK_transactions_operationTypes_OperationTypeID",
                        column: x => x.OperationTypeID,
                        principalTable: "operationTypes",
                        principalColumn: "Operation_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_OperationTypeID",
                table: "transactions",
                column: "OperationTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "operationTypes");
        }
    }
}
