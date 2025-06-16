using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCategoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<byte>(
                name: "ProductType",
                table: "Products",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModificationById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteById = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1a7461d3-ad5d-489b-8f35-9a67419f17b1"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("33be795c-7dd1-44f0-bfea-60cbe5629277"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("3931b998-d85d-4d93-92c3-74e3fe603e72"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("47fe9491-00ef-49f5-8afd-3e5bfe8e7c20"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("5af2b915-e8f6-4199-8a9b-c184b47e7e42"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("69e96dc6-6bbc-483d-9797-61f744e9a56f"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("a2e93cbd-9145-44b8-9672-c8a3616ad0ff"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("b869968f-29af-4d52-9bd7-7145b19ac6da"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("f1b57c92-b076-418b-86e0-08adec2e4308"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("f74f63a2-2159-4f72-aa1e-0ec554840f12"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("ff5b339a-d64c-48cd-9787-cef1c6232861"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "dfa9e1c4-5098-4285-86b4-9e535fc2ab68", new DateTime(2025, 5, 14, 4, 5, 12, 459, DateTimeKind.Utc).AddTicks(4946), "AQAAAAIAAYagAAAAEN2JKURIIH+ah/b5cnYAaHr3moYWJmFurQWl+rxK6W0L30mHPde00+TMJuS6SZaNig==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("47fe9491-00ef-49f5-8afd-3e5bfe8e7c20"),
                    new Guid("69e96dc6-6bbc-483d-9797-61f744e9a56f"),
                    new Guid("b869968f-29af-4d52-9bd7-7145b19ac6da"),
                    new Guid("f74f63a2-2159-4f72-aa1e-0ec554840f12"),
                    new Guid("ff5b339a-d64c-48cd-9787-cef1c6232861")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1a7461d3-ad5d-489b-8f35-9a67419f17b1"),
                    new Guid("a2e93cbd-9145-44b8-9672-c8a3616ad0ff")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("33be795c-7dd1-44f0-bfea-60cbe5629277"),
                    new Guid("3931b998-d85d-4d93-92c3-74e3fe603e72"),
                    new Guid("5af2b915-e8f6-4199-8a9b-c184b47e7e42"),
                    new Guid("f1b57c92-b076-418b-86e0-08adec2e4308")
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategory",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("47fe9491-00ef-49f5-8afd-3e5bfe8e7c20"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("69e96dc6-6bbc-483d-9797-61f744e9a56f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b869968f-29af-4d52-9bd7-7145b19ac6da"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("f74f63a2-2159-4f72-aa1e-0ec554840f12"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff5b339a-d64c-48cd-9787-cef1c6232861"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a7461d3-ad5d-489b-8f35-9a67419f17b1"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2e93cbd-9145-44b8-9672-c8a3616ad0ff"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("33be795c-7dd1-44f0-bfea-60cbe5629277"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("3931b998-d85d-4d93-92c3-74e3fe603e72"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5af2b915-e8f6-4199-8a9b-c184b47e7e42"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("f1b57c92-b076-418b-86e0-08adec2e4308"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a7461d3-ad5d-489b-8f35-9a67419f17b1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33be795c-7dd1-44f0-bfea-60cbe5629277"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3931b998-d85d-4d93-92c3-74e3fe603e72"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("47fe9491-00ef-49f5-8afd-3e5bfe8e7c20"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5af2b915-e8f6-4199-8a9b-c184b47e7e42"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("69e96dc6-6bbc-483d-9797-61f744e9a56f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2e93cbd-9145-44b8-9672-c8a3616ad0ff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b869968f-29af-4d52-9bd7-7145b19ac6da"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f1b57c92-b076-418b-86e0-08adec2e4308"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f74f63a2-2159-4f72-aa1e-0ec554840f12"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff5b339a-d64c-48cd-9787-cef1c6232861"));

            migrationBuilder.AlterColumn<int>(
                name: "ProductType",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
