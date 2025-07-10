using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Check_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "3c285a15-e68e-498b-b75c-480d6a3c8910", new DateTime(2025, 7, 10, 16, 9, 38, 196, DateTimeKind.Utc).AddTicks(778), "AQAAAAIAAYagAAAAEPdXm00IAqQWFjdhDlAXHrBatKhYmkbOvfJofX3fLfsFg0Ion0jid+b+jqJFbHEndw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "305193f4-ffdb-4335-bd41-8197e5a0b1c2", new DateTime(2025, 7, 10, 15, 50, 55, 509, DateTimeKind.Utc).AddTicks(7145), "AQAAAAIAAYagAAAAEBMIJ7DmIzhO/9HZUqMNGNJo7yigDjHNfcLRsT1Fh1I5iUiu0jV3dPwYEuLOFJowsQ==" });
        }
    }
}
