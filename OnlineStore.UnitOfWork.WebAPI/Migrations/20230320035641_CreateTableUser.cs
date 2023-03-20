using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.UnitOfWork.WebAPI.Migrations
{
    public partial class CreateTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NewId()"),
                    Username = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EmailId = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedDate",
                value: new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AddedDate",
                value: new DateTime(2023, 3, 13, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AddedDate",
                value: new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "AddedDate",
                value: new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "AddedDate",
                value: new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "AddedDate",
                value: new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "AddedDate",
                value: new DateTime(2023, 3, 15, 10, 2, 34, 801, DateTimeKind.Local).AddTicks(8068));
        }
    }
}
