using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "Gender", "PasswordHash" },
                values: new object[] { "f15d45d7-fcf5-4aab-b9db-1c0902ee6969", new DateTime(2025, 7, 11, 5, 26, 57, 684, DateTimeKind.Utc).AddTicks(2522), "Other", "AQAAAAIAAYagAAAAEAcy8sYVHTIoIStQ7t26ZWkWJey4k5ZjI+p63AKd7Tde5J51GRUd3uXk0qboES0Cng==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "305193f4-ffdb-4335-bd41-8197e5a0b1c2", new DateTime(2025, 7, 10, 15, 50, 55, 509, DateTimeKind.Utc).AddTicks(7145), "AQAAAAIAAYagAAAAEBMIJ7DmIzhO/9HZUqMNGNJo7yigDjHNfcLRsT1Fh1I5iUiu0jV3dPwYEuLOFJowsQ==" });
        }
    }
}
