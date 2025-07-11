using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class CheckDbUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "Other");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "Gender", "PasswordHash" },
                values: new object[] { "5f840fb6-e6e8-4ecd-a644-5205e85182f8", new DateTime(2025, 7, 11, 7, 19, 7, 977, DateTimeKind.Utc).AddTicks(704), "Other", "AQAAAAIAAYagAAAAEAlsSfIbg+PwNBbUdqZ6CU2X4+KgsWCI4GG9FPgUngGmGM/ToWxj7ziYrlOGnWPVXA==" });
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
