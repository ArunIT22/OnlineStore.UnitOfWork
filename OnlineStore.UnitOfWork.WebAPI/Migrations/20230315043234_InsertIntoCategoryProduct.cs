using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.UnitOfWork.WebAPI.Migrations
{
    public partial class InsertIntoCategoryProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "HomeApplicances" },
                    { 2, "Mobiles" },
                    { 3, "Clothing" },
                    { 4, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AddedDate", "CategoryId", "Discount", "ListPrice", "ProductName", "SellingPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8043), 1, 5f, 55000.50m, "Sony Television", 51000m },
                    { 2, new DateTime(2023, 3, 13, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8045), 1, 5f, 45000.50m, "LG Television", 41000m },
                    { 3, new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8063), 2, 5f, 85000.50m, "iPhone14", 80000m },
                    { 4, new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8065), 2, 4f, 25000.50m, "Samsung M33", 22000m },
                    { 5, new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8066), 3, 5f, 2599m, "Levis Jeans", 2199m },
                    { 6, new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8067), 3, 5f, 950m, "Shirt", 900m },
                    { 7, new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8068), 4, 10f, 259m, "Ruskin Bonds", 209m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
