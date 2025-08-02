using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Check_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "305193f4-ffdb-4335-bd41-8197e5a0b1c2", new DateTime(2025, 7, 10, 15, 50, 55, 509, DateTimeKind.Utc).AddTicks(7145), "AQAAAAIAAYagAAAAEBMIJ7DmIzhO/9HZUqMNGNJo7yigDjHNfcLRsT1Fh1I5iUiu0jV3dPwYEuLOFJowsQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "32db2eaa-aebe-41e2-93ba-c9d526a90537", new DateTime(2025, 7, 10, 15, 2, 40, 94, DateTimeKind.Utc).AddTicks(3276), "AQAAAAIAAYagAAAAECkAGcXJtMUNFiOJn0avbpwKGczH/ySpYAHnqBYR+2Kd7qN0GAOg7ZWzpTKl60ryNA==" });
        }
    }
}
