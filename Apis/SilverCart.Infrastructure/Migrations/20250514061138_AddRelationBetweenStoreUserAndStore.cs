using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenStoreUserAndStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_Stores_StoreId",
                table: "StoreUsers");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("285e6a44-7b04-456d-811c-347323e46a9c"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("5b42fc2c-b0e0-4771-9068-af2829d2b71c"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("98e6e07c-0070-4296-9571-f19bd2f3e67a"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b7c42595-9350-4503-bdf3-40736b46aa62"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7103213-3447-41de-9ca4-f0e92db27b42"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("92fa1cf6-3bda-4a95-bb4e-f40d9c6ed6da"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("bca3cc68-9eb1-4f71-875a-b29535456791"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a5bda87-2975-4ad8-aa23-354b79b1486e"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("64440f84-8cde-4f47-a40d-e18dc402eea3"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf7b39c1-520e-485a-a710-00cf4ca21fca"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d55313e6-f425-4ca3-bf6e-204071e8200f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("285e6a44-7b04-456d-811c-347323e46a9c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2a5bda87-2975-4ad8-aa23-354b79b1486e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5b42fc2c-b0e0-4771-9068-af2829d2b71c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64440f84-8cde-4f47-a40d-e18dc402eea3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("92fa1cf6-3bda-4a95-bb4e-f40d9c6ed6da"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98e6e07c-0070-4296-9571-f19bd2f3e67a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b7c42595-9350-4503-bdf3-40736b46aa62"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bca3cc68-9eb1-4f71-875a-b29535456791"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf7b39c1-520e-485a-a710-00cf4ca21fca"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d55313e6-f425-4ca3-bf6e-204071e8200f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7103213-3447-41de-9ca4-f0e92db27b42"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "StoreUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("077f0d19-89ae-4b1e-9133-4efce7a7ebdb"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("3af6bb98-a426-4cde-8136-3ca67bba1786"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("41152eab-fd69-4554-85b9-fca4fffbaff3"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("434bdbf3-b7ea-42eb-b01a-ad03e90087ab"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("4764f95c-d97e-4e0d-9284-c2a78777fa0c"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("4cd3054a-7ae6-40b5-b2b2-3867ea078f23"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("4d3ea222-17d9-4eaf-a486-487ed4dddd67"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("74473a14-6ed8-4b05-bdf0-0f5d2814b3a9"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("85d98a9c-04e7-4e15-8333-d81dc20ee219"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("f1d1a071-e6da-4b25-87ac-2ad2a8e9fdf7"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("fdea75fc-4f3b-4f2b-87e8-5725256986f8"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "3ec1bb80-3d06-4eaf-b267-a5bcf12596f0", new DateTime(2025, 5, 14, 6, 11, 38, 42, DateTimeKind.Utc).AddTicks(1943), "AQAAAAIAAYagAAAAEDrPn7J5AaESIzkUN4B5pVfRRxzw0mmZafvanoQ9A+ucmDW1uO2F25Lz4ONts7E7Dg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("434bdbf3-b7ea-42eb-b01a-ad03e90087ab"),
                    new Guid("4764f95c-d97e-4e0d-9284-c2a78777fa0c"),
                    new Guid("4d3ea222-17d9-4eaf-a486-487ed4dddd67"),
                    new Guid("85d98a9c-04e7-4e15-8333-d81dc20ee219"),
                    new Guid("fdea75fc-4f3b-4f2b-87e8-5725256986f8")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3af6bb98-a426-4cde-8136-3ca67bba1786"),
                    new Guid("41152eab-fd69-4554-85b9-fca4fffbaff3")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("077f0d19-89ae-4b1e-9133-4efce7a7ebdb"),
                    new Guid("4cd3054a-7ae6-40b5-b2b2-3867ea078f23"),
                    new Guid("74473a14-6ed8-4b05-bdf0-0f5d2814b3a9"),
                    new Guid("f1d1a071-e6da-4b25-87ac-2ad2a8e9fdf7")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_Stores_StoreId",
                table: "StoreUsers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_Stores_StoreId",
                table: "StoreUsers");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("434bdbf3-b7ea-42eb-b01a-ad03e90087ab"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("4764f95c-d97e-4e0d-9284-c2a78777fa0c"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d3ea222-17d9-4eaf-a486-487ed4dddd67"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("85d98a9c-04e7-4e15-8333-d81dc20ee219"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("fdea75fc-4f3b-4f2b-87e8-5725256986f8"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("3af6bb98-a426-4cde-8136-3ca67bba1786"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("41152eab-fd69-4554-85b9-fca4fffbaff3"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("077f0d19-89ae-4b1e-9133-4efce7a7ebdb"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("4cd3054a-7ae6-40b5-b2b2-3867ea078f23"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("74473a14-6ed8-4b05-bdf0-0f5d2814b3a9"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("f1d1a071-e6da-4b25-87ac-2ad2a8e9fdf7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("077f0d19-89ae-4b1e-9133-4efce7a7ebdb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3af6bb98-a426-4cde-8136-3ca67bba1786"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("41152eab-fd69-4554-85b9-fca4fffbaff3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("434bdbf3-b7ea-42eb-b01a-ad03e90087ab"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4764f95c-d97e-4e0d-9284-c2a78777fa0c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4cd3054a-7ae6-40b5-b2b2-3867ea078f23"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d3ea222-17d9-4eaf-a486-487ed4dddd67"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("74473a14-6ed8-4b05-bdf0-0f5d2814b3a9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("85d98a9c-04e7-4e15-8333-d81dc20ee219"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f1d1a071-e6da-4b25-87ac-2ad2a8e9fdf7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fdea75fc-4f3b-4f2b-87e8-5725256986f8"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "StoreUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("285e6a44-7b04-456d-811c-347323e46a9c"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("2a5bda87-2975-4ad8-aa23-354b79b1486e"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("5b42fc2c-b0e0-4771-9068-af2829d2b71c"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("64440f84-8cde-4f47-a40d-e18dc402eea3"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("92fa1cf6-3bda-4a95-bb4e-f40d9c6ed6da"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("98e6e07c-0070-4296-9571-f19bd2f3e67a"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("b7c42595-9350-4503-bdf3-40736b46aa62"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("bca3cc68-9eb1-4f71-875a-b29535456791"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("bf7b39c1-520e-485a-a710-00cf4ca21fca"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("d55313e6-f425-4ca3-bf6e-204071e8200f"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("e7103213-3447-41de-9ca4-f0e92db27b42"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "e1c8b0ac-937b-475a-9403-f5c41fd6cd3c", new DateTime(2025, 5, 14, 5, 38, 27, 823, DateTimeKind.Utc).AddTicks(7453), "AQAAAAIAAYagAAAAEL4eSt2rGjs6Bw4BbCa9c5IBrhLRxoE1wnvB8MkWaToRLs/kiEVTk8BDl1m3PDDuKw==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("285e6a44-7b04-456d-811c-347323e46a9c"),
                    new Guid("5b42fc2c-b0e0-4771-9068-af2829d2b71c"),
                    new Guid("98e6e07c-0070-4296-9571-f19bd2f3e67a"),
                    new Guid("b7c42595-9350-4503-bdf3-40736b46aa62"),
                    new Guid("e7103213-3447-41de-9ca4-f0e92db27b42")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("92fa1cf6-3bda-4a95-bb4e-f40d9c6ed6da"),
                    new Guid("bca3cc68-9eb1-4f71-875a-b29535456791")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("2a5bda87-2975-4ad8-aa23-354b79b1486e"),
                    new Guid("64440f84-8cde-4f47-a40d-e18dc402eea3"),
                    new Guid("bf7b39c1-520e-485a-a710-00cf4ca21fca"),
                    new Guid("d55313e6-f425-4ca3-bf6e-204071e8200f")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_Stores_StoreId",
                table: "StoreUsers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }
    }
}
