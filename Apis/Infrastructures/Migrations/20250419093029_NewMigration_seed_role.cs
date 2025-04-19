using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration_seed_role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("eae9874c-10dc-4f1a-b14f-d6cf70aba47a"));

            migrationBuilder.DeleteData(
                table: "AdministratorUsers",
                keyColumn: "Id",
                keyValue: new Guid("c6e51106-4b1d-4f46-9206-2b23dfb6f5d1"));

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StoreUserRoles");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StoreUserRoles");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StoreUserRoles");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StoreUserRoles");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StoreUserRoles");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "StoreUserRoles");

            migrationBuilder.InsertData(
                table: "AdministratorUserRoles",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2204d2bc-8979-4456-9ed9-d151a5bba61c"), null, null, null, null, "Admin Role ", null, null, "Admin", "Admin" },
                    { new Guid("f0c96c2e-e26d-405b-a984-f6c7c40a8760"), null, null, null, null, "Super Admin Role with all permissions", null, null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AdministratorUsers",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Email", "FirstName", "IsVerified", "LastName", "ModificationById", "ModificationDate", "PasswordHash", "Phone", "RefreshToken", "RoleId", "SignInTime" },
                values: new object[] { new Guid("07a34fdc-17fe-4536-9946-9c6ca44d1772"), null, null, null, null, "admin@elderly.com", "Super", true, "Admin", null, null, "admin111", "", null, null, null });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("40ea4122-bab4-4559-81a5-7bfbdc175be7"), null, null, null, null, "", null, null, "Service", "Service" },
                    { new Guid("b998c50d-ee43-4d76-9f8a-84b5cb0ee9cd"), null, null, null, null, "", null, null, "Manager", "Store Manager" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("2204d2bc-8979-4456-9ed9-d151a5bba61c"));

            migrationBuilder.DeleteData(
                table: "AdministratorUserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0c96c2e-e26d-405b-a984-f6c7c40a8760"));

            migrationBuilder.DeleteData(
                table: "AdministratorUsers",
                keyColumn: "Id",
                keyValue: new Guid("07a34fdc-17fe-4536-9946-9c6ca44d1772"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("40ea4122-bab4-4559-81a5-7bfbdc175be7"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("b998c50d-ee43-4d76-9f8a-84b5cb0ee9cd"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.InsertData(
                table: "AdministratorUserRoles",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[] { new Guid("eae9874c-10dc-4f1a-b14f-d6cf70aba47a"), null, null, null, null, "Super Admin Role with all permissions", null, null, "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AdministratorUsers",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Email", "FirstName", "IsVerified", "LastName", "ModificationById", "ModificationDate", "PasswordHash", "Phone", "RefreshToken", "RoleId", "SignInTime" },
                values: new object[] { new Guid("c6e51106-4b1d-4f46-9206-2b23dfb6f5d1"), null, null, null, null, "admin@elderly.com", "Super", true, "Admin", null, null, "admin111", "", null, null, null });
        }
    }
}
