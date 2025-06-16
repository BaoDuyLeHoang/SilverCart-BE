using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixCustomerAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "b7f9d075-44bf-4d2e-bbb4-93423d9b2a27", new DateTime(2025, 5, 26, 7, 5, 24, 6, DateTimeKind.Utc).AddTicks(796), "AQAAAAIAAYagAAAAEIf/TOl9w+5yx/1j1GLRyiPJIry6iAtATkw3Nrch3xmLRAD3jQYdifsia4VkynbZPg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "d4c9e6ee-3adc-488f-acfa-2cf6ddbfd1db", new DateTime(2025, 5, 26, 6, 51, 36, 980, DateTimeKind.Utc).AddTicks(7267), "AQAAAAIAAYagAAAAEKTNYjWjGv5ZDS7TdxNhUBlTaqbGiDpHChD4TeAwjIkWbz1+Orr4bWEq/6mNaoiiUQ==" });
        }
    }
}
