using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddWardToStoreAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FromProvinceName",
                table: "StoreAddresses",
                newName: "WardName");

            migrationBuilder.RenameColumn(
                name: "FromDistrictName",
                table: "StoreAddresses",
                newName: "ProvinceName");

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "StoreAddresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "0de24570-aeb9-4a8a-a3af-aea722ee2871", new DateTime(2025, 5, 26, 6, 6, 31, 22, DateTimeKind.Utc).AddTicks(233), "AQAAAAIAAYagAAAAECSLtfunf5EpolxM1R9FbUFU3dwg91KkNLRsqScY+Iq24GsdJh9cSN7Qxc/WL+G2Ww==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "StoreAddresses");

            migrationBuilder.RenameColumn(
                name: "WardName",
                table: "StoreAddresses",
                newName: "FromProvinceName");

            migrationBuilder.RenameColumn(
                name: "ProvinceName",
                table: "StoreAddresses",
                newName: "FromDistrictName");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "cfc6899c-42fa-439e-8a8f-037516d6c893", new DateTime(2025, 5, 26, 3, 48, 46, 768, DateTimeKind.Utc).AddTicks(825), "AQAAAAIAAYagAAAAELIpz1zWqBtOR0If3SoUlRBhBKKH8MWW60sU0lUAIDeyQfE8cS0orYE//Jrjxpr2dA==" });
        }
    }
}
