using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductItemImageRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductItemId",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("238f6ea5-0c16-4de8-95f0-dc506e1d976d"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b6ed63e-fc79-4823-987e-2a10d357e56b"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("33d95935-d7d0-4ab6-9954-81e0ae56ddd9"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fb36102-e63e-4392-acd5-adf35e46190b"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("fdc148e2-e39c-4e98-ae18-737e0b479d28"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d5e5d5a-0953-4e8a-b811-495250c59f54"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("55084aae-0227-41ed-a38c-2235c92561d2"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("04c1cf37-fd32-4df2-bd65-d686a7b4758f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("06d58718-38dd-4509-8423-1506ac151451"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f7bf7da-cee1-4feb-95d2-0fa06d0a05a7"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("83875e46-e936-48fd-8e96-efa49423c0dd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04c1cf37-fd32-4df2-bd65-d686a7b4758f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("06d58718-38dd-4509-8423-1506ac151451"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d5e5d5a-0953-4e8a-b811-495250c59f54"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("238f6ea5-0c16-4de8-95f0-dc506e1d976d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b6ed63e-fc79-4823-987e-2a10d357e56b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33d95935-d7d0-4ab6-9954-81e0ae56ddd9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("55084aae-0227-41ed-a38c-2235c92561d2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f7bf7da-cee1-4feb-95d2-0fa06d0a05a7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fb36102-e63e-4392-acd5-adf35e46190b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83875e46-e936-48fd-8e96-efa49423c0dd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fdc148e2-e39c-4e98-ae18-737e0b479d28"));

            migrationBuilder.DropColumn(
                name: "ProductImageId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductImages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("15bf195d-5fc7-4092-90f4-e47003ca4e0c"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("256bd4c2-9ff7-4cd8-a028-85b434240c04"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("27879027-0a3f-4d3f-a2cd-70fd4e734a6e"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("3919cd9b-633f-4c36-b3be-7ee1e8352103"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("49caec13-4056-49c7-a2d3-9ac227d37458"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("5c7a712c-a7d3-4bf6-8a87-3ddfd3c61619"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("8b9ea083-00b0-44c1-9a07-aa27e9ffd636"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("a1fdd632-13bf-4c3a-9eab-01e01ee3f561"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("a942cc32-4463-4a5a-82de-c5f261c499ee"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("cdb7b61d-7df6-44af-a541-923ebe9d59f1"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("d86b3724-7162-448b-a9dc-f3a59446f4b2"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "40ad1757-3a02-4494-9def-f1a43560b617", new DateTime(2025, 5, 20, 4, 21, 12, 93, DateTimeKind.Utc).AddTicks(6289), "AQAAAAIAAYagAAAAECQSMBD5UTG0yqVAeivCJBYnvDtH9vMNdFvlclvm5FjEF1FwHZ/e/MnImcLtfGQZMw==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("27879027-0a3f-4d3f-a2cd-70fd4e734a6e"),
                    new Guid("3919cd9b-633f-4c36-b3be-7ee1e8352103"),
                    new Guid("49caec13-4056-49c7-a2d3-9ac227d37458"),
                    new Guid("8b9ea083-00b0-44c1-9a07-aa27e9ffd636"),
                    new Guid("d86b3724-7162-448b-a9dc-f3a59446f4b2")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("a1fdd632-13bf-4c3a-9eab-01e01ee3f561"),
                    new Guid("cdb7b61d-7df6-44af-a541-923ebe9d59f1")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("15bf195d-5fc7-4092-90f4-e47003ca4e0c"),
                    new Guid("256bd4c2-9ff7-4cd8-a028-85b434240c04"),
                    new Guid("5c7a712c-a7d3-4bf6-8a87-3ddfd3c61619"),
                    new Guid("a942cc32-4463-4a5a-82de-c5f261c499ee")
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductItemId",
                table: "ProductImages");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("27879027-0a3f-4d3f-a2cd-70fd4e734a6e"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3919cd9b-633f-4c36-b3be-7ee1e8352103"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("49caec13-4056-49c7-a2d3-9ac227d37458"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b9ea083-00b0-44c1-9a07-aa27e9ffd636"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("d86b3724-7162-448b-a9dc-f3a59446f4b2"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1fdd632-13bf-4c3a-9eab-01e01ee3f561"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdb7b61d-7df6-44af-a541-923ebe9d59f1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("15bf195d-5fc7-4092-90f4-e47003ca4e0c"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("256bd4c2-9ff7-4cd8-a028-85b434240c04"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c7a712c-a7d3-4bf6-8a87-3ddfd3c61619"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("a942cc32-4463-4a5a-82de-c5f261c499ee"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("15bf195d-5fc7-4092-90f4-e47003ca4e0c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("256bd4c2-9ff7-4cd8-a028-85b434240c04"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("27879027-0a3f-4d3f-a2cd-70fd4e734a6e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3919cd9b-633f-4c36-b3be-7ee1e8352103"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("49caec13-4056-49c7-a2d3-9ac227d37458"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c7a712c-a7d3-4bf6-8a87-3ddfd3c61619"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b9ea083-00b0-44c1-9a07-aa27e9ffd636"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1fdd632-13bf-4c3a-9eab-01e01ee3f561"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a942cc32-4463-4a5a-82de-c5f261c499ee"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cdb7b61d-7df6-44af-a541-923ebe9d59f1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d86b3724-7162-448b-a9dc-f3a59446f4b2"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductImageId",
                table: "ProductItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ProductImages",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("04c1cf37-fd32-4df2-bd65-d686a7b4758f"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("06d58718-38dd-4509-8423-1506ac151451"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("1d5e5d5a-0953-4e8a-b811-495250c59f54"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("238f6ea5-0c16-4de8-95f0-dc506e1d976d"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("2b6ed63e-fc79-4823-987e-2a10d357e56b"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("33d95935-d7d0-4ab6-9954-81e0ae56ddd9"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("55084aae-0227-41ed-a38c-2235c92561d2"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("5f7bf7da-cee1-4feb-95d2-0fa06d0a05a7"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("6fb36102-e63e-4392-acd5-adf35e46190b"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("83875e46-e936-48fd-8e96-efa49423c0dd"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("fdc148e2-e39c-4e98-ae18-737e0b479d28"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "036cf9be-0cb3-4ba3-abe1-72ddf9382200", new DateTime(2025, 5, 19, 8, 20, 12, 281, DateTimeKind.Utc).AddTicks(2727), "AQAAAAIAAYagAAAAEDHoyzOEjsg15gebmbjdl5lDTtERd2wFxlyF39nLvkF17XR5S0QMmOJXvCxq5AoGUg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("238f6ea5-0c16-4de8-95f0-dc506e1d976d"),
                    new Guid("2b6ed63e-fc79-4823-987e-2a10d357e56b"),
                    new Guid("33d95935-d7d0-4ab6-9954-81e0ae56ddd9"),
                    new Guid("6fb36102-e63e-4392-acd5-adf35e46190b"),
                    new Guid("fdc148e2-e39c-4e98-ae18-737e0b479d28")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1d5e5d5a-0953-4e8a-b811-495250c59f54"),
                    new Guid("55084aae-0227-41ed-a38c-2235c92561d2")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("04c1cf37-fd32-4df2-bd65-d686a7b4758f"),
                    new Guid("06d58718-38dd-4509-8423-1506ac151451"),
                    new Guid("5f7bf7da-cee1-4feb-95d2-0fa06d0a05a7"),
                    new Guid("83875e46-e936-48fd-8e96-efa49423c0dd")
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
