using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreProductItemOrderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "StoreProductItemsOrder",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "d4c9e6ee-3adc-488f-acfa-2cf6ddbfd1db", new DateTime(2025, 5, 26, 6, 51, 36, 980, DateTimeKind.Utc).AddTicks(7267), "AQAAAAIAAYagAAAAEKTNYjWjGv5ZDS7TdxNhUBlTaqbGiDpHChD4TeAwjIkWbz1+Orr4bWEq/6mNaoiiUQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StoreProductItemsOrder");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "fb9c9152-a0ae-4be0-b56c-38f5e04eda09", new DateTime(2025, 5, 26, 6, 24, 43, 700, DateTimeKind.Utc).AddTicks(9640), "AQAAAAIAAYagAAAAEDxzJZRSJ2Hrk/IIxS2ir5wVYucrf73KfiSMAhNJr3UBIlwxe0ZDb1K0nOC3UkwAAQ==" });
        }
    }
}
