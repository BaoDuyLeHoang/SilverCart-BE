using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddConver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastMessage",
                table: "Conversations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "b949dcaa-1cf9-4e76-930d-c75726ffda0a", new DateTime(2025, 6, 3, 3, 49, 5, 382, DateTimeKind.Utc).AddTicks(7807), "AQAAAAIAAYagAAAAEG3p50UbJ4qAoiZH/inAmvmxpwQ74fWKbDgyKpt0Yt2DCIYlOZANGDEGAFkhI9aptA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMessage",
                table: "Conversations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "8c82041a-69a4-48ff-9ecb-aeca7ad88143", new DateTime(2025, 5, 26, 7, 24, 57, 941, DateTimeKind.Utc).AddTicks(5627), "AQAAAAIAAYagAAAAEMeNb7ogtD4+0mtsPl6gHlDnmgbOUr1u9Y6OdcSEMTeK5j58FrA/HeK1jbxEj7HADg==" });
        }
    }
}
