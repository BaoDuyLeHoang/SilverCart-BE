using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Message : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ec7dfe8-7dcb-4b53-88ae-67d826fecf33"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("43d06ded-8d71-4a5e-b636-ab20d222bd8f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ce66f1e-9b76-4157-8de4-92ca82f8c797"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("f54e938d-33f8-4ee5-8aa3-9a7dde934cd7"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8cf01a7-85f7-467d-a13a-a1719a998707"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("3b0556eb-e009-423d-86ab-6782fade20b6"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("616fb0dd-6473-4954-a5d3-1033a0779061"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("b159331d-9cbc-481a-bc14-47dc6455100c"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e6dad34-16f4-49ee-ad00-c26739276f07"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c256f111-e373-4355-9e0c-54974c72d264"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c9151381-ff87-4688-bcb6-e170eed79276"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1029f34-cdf8-4319-b48a-4aa629012e2b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ec7dfe8-7dcb-4b53-88ae-67d826fecf33"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3b0556eb-e009-423d-86ab-6782fade20b6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e6dad34-16f4-49ee-ad00-c26739276f07"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43d06ded-8d71-4a5e-b636-ab20d222bd8f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("616fb0dd-6473-4954-a5d3-1033a0779061"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ce66f1e-9b76-4157-8de4-92ca82f8c797"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b159331d-9cbc-481a-bc14-47dc6455100c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c256f111-e373-4355-9e0c-54974c72d264"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c9151381-ff87-4688-bcb6-e170eed79276"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e1029f34-cdf8-4319-b48a-4aa629012e2b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f54e938d-33f8-4ee5-8aa3-9a7dde934cd7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8cf01a7-85f7-467d-a13a-a1719a998707"));

            migrationBuilder.CreateTable(
                name: "Conversations",
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
                    User1Id = table.Column<Guid>(type: "uuid", nullable: false),
                    User2Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastMessageAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversations_AspNetUsers_User1Id",
                        column: x => x.User1Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conversations_AspNetUsers_User2Id",
                        column: x => x.User2Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
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
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    IsModified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_User1Id",
                table: "Conversations",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_User2Id",
                table: "Conversations",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Conversations");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1ec7dfe8-7dcb-4b53-88ae-67d826fecf33"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("3b0556eb-e009-423d-86ab-6782fade20b6"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("3e6dad34-16f4-49ee-ad00-c26739276f07"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" },
                    { new Guid("43d06ded-8d71-4a5e-b636-ab20d222bd8f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("616fb0dd-6473-4954-a5d3-1033a0779061"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("7ce66f1e-9b76-4157-8de4-92ca82f8c797"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("b159331d-9cbc-481a-bc14-47dc6455100c"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("c256f111-e373-4355-9e0c-54974c72d264"), null, null, null, null, null, "", false, null, null, "StoreDelivery", "STOREDELIVERY" },
                    { new Guid("c9151381-ff87-4688-bcb6-e170eed79276"), null, null, null, null, null, "", false, null, null, "StoreManager", "STOREMANAGER" },
                    { new Guid("e1029f34-cdf8-4319-b48a-4aa629012e2b"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" },
                    { new Guid("f54e938d-33f8-4ee5-8aa3-9a7dde934cd7"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("f8cf01a7-85f7-467d-a13a-a1719a998707"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "1f71838a-5cc6-41b3-9f09-b80344b2ac6c", new DateTime(2025, 5, 22, 4, 2, 11, 262, DateTimeKind.Utc).AddTicks(153), "AQAAAAIAAYagAAAAEGFKyKg8ipLdx1ezU+YZwvP7ABOo/AS2nTmZvQ1RtjkHW4SuXOeO5t7KLpfKxMt7yg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1ec7dfe8-7dcb-4b53-88ae-67d826fecf33"),
                    new Guid("43d06ded-8d71-4a5e-b636-ab20d222bd8f"),
                    new Guid("7ce66f1e-9b76-4157-8de4-92ca82f8c797"),
                    new Guid("f54e938d-33f8-4ee5-8aa3-9a7dde934cd7"),
                    new Guid("f8cf01a7-85f7-467d-a13a-a1719a998707")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3b0556eb-e009-423d-86ab-6782fade20b6"),
                    new Guid("616fb0dd-6473-4954-a5d3-1033a0779061"),
                    new Guid("b159331d-9cbc-481a-bc14-47dc6455100c")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3e6dad34-16f4-49ee-ad00-c26739276f07"),
                    new Guid("c256f111-e373-4355-9e0c-54974c72d264"),
                    new Guid("c9151381-ff87-4688-bcb6-e170eed79276"),
                    new Guid("e1029f34-cdf8-4319-b48a-4aa629012e2b")
                });
        }
    }
}
