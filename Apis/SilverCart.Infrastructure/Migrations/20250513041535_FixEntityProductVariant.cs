using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixEntityProductVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ad6c7a4-5d01-4031-bc97-019c9a5dfe7f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e439685-c17c-4c44-b7ac-602852ac4161"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("89c31de1-46a9-401a-a941-9affb9636e8d"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d1a9e12-6710-4f15-a689-5f8b79fdda3e"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd7fcea7-fe6d-4fa6-8360-ee644ecd18f4"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("adbade04-b559-4777-b1a0-2f245af04bad"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd8c2df3-0401-43e3-b9cc-c2a829157ce5"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("01a8eff1-3c68-4ce0-a767-2b06157c18b1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e76832e-9cc0-47c3-94f2-f96473f37e79"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c0f7754-1a28-4ae1-9613-ddb55679a5c1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c577c87f-f067-4ceb-ad0d-f5de6f0bc3ce"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01a8eff1-3c68-4ce0-a767-2b06157c18b1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e76832e-9cc0-47c3-94f2-f96473f37e79"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c0f7754-1a28-4ae1-9613-ddb55679a5c1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ad6c7a4-5d01-4031-bc97-019c9a5dfe7f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e439685-c17c-4c44-b7ac-602852ac4161"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("89c31de1-46a9-401a-a941-9affb9636e8d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d1a9e12-6710-4f15-a689-5f8b79fdda3e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("adbade04-b559-4777-b1a0-2f245af04bad"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd7fcea7-fe6d-4fa6-8360-ee644ecd18f4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd8c2df3-0401-43e3-b9cc-c2a829157ce5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c577c87f-f067-4ceb-ad0d-f5de6f0bc3ce"));

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "ProductVariants");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("09334fe3-b83d-4913-a902-df06fdc84c24"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("0e131c4a-6100-4c51-bb65-36184c9e24a7"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("10b767c4-f323-462c-b71d-19d100a4ab5e"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("2791904a-e344-4176-9cc8-13668a36a11b"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("5290efdb-dadc-446e-9d1a-ed1ec07baca7"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("61a07897-0ffe-4cb4-bb6c-02b06e968c64"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("9a27fc0f-0414-4b51-9bba-13868f8f7d2a"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("a8049888-475e-4bcf-9c28-968267d4f21d"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("bab8c8de-0d30-4e4f-87f1-92836b321518"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("c5132bda-3d66-4726-8adb-7e1b6ae758a4"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("c6c3b3c6-3532-43fa-9499-a85d5d8a6f80"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "ff3730a3-0623-4473-8321-1f7c78d291e3", new DateTime(2025, 5, 13, 4, 15, 33, 546, DateTimeKind.Utc).AddTicks(7028), "AQAAAAIAAYagAAAAEPtWWlz7yX9snRGCXoGpNGLQ9q61Q5HwlPv1AFCUInjM/K0E9bWGVhEkQI+gGvXniQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("09334fe3-b83d-4913-a902-df06fdc84c24"),
                    new Guid("10b767c4-f323-462c-b71d-19d100a4ab5e"),
                    new Guid("61a07897-0ffe-4cb4-bb6c-02b06e968c64"),
                    new Guid("c5132bda-3d66-4726-8adb-7e1b6ae758a4"),
                    new Guid("c6c3b3c6-3532-43fa-9499-a85d5d8a6f80")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("5290efdb-dadc-446e-9d1a-ed1ec07baca7"),
                    new Guid("9a27fc0f-0414-4b51-9bba-13868f8f7d2a")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0e131c4a-6100-4c51-bb65-36184c9e24a7"),
                    new Guid("2791904a-e344-4176-9cc8-13668a36a11b"),
                    new Guid("a8049888-475e-4bcf-9c28-968267d4f21d"),
                    new Guid("bab8c8de-0d30-4e4f-87f1-92836b321518")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("09334fe3-b83d-4913-a902-df06fdc84c24"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("10b767c4-f323-462c-b71d-19d100a4ab5e"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("61a07897-0ffe-4cb4-bb6c-02b06e968c64"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5132bda-3d66-4726-8adb-7e1b6ae758a4"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("c6c3b3c6-3532-43fa-9499-a85d5d8a6f80"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("5290efdb-dadc-446e-9d1a-ed1ec07baca7"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a27fc0f-0414-4b51-9bba-13868f8f7d2a"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e131c4a-6100-4c51-bb65-36184c9e24a7"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("2791904a-e344-4176-9cc8-13668a36a11b"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("a8049888-475e-4bcf-9c28-968267d4f21d"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("bab8c8de-0d30-4e4f-87f1-92836b321518"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09334fe3-b83d-4913-a902-df06fdc84c24"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e131c4a-6100-4c51-bb65-36184c9e24a7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("10b767c4-f323-462c-b71d-19d100a4ab5e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2791904a-e344-4176-9cc8-13668a36a11b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5290efdb-dadc-446e-9d1a-ed1ec07baca7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("61a07897-0ffe-4cb4-bb6c-02b06e968c64"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9a27fc0f-0414-4b51-9bba-13868f8f7d2a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a8049888-475e-4bcf-9c28-968267d4f21d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bab8c8de-0d30-4e4f-87f1-92836b321518"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5132bda-3d66-4726-8adb-7e1b6ae758a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c6c3b3c6-3532-43fa-9499-a85d5d8a6f80"));

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "ProductVariants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "ProductVariants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01a8eff1-3c68-4ce0-a767-2b06157c18b1"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("0e76832e-9cc0-47c3-94f2-f96473f37e79"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("3c0f7754-1a28-4ae1-9613-ddb55679a5c1"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("4ad6c7a4-5d01-4031-bc97-019c9a5dfe7f"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("4e439685-c17c-4c44-b7ac-602852ac4161"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("89c31de1-46a9-401a-a941-9affb9636e8d"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("8d1a9e12-6710-4f15-a689-5f8b79fdda3e"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("adbade04-b559-4777-b1a0-2f245af04bad"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("bd7fcea7-fe6d-4fa6-8360-ee644ecd18f4"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("bd8c2df3-0401-43e3-b9cc-c2a829157ce5"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("c577c87f-f067-4ceb-ad0d-f5de6f0bc3ce"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "5abc5f88-e78e-4ac6-a4fe-521ee129a0f2", new DateTime(2025, 5, 12, 17, 28, 44, 203, DateTimeKind.Utc).AddTicks(3519), "AQAAAAIAAYagAAAAEFmqjVCTi5c3idhmit5y2zlVJ69mSB+ftpJy2Qm0P5sx/qS8UxnZzMqjHtcVyjeFzg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("4ad6c7a4-5d01-4031-bc97-019c9a5dfe7f"),
                    new Guid("4e439685-c17c-4c44-b7ac-602852ac4161"),
                    new Guid("89c31de1-46a9-401a-a941-9affb9636e8d"),
                    new Guid("8d1a9e12-6710-4f15-a689-5f8b79fdda3e"),
                    new Guid("bd7fcea7-fe6d-4fa6-8360-ee644ecd18f4")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("adbade04-b559-4777-b1a0-2f245af04bad"),
                    new Guid("bd8c2df3-0401-43e3-b9cc-c2a829157ce5")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("01a8eff1-3c68-4ce0-a767-2b06157c18b1"),
                    new Guid("0e76832e-9cc0-47c3-94f2-f96473f37e79"),
                    new Guid("3c0f7754-1a28-4ae1-9613-ddb55679a5c1"),
                    new Guid("c577c87f-f067-4ceb-ad0d-f5de6f0bc3ce")
                });
        }
    }
}
