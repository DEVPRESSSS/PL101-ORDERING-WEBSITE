using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Migrations
{
    /// <inheritdoc />
    public partial class seedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: "PROD-202",
                column: "Category_ID",
                value: "CAT-1012");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Category_ID", "CreatedAt", "Description", "Name", "Price", "Size", "Stock" },
                values: new object[,]
                {
                    { "PROD-203", "CAT-1012", new DateOnly(2023, 12, 10), "Test", "Product101", 50.0, "30oz", 2 },
                    { "PROD-204", "CAT-1012", new DateOnly(2023, 12, 10), "Test", "Product101", 50.0, "30oz", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: "PROD-203");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: "PROD-204");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: "PROD-202",
                column: "Category_ID",
                value: "CAT-1013");
        }
    }
}
