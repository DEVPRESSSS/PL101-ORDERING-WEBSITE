using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Migrations
{
    /// <inheritdoc />
    public partial class seedCategoryAndProductTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { "CAT-1012", null, "Hot Coffe" },
                    { "CAT-1013", null, "Iced Coffe" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Category_ID", "CreatedAt", "Description", "Name", "Price", "Size", "Stock" },
                values: new object[] { "PROD-202", null, "CAT-1013", new DateOnly(2023, 12, 10), "Test", "Product101", 50.0, "30oz", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: "CAT-1012");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: "CAT-1013");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: "PROD-202");
        }
    }
}
