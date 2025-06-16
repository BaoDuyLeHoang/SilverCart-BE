using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddWeightToProductItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "ProductItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "fb9c9152-a0ae-4be0-b56c-38f5e04eda09", new DateTime(2025, 5, 26, 6, 24, 43, 700, DateTimeKind.Utc).AddTicks(9640), "AQAAAAIAAYagAAAAEDxzJZRSJ2Hrk/IIxS2ir5wVYucrf73KfiSMAhNJr3UBIlwxe0ZDb1K0nOC3UkwAAQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "ProductItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "0de24570-aeb9-4a8a-a3af-aea722ee2871", new DateTime(2025, 5, 26, 6, 6, 31, 22, DateTimeKind.Utc).AddTicks(233), "AQAAAAIAAYagAAAAECSLtfunf5EpolxM1R9FbUFU3dwg91KkNLRsqScY+Iq24GsdJh9cSN7Qxc/WL+G2Ww==" });
        }
    }
}
