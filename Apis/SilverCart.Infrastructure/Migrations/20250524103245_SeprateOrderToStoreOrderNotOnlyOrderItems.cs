using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class SeprateOrderToStoreOrderNotOnlyOrderItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fa74de2-9662-435b-9851-56776ff98873"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("78828fde-cf55-468c-8423-bea8880500dc"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e1f4fc7-db40-4293-b7a9-b228f104e1d9"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("958f3b3d-859c-42bd-8bfe-989ac2210483"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6f4a4f5-6f79-44cf-8454-d97ecc40993a"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("456aa3d8-c691-451d-bb91-17ae27c2530d"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("e647168f-e981-490e-8487-8cdfd1946a74"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8547848-ca21-493e-a4f4-87261aa7622e"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a6b1c44-99b1-48d4-8257-0bced580c648"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("bfb0d6fe-9094-43aa-838d-734ea1a98f2e"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("cebac1e1-60fe-4220-92bc-c76440d493dc"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffb57f28-fce3-44c0-a662-7ff233d1b520"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0fa74de2-9662-435b-9851-56776ff98873"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("456aa3d8-c691-451d-bb91-17ae27c2530d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a6b1c44-99b1-48d4-8257-0bced580c648"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("78828fde-cf55-468c-8423-bea8880500dc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e1f4fc7-db40-4293-b7a9-b228f104e1d9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("958f3b3d-859c-42bd-8bfe-989ac2210483"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bfb0d6fe-9094-43aa-838d-734ea1a98f2e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cebac1e1-60fe-4220-92bc-c76440d493dc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e647168f-e981-490e-8487-8cdfd1946a74"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6f4a4f5-6f79-44cf-8454-d97ecc40993a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8547848-ca21-493e-a4f4-87261aa7622e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ffb57f28-fce3-44c0-a662-7ff233d1b520"));

            migrationBuilder.DropColumn(
                name: "ArrivedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeadlineDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EstimatedArrivedDate",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "StoreOrder",
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
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingStatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreOrder_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreProductItemsOrder",
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
                    StoreProductItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreOrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProductItemsOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreProductItemsOrder_StoreOrder_StoreOrderId",
                        column: x => x.StoreOrderId,
                        principalTable: "StoreOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProductItemsOrder_StoreProductItem_StoreProductItemId",
                        column: x => x.StoreProductItemId,
                        principalTable: "StoreProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1da37fba-8e6b-49e2-8ed4-74718c64ed59"), null, null, null, null, null, "", false, null, null, "StoreDelivery", "STOREDELIVERY" },
                    { new Guid("2bff9e12-ee15-4335-babb-d2ecb16d0c60"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" },
                    { new Guid("5c584796-2a86-4f4c-ad19-e59a58092c46"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("6375006b-115b-4857-a883-8d50b191da63"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("6764415b-9fe0-4730-9b8e-6996751099fc"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("68aaaac4-8091-4b4f-abc2-b37581d67e78"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("736167d0-84b3-4a1e-a379-ea4c05cc627b"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("8051ac7b-9543-4d1d-82bc-ed7faeba6dd0"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("8dfd99b9-fcd9-4dc4-85d1-0daf30ac307b"), null, null, null, null, null, "", false, null, null, "StoreManager", "STOREMANAGER" },
                    { new Guid("8e02f126-e9e8-43df-8fd5-2942288f8619"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("c9f8a2a3-be0e-4412-a6d2-a66d0e9a5b6e"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" },
                    { new Guid("cc17f47c-5f0f-4930-913e-b83dd8a9f8b4"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "a4343cdf-467a-4cb7-afcb-971d04aec88f", new DateTime(2025, 5, 24, 10, 32, 44, 259, DateTimeKind.Utc).AddTicks(7954), "AQAAAAIAAYagAAAAEMrIFP+Ph04PgobXsYrVLYdsg8QnLDuY+5g4bImcxTBxva+x2TPg8tm/bGaKKlSiCA==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("5c584796-2a86-4f4c-ad19-e59a58092c46"),
                    new Guid("6375006b-115b-4857-a883-8d50b191da63"),
                    new Guid("68aaaac4-8091-4b4f-abc2-b37581d67e78"),
                    new Guid("8051ac7b-9543-4d1d-82bc-ed7faeba6dd0"),
                    new Guid("cc17f47c-5f0f-4930-913e-b83dd8a9f8b4")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("6764415b-9fe0-4730-9b8e-6996751099fc"),
                    new Guid("736167d0-84b3-4a1e-a379-ea4c05cc627b"),
                    new Guid("8e02f126-e9e8-43df-8fd5-2942288f8619")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1da37fba-8e6b-49e2-8ed4-74718c64ed59"),
                    new Guid("2bff9e12-ee15-4335-babb-d2ecb16d0c60"),
                    new Guid("8dfd99b9-fcd9-4dc4-85d1-0daf30ac307b"),
                    new Guid("c9f8a2a3-be0e-4412-a6d2-a66d0e9a5b6e")
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrder_OrderId",
                table: "StoreOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreOrder_StoreId",
                table: "StoreOrder",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductItemsOrder_StoreOrderId",
                table: "StoreProductItemsOrder",
                column: "StoreOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductItemsOrder_StoreProductItemId",
                table: "StoreProductItemsOrder",
                column: "StoreProductItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreProductItemsOrder");

            migrationBuilder.DropTable(
                name: "StoreOrder");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c584796-2a86-4f4c-ad19-e59a58092c46"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("6375006b-115b-4857-a883-8d50b191da63"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("68aaaac4-8091-4b4f-abc2-b37581d67e78"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8051ac7b-9543-4d1d-82bc-ed7faeba6dd0"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc17f47c-5f0f-4930-913e-b83dd8a9f8b4"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("6764415b-9fe0-4730-9b8e-6996751099fc"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("736167d0-84b3-4a1e-a379-ea4c05cc627b"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e02f126-e9e8-43df-8fd5-2942288f8619"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("1da37fba-8e6b-49e2-8ed4-74718c64ed59"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("2bff9e12-ee15-4335-babb-d2ecb16d0c60"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dfd99b9-fcd9-4dc4-85d1-0daf30ac307b"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c9f8a2a3-be0e-4412-a6d2-a66d0e9a5b6e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1da37fba-8e6b-49e2-8ed4-74718c64ed59"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2bff9e12-ee15-4335-babb-d2ecb16d0c60"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c584796-2a86-4f4c-ad19-e59a58092c46"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6375006b-115b-4857-a883-8d50b191da63"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6764415b-9fe0-4730-9b8e-6996751099fc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68aaaac4-8091-4b4f-abc2-b37581d67e78"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("736167d0-84b3-4a1e-a379-ea4c05cc627b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8051ac7b-9543-4d1d-82bc-ed7faeba6dd0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8dfd99b9-fcd9-4dc4-85d1-0daf30ac307b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8e02f126-e9e8-43df-8fd5-2942288f8619"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c9f8a2a3-be0e-4412-a6d2-a66d0e9a5b6e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc17f47c-5f0f-4930-913e-b83dd8a9f8b4"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivedDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeadlineDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedArrivedDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0fa74de2-9662-435b-9851-56776ff98873"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("456aa3d8-c691-451d-bb91-17ae27c2530d"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("5a6b1c44-99b1-48d4-8257-0bced580c648"), null, null, null, null, null, "", false, null, null, "StoreManager", "STOREMANAGER" },
                    { new Guid("78828fde-cf55-468c-8423-bea8880500dc"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("8e1f4fc7-db40-4293-b7a9-b228f104e1d9"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("958f3b3d-859c-42bd-8bfe-989ac2210483"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("bfb0d6fe-9094-43aa-838d-734ea1a98f2e"), null, null, null, null, null, "", false, null, null, "StoreDelivery", "STOREDELIVERY" },
                    { new Guid("cebac1e1-60fe-4220-92bc-c76440d493dc"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" },
                    { new Guid("e647168f-e981-490e-8487-8cdfd1946a74"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("e6f4a4f5-6f79-44cf-8454-d97ecc40993a"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("f8547848-ca21-493e-a4f4-87261aa7622e"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("ffb57f28-fce3-44c0-a662-7ff233d1b520"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "b0410969-ca8b-4f0d-bdf1-0faa67d5116d", new DateTime(2025, 5, 23, 10, 40, 16, 485, DateTimeKind.Utc).AddTicks(3926), "AQAAAAIAAYagAAAAECN+9mN0scbsM308bqmlvAysLA0iepUP0UXKwoOHyyoR2W1vpkJXEqFBIL1KdEZJYg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0fa74de2-9662-435b-9851-56776ff98873"),
                    new Guid("78828fde-cf55-468c-8423-bea8880500dc"),
                    new Guid("8e1f4fc7-db40-4293-b7a9-b228f104e1d9"),
                    new Guid("958f3b3d-859c-42bd-8bfe-989ac2210483"),
                    new Guid("e6f4a4f5-6f79-44cf-8454-d97ecc40993a")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("456aa3d8-c691-451d-bb91-17ae27c2530d"),
                    new Guid("e647168f-e981-490e-8487-8cdfd1946a74"),
                    new Guid("f8547848-ca21-493e-a4f4-87261aa7622e")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("5a6b1c44-99b1-48d4-8257-0bced580c648"),
                    new Guid("bfb0d6fe-9094-43aa-838d-734ea1a98f2e"),
                    new Guid("cebac1e1-60fe-4220-92bc-c76440d493dc"),
                    new Guid("ffb57f28-fce3-44c0-a662-7ff233d1b520")
                });
        }
    }
}
