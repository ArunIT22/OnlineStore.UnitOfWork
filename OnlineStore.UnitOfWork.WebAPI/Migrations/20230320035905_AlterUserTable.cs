using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.UnitOfWork.WebAPI.Migrations
{
    public partial class AlterUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 29, 5, 160, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2023, 3, 18, 9, 29, 5, 160, DateTimeKind.Local).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 29, 5, 160, DateTimeKind.Local).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 29, 5, 160, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 29, 5, 160, DateTimeKind.Local).AddTicks(630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 29, 5, 160, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 29, 5, 160, DateTimeKind.Local).AddTicks(632));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 26, 41, 614, DateTimeKind.Local).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2023, 3, 18, 9, 26, 41, 614, DateTimeKind.Local).AddTicks(3048));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 26, 41, 614, DateTimeKind.Local).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 26, 41, 614, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 26, 41, 614, DateTimeKind.Local).AddTicks(3071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 26, 41, 614, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2023, 3, 20, 9, 26, 41, 614, DateTimeKind.Local).AddTicks(3073));
        }
    }
}
