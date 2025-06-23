using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Update_SetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("068c5fb3-1197-43ab-897b-b428849f56a0"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("1da26546-aab9-43cd-81be-22b17b69a7c6"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("725e11fa-601c-41b7-9faf-f2ff7983d95a"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("75c0b308-5682-43a1-8499-bc7b1cbb1418"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b7755f6-6f50-4f44-8985-01578930df53"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("584d81af-28f9-446b-85e7-544e70bea6dc"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("b758547a-3d00-4878-9524-9eb615730aca"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0db2283-0561-441c-9de2-7bfc5051a32f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("b917739b-3b76-4644-917b-ce415b686f24"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c32c1ca0-dcb2-4658-9f4c-38c4c60a80eb"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d161a6d0-53f9-42dd-bc15-635d61c16b5e"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2fd0a2d-756d-4c8b-a6cc-b908fbb4cc11"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("068c5fb3-1197-43ab-897b-b428849f56a0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1da26546-aab9-43cd-81be-22b17b69a7c6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("584d81af-28f9-446b-85e7-544e70bea6dc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("725e11fa-601c-41b7-9faf-f2ff7983d95a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("75c0b308-5682-43a1-8499-bc7b1cbb1418"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b7755f6-6f50-4f44-8985-01578930df53"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b758547a-3d00-4878-9524-9eb615730aca"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b917739b-3b76-4644-917b-ce415b686f24"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0db2283-0561-441c-9de2-7bfc5051a32f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c32c1ca0-dcb2-4658-9f4c-38c4c60a80eb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d161a6d0-53f9-42dd-bc15-635d61c16b5e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2fd0a2d-756d-4c8b-a6cc-b908fbb4cc11"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("068c5fb3-1197-43ab-897b-b428849f56a0"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("1da26546-aab9-43cd-81be-22b17b69a7c6"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("584d81af-28f9-446b-85e7-544e70bea6dc"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("725e11fa-601c-41b7-9faf-f2ff7983d95a"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("75c0b308-5682-43a1-8499-bc7b1cbb1418"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("9b7755f6-6f50-4f44-8985-01578930df53"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("b758547a-3d00-4878-9524-9eb615730aca"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("b917739b-3b76-4644-917b-ce415b686f24"), null, null, null, null, null, "", false, null, null, "StoreDelivery", "STOREDELIVERY" },
                    { new Guid("c0db2283-0561-441c-9de2-7bfc5051a32f"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("c32c1ca0-dcb2-4658-9f4c-38c4c60a80eb"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" },
                    { new Guid("d161a6d0-53f9-42dd-bc15-635d61c16b5e"), null, null, null, null, null, "", false, null, null, "StoreManager", "STOREMANAGER" },
                    { new Guid("e2fd0a2d-756d-4c8b-a6cc-b908fbb4cc11"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "4bccfcd5-a17a-4f55-86f4-6e04bb77690a", new DateTime(2025, 5, 31, 19, 39, 2, 786, DateTimeKind.Utc).AddTicks(5382), "AQAAAAIAAYagAAAAEEuPEzF4yufmNFg7Oj8LJfU1WddYB/+0rGXh260t1NLN4BQwat6Xvy++WLHTLFbm6Q==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("068c5fb3-1197-43ab-897b-b428849f56a0"),
                    new Guid("1da26546-aab9-43cd-81be-22b17b69a7c6"),
                    new Guid("725e11fa-601c-41b7-9faf-f2ff7983d95a"),
                    new Guid("75c0b308-5682-43a1-8499-bc7b1cbb1418"),
                    new Guid("9b7755f6-6f50-4f44-8985-01578930df53")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("584d81af-28f9-446b-85e7-544e70bea6dc"),
                    new Guid("b758547a-3d00-4878-9524-9eb615730aca"),
                    new Guid("c0db2283-0561-441c-9de2-7bfc5051a32f")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("b917739b-3b76-4644-917b-ce415b686f24"),
                    new Guid("c32c1ca0-dcb2-4658-9f4c-38c4c60a80eb"),
                    new Guid("d161a6d0-53f9-42dd-bc15-635d61c16b5e"),
                    new Guid("e2fd0a2d-756d-4c8b-a6cc-b908fbb4cc11")
                });
        }
    }
}
