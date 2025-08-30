using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BEAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Update string values to int equivalents before altering column
            migrationBuilder.Sql(@"
                UPDATE [Users] SET [Gender] = '0' WHERE [Gender] = 'Male';
                UPDATE [Users] SET [Gender] = '1' WHERE [Gender] = 'Female';
                UPDATE [Users] SET [Gender] = '2' WHERE [Gender] IS NOT NULL AND [Gender] NOT IN ('Male', 'Female'); -- Optional: for other values
            ");

            // 2. Alter column type
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            // 3. Add new columns
            migrationBuilder.AddColumn<string>(
                name: "EmergencyPhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelationShip",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Spendlimit",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true);

            // 4. Update seed data
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "EmergencyPhoneNumber", "Gender", "RelationShip", "Spendlimit" },
                values: new object[] { null, 0, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "EmergencyPhoneNumber", "Gender", "RelationShip", "Spendlimit" },
                values: new object[] { null, 0, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "EmergencyPhoneNumber", "Gender", "RelationShip", "Spendlimit" },
                values: new object[] { null, 0, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyPhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RelationShip",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Spendlimit",
                table: "Users");

            // If you want to revert back to string, you can map int back to string
            migrationBuilder.Sql(@"
                UPDATE [Users] SET [Gender] = 'Male' WHERE [Gender] = 0;
                UPDATE [Users] SET [Gender] = 'Female' WHERE [Gender] = 1;
            ");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Gender",
                value: "Male");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Gender",
                value: "Female");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Gender",
                value: "Male");
        }
    }
}
