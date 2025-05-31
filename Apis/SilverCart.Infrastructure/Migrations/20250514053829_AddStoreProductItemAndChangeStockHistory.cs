using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreProductItemAndChangeStockHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_Products_ProductId",
                table: "StockHistories");

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

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "ProductItems");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "StockHistories",
                newName: "StockAfterChange");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "StockHistories",
                newName: "StoreProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistories_ProductId",
                table: "StockHistories",
                newName: "IX_StockHistories_StoreProductItemId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StockHistories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "QuantityChange",
                table: "StockHistories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "StockHistories",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StoreProductItem",
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
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProductItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreProductItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreProductItem_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProductItem_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductItem_OrderId",
                table: "StoreProductItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductItem_ProductItemId",
                table: "StoreProductItem",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductItem_StoreId",
                table: "StoreProductItem",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_StoreProductItem_StoreProductItemId",
                table: "StockHistories",
                column: "StoreProductItemId",
                principalTable: "StoreProductItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_StoreProductItem_StoreProductItemId",
                table: "StockHistories");

            migrationBuilder.DropTable(
                name: "StoreProductItem");

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

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "QuantityChange",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "StockHistories");

            migrationBuilder.RenameColumn(
                name: "StoreProductItemId",
                table: "StockHistories",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "StockAfterChange",
                table: "StockHistories",
                newName: "Quantity");

            migrationBuilder.RenameIndex(
                name: "IX_StockHistories_StoreProductItemId",
                table: "StockHistories",
                newName: "IX_StockHistories_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "ProductItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_Products_ProductId",
                table: "StockHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
