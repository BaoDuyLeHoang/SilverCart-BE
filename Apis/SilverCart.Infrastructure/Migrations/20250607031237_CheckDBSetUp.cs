using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class CheckDBSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("556742ac-cf63-4f40-b79a-78f46edc1dd7"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("83c7e6ac-f998-42c6-ab42-f69fd15e1b90"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("98618b13-3bf5-4322-b342-bb6f56783cfa"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b836d85b-d241-44c4-bf80-ba551eb1affd"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7a10210-a8b7-493d-8763-047758d38db7"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ec19fdd-79fc-450d-92be-a7b53cf12c3b"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("95fe6213-81fa-4998-b821-47cebe9188b9"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("d746c43d-3990-4e9f-810e-7ad7f90a4223"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("16c81908-f9cb-441e-835a-a1546068b42a"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("3786f7a7-6d05-449c-adcd-4271774db1a9"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("7a2d35d9-aee0-492e-b117-50464c1ac2c6"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a2e2107-28c9-4322-a77d-1b869226729e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("16c81908-f9cb-441e-835a-a1546068b42a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3786f7a7-6d05-449c-adcd-4271774db1a9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ec19fdd-79fc-450d-92be-a7b53cf12c3b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("556742ac-cf63-4f40-b79a-78f46edc1dd7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7a2d35d9-aee0-492e-b117-50464c1ac2c6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83c7e6ac-f998-42c6-ab42-f69fd15e1b90"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("95fe6213-81fa-4998-b821-47cebe9188b9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98618b13-3bf5-4322-b342-bb6f56783cfa"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a2e2107-28c9-4322-a77d-1b869226729e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b836d85b-d241-44c4-bf80-ba551eb1affd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7a10210-a8b7-493d-8763-047758d38db7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d746c43d-3990-4e9f-810e-7ad7f90a4223"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0662e0a3-ae05-4d8f-b56c-c9528157e256"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("1a344170-fe93-4320-b1d3-0140a7d571a1"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("21380e35-8549-4229-a714-99e2ea5ca9c4"), null, null, null, null, null, "", false, null, null, "StoreManager", "STOREMANAGER" },
                    { new Guid("340e58a8-4605-4317-a18a-f2fc3e96940f"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("3d0f01df-3615-46a4-bedc-c4ba95df7235"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("6077bf32-6d29-41ce-af9d-abcd48266407"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" },
                    { new Guid("767b762c-120b-468a-acb9-111a06845b75"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("7cbc4362-00c7-4d29-9607-9523ac92d1de"), null, null, null, null, null, "", false, null, null, "StoreDelivery", "STOREDELIVERY" },
                    { new Guid("8354fca4-0dfd-4c9e-8e7b-220a9a53e2c1"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("a6f93435-b61f-4320-abf4-5551c1101e6f"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" },
                    { new Guid("e0117101-92d0-4dd3-afe4-a3326411c30c"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("f23b2eb1-57ab-49be-9310-5321809d9339"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "e47288a8-97c2-49c4-841f-cc47ba2579d7", new DateTime(2025, 6, 7, 3, 12, 36, 257, DateTimeKind.Utc).AddTicks(2861), "AQAAAAIAAYagAAAAEHVIvA+Yep+a4JTQ9OlUyw6R5LORE+3S691mZIIn2JHrDZ4yPR/oLdq9qNu5A7usRA==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1a344170-fe93-4320-b1d3-0140a7d571a1"),
                    new Guid("3d0f01df-3615-46a4-bedc-c4ba95df7235"),
                    new Guid("767b762c-120b-468a-acb9-111a06845b75"),
                    new Guid("8354fca4-0dfd-4c9e-8e7b-220a9a53e2c1"),
                    new Guid("e0117101-92d0-4dd3-afe4-a3326411c30c")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0662e0a3-ae05-4d8f-b56c-c9528157e256"),
                    new Guid("340e58a8-4605-4317-a18a-f2fc3e96940f"),
                    new Guid("f23b2eb1-57ab-49be-9310-5321809d9339")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("21380e35-8549-4229-a714-99e2ea5ca9c4"),
                    new Guid("6077bf32-6d29-41ce-af9d-abcd48266407"),
                    new Guid("7cbc4362-00c7-4d29-9607-9523ac92d1de"),
                    new Guid("a6f93435-b61f-4320-abf4-5551c1101e6f")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a344170-fe93-4320-b1d3-0140a7d571a1"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d0f01df-3615-46a4-bedc-c4ba95df7235"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("767b762c-120b-468a-acb9-111a06845b75"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8354fca4-0dfd-4c9e-8e7b-220a9a53e2c1"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e0117101-92d0-4dd3-afe4-a3326411c30c"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("0662e0a3-ae05-4d8f-b56c-c9528157e256"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("340e58a8-4605-4317-a18a-f2fc3e96940f"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("f23b2eb1-57ab-49be-9310-5321809d9339"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("21380e35-8549-4229-a714-99e2ea5ca9c4"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("6077bf32-6d29-41ce-af9d-abcd48266407"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cbc4362-00c7-4d29-9607-9523ac92d1de"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6f93435-b61f-4320-abf4-5551c1101e6f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0662e0a3-ae05-4d8f-b56c-c9528157e256"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a344170-fe93-4320-b1d3-0140a7d571a1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("21380e35-8549-4229-a714-99e2ea5ca9c4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("340e58a8-4605-4317-a18a-f2fc3e96940f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d0f01df-3615-46a4-bedc-c4ba95df7235"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6077bf32-6d29-41ce-af9d-abcd48266407"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("767b762c-120b-468a-acb9-111a06845b75"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cbc4362-00c7-4d29-9607-9523ac92d1de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8354fca4-0dfd-4c9e-8e7b-220a9a53e2c1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6f93435-b61f-4320-abf4-5551c1101e6f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e0117101-92d0-4dd3-afe4-a3326411c30c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f23b2eb1-57ab-49be-9310-5321809d9339"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("16c81908-f9cb-441e-835a-a1546068b42a"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" },
                    { new Guid("3786f7a7-6d05-449c-adcd-4271774db1a9"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" },
                    { new Guid("4ec19fdd-79fc-450d-92be-a7b53cf12c3b"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("556742ac-cf63-4f40-b79a-78f46edc1dd7"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("7a2d35d9-aee0-492e-b117-50464c1ac2c6"), null, null, null, null, null, "", false, null, null, "StoreManager", "STOREMANAGER" },
                    { new Guid("83c7e6ac-f998-42c6-ab42-f69fd15e1b90"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("95fe6213-81fa-4998-b821-47cebe9188b9"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("98618b13-3bf5-4322-b342-bb6f56783cfa"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("9a2e2107-28c9-4322-a77d-1b869226729e"), null, null, null, null, null, "", false, null, null, "StoreDelivery", "STOREDELIVERY" },
                    { new Guid("b836d85b-d241-44c4-bf80-ba551eb1affd"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("c7a10210-a8b7-493d-8763-047758d38db7"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("d746c43d-3990-4e9f-810e-7ad7f90a4223"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "cee16f1a-1360-44e5-a12a-c17e4cdfb7bc", new DateTime(2025, 5, 31, 21, 17, 4, 367, DateTimeKind.Utc).AddTicks(9520), "AQAAAAIAAYagAAAAEK5rTK3u3NIrmTv63K42oET5lojx/o0xDfeIsULtKHrmZyTSvO8hdlF0Wa8UWeX6NQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("556742ac-cf63-4f40-b79a-78f46edc1dd7"),
                    new Guid("83c7e6ac-f998-42c6-ab42-f69fd15e1b90"),
                    new Guid("98618b13-3bf5-4322-b342-bb6f56783cfa"),
                    new Guid("b836d85b-d241-44c4-bf80-ba551eb1affd"),
                    new Guid("c7a10210-a8b7-493d-8763-047758d38db7")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("4ec19fdd-79fc-450d-92be-a7b53cf12c3b"),
                    new Guid("95fe6213-81fa-4998-b821-47cebe9188b9"),
                    new Guid("d746c43d-3990-4e9f-810e-7ad7f90a4223")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("16c81908-f9cb-441e-835a-a1546068b42a"),
                    new Guid("3786f7a7-6d05-449c-adcd-4271774db1a9"),
                    new Guid("7a2d35d9-aee0-492e-b117-50464c1ac2c6"),
                    new Guid("9a2e2107-28c9-4322-a77d-1b869226729e")
                });
        }
    }
}
