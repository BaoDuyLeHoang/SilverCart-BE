using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserfixv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c6db6ae-6bc0-40d9-a94f-3892891ad743"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3178dd96-39af-4868-8096-52d245c60955"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3daaf432-fb3a-4b1d-8e15-d7d7a9726f81"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("543fdcdd-995d-4289-8c5c-8667d71c12c0"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b163c6fb-6b3b-4ce7-8f3e-99995a499a2f"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("959c60b8-7ae2-4d88-8424-be9803d2f303"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3e3c11d-48ac-42a3-8049-b0c638fc07b7"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("d01674e2-8fa5-4617-9a97-c79f82d8a501"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("1aae0341-c8bd-474f-afb2-d6bcf3daa331"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("302c5dee-c581-46d6-a6dd-198599fea694"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("33ba3181-ce48-4b9b-b112-741320cdb8ef"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("af94e231-ddc9-4678-8dae-5f30a54725a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1aae0341-c8bd-474f-afb2-d6bcf3daa331"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c6db6ae-6bc0-40d9-a94f-3892891ad743"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("302c5dee-c581-46d6-a6dd-198599fea694"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3178dd96-39af-4868-8096-52d245c60955"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33ba3181-ce48-4b9b-b112-741320cdb8ef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3daaf432-fb3a-4b1d-8e15-d7d7a9726f81"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("543fdcdd-995d-4289-8c5c-8667d71c12c0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("959c60b8-7ae2-4d88-8424-be9803d2f303"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("af94e231-ddc9-4678-8dae-5f30a54725a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b163c6fb-6b3b-4ce7-8f3e-99995a499a2f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3e3c11d-48ac-42a3-8049-b0c638fc07b7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d01674e2-8fa5-4617-9a97-c79f82d8a501"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("075b9468-8ef5-42f9-8f3c-ed5983f3b301"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("10aa5165-49b4-4346-b804-340ac6ba41cc"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("3f776114-1fca-4a59-aaeb-ff874edede82"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("5297f1ca-aaad-44a2-8525-40e0dc747792"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("52d7cc4f-b1dc-4c5c-bb6a-3d39b22dd228"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("72cc6ab8-f456-45c0-b39a-957fdbfde10b"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("77a9213c-39af-4e05-b331-088dd87a8822"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("7e9680cc-c29a-4fcf-8ecb-69d58ac1904f"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("86b2c1ae-c413-458b-8500-5f8976a054a1"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("8fc07e42-16e0-4157-86e1-4ebde8354286"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("afd74a93-1690-4022-92f9-f150f85265f7"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("cbdf3de3-68e1-4d15-bebd-ede0398399df"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "75c07c9d-99b6-42ff-b6a8-ab783b9450df", new DateTime(2025, 5, 21, 4, 24, 14, 601, DateTimeKind.Utc).AddTicks(6216), "AQAAAAIAAYagAAAAEKWvunv2yLXgbOsBe9dlJpMyx3M1ovbdeGNRdV2m4OEvJQvnwDVXbypylay1F/wOIQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("075b9468-8ef5-42f9-8f3c-ed5983f3b301"),
                    new Guid("5297f1ca-aaad-44a2-8525-40e0dc747792"),
                    new Guid("77a9213c-39af-4e05-b331-088dd87a8822"),
                    new Guid("7e9680cc-c29a-4fcf-8ecb-69d58ac1904f"),
                    new Guid("afd74a93-1690-4022-92f9-f150f85265f7")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("10aa5165-49b4-4346-b804-340ac6ba41cc"),
                    new Guid("3f776114-1fca-4a59-aaeb-ff874edede82"),
                    new Guid("86b2c1ae-c413-458b-8500-5f8976a054a1")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("52d7cc4f-b1dc-4c5c-bb6a-3d39b22dd228"),
                    new Guid("72cc6ab8-f456-45c0-b39a-957fdbfde10b"),
                    new Guid("8fc07e42-16e0-4157-86e1-4ebde8354286"),
                    new Guid("cbdf3de3-68e1-4d15-bebd-ede0398399df")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("075b9468-8ef5-42f9-8f3c-ed5983f3b301"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("5297f1ca-aaad-44a2-8525-40e0dc747792"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("77a9213c-39af-4e05-b331-088dd87a8822"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e9680cc-c29a-4fcf-8ecb-69d58ac1904f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("afd74a93-1690-4022-92f9-f150f85265f7"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("10aa5165-49b4-4346-b804-340ac6ba41cc"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f776114-1fca-4a59-aaeb-ff874edede82"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("86b2c1ae-c413-458b-8500-5f8976a054a1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("52d7cc4f-b1dc-4c5c-bb6a-3d39b22dd228"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("72cc6ab8-f456-45c0-b39a-957fdbfde10b"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("8fc07e42-16e0-4157-86e1-4ebde8354286"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbdf3de3-68e1-4d15-bebd-ede0398399df"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("075b9468-8ef5-42f9-8f3c-ed5983f3b301"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("10aa5165-49b4-4346-b804-340ac6ba41cc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f776114-1fca-4a59-aaeb-ff874edede82"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5297f1ca-aaad-44a2-8525-40e0dc747792"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("52d7cc4f-b1dc-4c5c-bb6a-3d39b22dd228"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("72cc6ab8-f456-45c0-b39a-957fdbfde10b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77a9213c-39af-4e05-b331-088dd87a8822"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e9680cc-c29a-4fcf-8ecb-69d58ac1904f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("86b2c1ae-c413-458b-8500-5f8976a054a1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8fc07e42-16e0-4157-86e1-4ebde8354286"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("afd74a93-1690-4022-92f9-f150f85265f7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbdf3de3-68e1-4d15-bebd-ede0398399df"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1aae0341-c8bd-474f-afb2-d6bcf3daa331"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("2c6db6ae-6bc0-40d9-a94f-3892891ad743"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("302c5dee-c581-46d6-a6dd-198599fea694"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("3178dd96-39af-4868-8096-52d245c60955"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("33ba3181-ce48-4b9b-b112-741320cdb8ef"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("3daaf432-fb3a-4b1d-8e15-d7d7a9726f81"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("543fdcdd-995d-4289-8c5c-8667d71c12c0"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("959c60b8-7ae2-4d88-8424-be9803d2f303"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("af94e231-ddc9-4678-8dae-5f30a54725a4"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("b163c6fb-6b3b-4ce7-8f3e-99995a499a2f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("c3e3c11d-48ac-42a3-8049-b0c638fc07b7"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("d01674e2-8fa5-4617-9a97-c79f82d8a501"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "4947d753-995c-440e-8f7d-5675bcdb2260", new DateTime(2025, 5, 20, 8, 51, 8, 500, DateTimeKind.Utc).AddTicks(9075), "AQAAAAIAAYagAAAAEA433vEsdyjnQ+15DZRXMN0fDrkkt+CAO7SAcnVg47ahA+GP/qeBpD05Z+D0c0yYNQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("2c6db6ae-6bc0-40d9-a94f-3892891ad743"),
                    new Guid("3178dd96-39af-4868-8096-52d245c60955"),
                    new Guid("3daaf432-fb3a-4b1d-8e15-d7d7a9726f81"),
                    new Guid("543fdcdd-995d-4289-8c5c-8667d71c12c0"),
                    new Guid("b163c6fb-6b3b-4ce7-8f3e-99995a499a2f")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("959c60b8-7ae2-4d88-8424-be9803d2f303"),
                    new Guid("c3e3c11d-48ac-42a3-8049-b0c638fc07b7"),
                    new Guid("d01674e2-8fa5-4617-9a97-c79f82d8a501")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1aae0341-c8bd-474f-afb2-d6bcf3daa331"),
                    new Guid("302c5dee-c581-46d6-a6dd-198599fea694"),
                    new Guid("33ba3181-ce48-4b9b-b112-741320cdb8ef"),
                    new Guid("af94e231-ddc9-4678-8dae-5f30a54725a4")
                });
        }
    }
}
