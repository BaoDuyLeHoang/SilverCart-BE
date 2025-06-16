using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatav2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3444d9f0-de44-4d4d-ba74-ddabd16f2628"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("41f45d10-5c2d-47ee-8be8-584fe85e4670"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("521c913a-8ca6-4c6c-87a3-04ce55d16ff6"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("98702079-0820-4d2a-a518-0ff65c9abeb7"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7df3caa-346d-420a-b722-c73cf82e4bb7"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2cdf8bb-310c-4a1e-ae48-e05dc1ef0221"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("df4fd32f-4057-4888-9347-e67b89564fe3"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("020c2d2c-7b6f-420b-88dd-74e93391a70d"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5cca8407-6756-44a2-abc2-badc9f9f66db"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f7654d0-dedd-4deb-ab67-6ed475903598"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("b50a6a3f-e589-4757-a139-933b8837a11d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("020c2d2c-7b6f-420b-88dd-74e93391a70d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3444d9f0-de44-4d4d-ba74-ddabd16f2628"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("41f45d10-5c2d-47ee-8be8-584fe85e4670"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("521c913a-8ca6-4c6c-87a3-04ce55d16ff6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5cca8407-6756-44a2-abc2-badc9f9f66db"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f7654d0-dedd-4deb-ab67-6ed475903598"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98702079-0820-4d2a-a518-0ff65c9abeb7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b50a6a3f-e589-4757-a139-933b8837a11d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2cdf8bb-310c-4a1e-ae48-e05dc1ef0221"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7df3caa-346d-420a-b722-c73cf82e4bb7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("df4fd32f-4057-4888-9347-e67b89564fe3"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("27985ce1-855d-46d3-8e73-367f43375805"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("3e6cf206-24d0-408c-af66-79d8e71a83b5"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("3facadb1-5be0-4312-a85a-4dba7a56f342"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("79b26a97-6503-4176-a3c5-7a7822968c30"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("a51776ab-0eaf-41ce-a0cf-8be810f1c6e3"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("a94fde08-759e-445b-b4be-a1ab0058e19a"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("ae8c009d-fb0c-4ee9-9dc8-fc40a2d0d517"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("bb911613-03f8-4fb3-8f7c-eb8c710f730f"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("c0e2d4ae-9dec-4aed-937b-0696201e674e"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("e687ca60-1b7f-4c3f-9968-ca580a27d71f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("e8153911-a5a4-4387-b830-cd940391f7ba"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "0076726d-430e-4d36-ad2e-5c23bfb96583", new DateTime(2025, 5, 9, 6, 27, 2, 554, DateTimeKind.Utc).AddTicks(8988), "AQAAAAIAAYagAAAAECcNKYQjE4nguXbkeYa7tViOXEt/3ANYmcvcD2Z5LZ8aU8MytPCafakeq7MK71Apnw==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3e6cf206-24d0-408c-af66-79d8e71a83b5"),
                    new Guid("3facadb1-5be0-4312-a85a-4dba7a56f342"),
                    new Guid("ae8c009d-fb0c-4ee9-9dc8-fc40a2d0d517"),
                    new Guid("c0e2d4ae-9dec-4aed-937b-0696201e674e"),
                    new Guid("e687ca60-1b7f-4c3f-9968-ca580a27d71f")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("27985ce1-855d-46d3-8e73-367f43375805"),
                    new Guid("a51776ab-0eaf-41ce-a0cf-8be810f1c6e3")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("79b26a97-6503-4176-a3c5-7a7822968c30"),
                    new Guid("a94fde08-759e-445b-b4be-a1ab0058e19a"),
                    new Guid("bb911613-03f8-4fb3-8f7c-eb8c710f730f"),
                    new Guid("e8153911-a5a4-4387-b830-cd940391f7ba")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e6cf206-24d0-408c-af66-79d8e71a83b5"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3facadb1-5be0-4312-a85a-4dba7a56f342"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae8c009d-fb0c-4ee9-9dc8-fc40a2d0d517"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0e2d4ae-9dec-4aed-937b-0696201e674e"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e687ca60-1b7f-4c3f-9968-ca580a27d71f"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("27985ce1-855d-46d3-8e73-367f43375805"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("a51776ab-0eaf-41ce-a0cf-8be810f1c6e3"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("79b26a97-6503-4176-a3c5-7a7822968c30"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("a94fde08-759e-445b-b4be-a1ab0058e19a"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb911613-03f8-4fb3-8f7c-eb8c710f730f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8153911-a5a4-4387-b830-cd940391f7ba"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("27985ce1-855d-46d3-8e73-367f43375805"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e6cf206-24d0-408c-af66-79d8e71a83b5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3facadb1-5be0-4312-a85a-4dba7a56f342"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("79b26a97-6503-4176-a3c5-7a7822968c30"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a51776ab-0eaf-41ce-a0cf-8be810f1c6e3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a94fde08-759e-445b-b4be-a1ab0058e19a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae8c009d-fb0c-4ee9-9dc8-fc40a2d0d517"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb911613-03f8-4fb3-8f7c-eb8c710f730f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0e2d4ae-9dec-4aed-937b-0696201e674e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e687ca60-1b7f-4c3f-9968-ca580a27d71f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8153911-a5a4-4387-b830-cd940391f7ba"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("020c2d2c-7b6f-420b-88dd-74e93391a70d"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("3444d9f0-de44-4d4d-ba74-ddabd16f2628"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("41f45d10-5c2d-47ee-8be8-584fe85e4670"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("521c913a-8ca6-4c6c-87a3-04ce55d16ff6"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("5cca8407-6756-44a2-abc2-badc9f9f66db"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("7f7654d0-dedd-4deb-ab67-6ed475903598"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("98702079-0820-4d2a-a518-0ff65c9abeb7"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("b50a6a3f-e589-4757-a139-933b8837a11d"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("d2cdf8bb-310c-4a1e-ae48-e05dc1ef0221"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("d7df3caa-346d-420a-b722-c73cf82e4bb7"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("df4fd32f-4057-4888-9347-e67b89564fe3"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "28fd18c9-aa5d-405f-8443-049e6ef9e220", new DateTime(2025, 5, 9, 6, 24, 52, 852, DateTimeKind.Utc).AddTicks(9056), "AQAAAAIAAYagAAAAEMR4c7Dw8l+30GdQjOIa5md6EZoYbi91iOW5KY/lcHF8t/CEBtUJguOP00nnvYHkPQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3444d9f0-de44-4d4d-ba74-ddabd16f2628"),
                    new Guid("41f45d10-5c2d-47ee-8be8-584fe85e4670"),
                    new Guid("521c913a-8ca6-4c6c-87a3-04ce55d16ff6"),
                    new Guid("98702079-0820-4d2a-a518-0ff65c9abeb7"),
                    new Guid("d7df3caa-346d-420a-b722-c73cf82e4bb7")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("d2cdf8bb-310c-4a1e-ae48-e05dc1ef0221"),
                    new Guid("df4fd32f-4057-4888-9347-e67b89564fe3")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("020c2d2c-7b6f-420b-88dd-74e93391a70d"),
                    new Guid("5cca8407-6756-44a2-abc2-badc9f9f66db"),
                    new Guid("7f7654d0-dedd-4deb-ab67-6ed475903598"),
                    new Guid("b50a6a3f-e589-4757-a139-933b8837a11d")
                });
        }
    }
}
