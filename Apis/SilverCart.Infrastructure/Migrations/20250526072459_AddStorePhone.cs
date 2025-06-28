using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddStorePhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Stores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "8c82041a-69a4-48ff-9ecb-aeca7ad88143", new DateTime(2025, 5, 26, 7, 24, 57, 941, DateTimeKind.Utc).AddTicks(5627), "AQAAAAIAAYagAAAAEMeNb7ogtD4+0mtsPl6gHlDnmgbOUr1u9Y6OdcSEMTeK5j58FrA/HeK1jbxEj7HADg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Stores");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "b7f9d075-44bf-4d2e-bbb4-93423d9b2a27", new DateTime(2025, 5, 26, 7, 5, 24, 6, DateTimeKind.Utc).AddTicks(796), "AQAAAAIAAYagAAAAEIf/TOl9w+5yx/1j1GLRyiPJIry6iAtATkw3Nrch3xmLRAD3jQYdifsia4VkynbZPg==" });
        }
    }
}
