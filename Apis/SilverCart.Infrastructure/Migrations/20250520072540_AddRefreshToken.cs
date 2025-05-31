using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("184c5703-bafc-4d46-ac45-8c43abd8397e"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("30dd3eb6-6ea4-4262-ba92-7992082a07e5"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("34ffb774-e96e-4c25-b0cf-cf40a8b9f1f0"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("63b756a3-279f-496c-91e0-1c1d19926160"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("81cfd08b-3af9-4288-99ff-abd1d74ab28f"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("987f3df8-72ec-49c0-a4d6-1a65bb2de6a4"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("ae367502-3f47-49f1-b3bf-2feed7f66efe"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("b6d665bb-d839-4688-bcfd-939c9236182e"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("c1a0a149-b5db-4b91-9c33-cdbad828da9e"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("c1e4e9fb-5066-4f16-9de9-59bdf6232e5f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("d2e130e3-af54-4490-88f2-82e930e32673"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("f19888bc-81c5-470c-a43c-e2bcdefe7f1d"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "RefreshToken" },
                values: new object[] { "d348f007-1072-46f9-90bc-f18caa1935f3", new DateTime(2025, 5, 20, 7, 25, 39, 442, DateTimeKind.Utc).AddTicks(736), "AQAAAAIAAYagAAAAEDY1V92Y14qw/39neyohO/5boC84xF5mylQA1JTJIa/coJclLCVL1DLoibU+AcsWLA==", null });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("987f3df8-72ec-49c0-a4d6-1a65bb2de6a4"),
                    new Guid("ae367502-3f47-49f1-b3bf-2feed7f66efe"),
                    new Guid("b6d665bb-d839-4688-bcfd-939c9236182e"),
                    new Guid("c1e4e9fb-5066-4f16-9de9-59bdf6232e5f"),
                    new Guid("f19888bc-81c5-470c-a43c-e2bcdefe7f1d")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("184c5703-bafc-4d46-ac45-8c43abd8397e"),
                    new Guid("30dd3eb6-6ea4-4262-ba92-7992082a07e5"),
                    new Guid("c1a0a149-b5db-4b91-9c33-cdbad828da9e")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("34ffb774-e96e-4c25-b0cf-cf40a8b9f1f0"),
                    new Guid("63b756a3-279f-496c-91e0-1c1d19926160"),
                    new Guid("81cfd08b-3af9-4288-99ff-abd1d74ab28f"),
                    new Guid("d2e130e3-af54-4490-88f2-82e930e32673")
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AdministratorUserId",
                table: "Addresses",
                column: "AdministratorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StoreUserId",
                table: "Addresses",
                column: "StoreUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AdministratorUsers_AdministratorUserId",
                table: "Addresses",
                column: "AdministratorUserId",
                principalTable: "AdministratorUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StoreUsers_StoreUserId",
                table: "Addresses",
                column: "StoreUserId",
                principalTable: "StoreUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AdministratorUsers_AdministratorUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StoreUsers_StoreUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AdministratorUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StoreUserId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("987f3df8-72ec-49c0-a4d6-1a65bb2de6a4"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae367502-3f47-49f1-b3bf-2feed7f66efe"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b6d665bb-d839-4688-bcfd-939c9236182e"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1e4e9fb-5066-4f16-9de9-59bdf6232e5f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("f19888bc-81c5-470c-a43c-e2bcdefe7f1d"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("184c5703-bafc-4d46-ac45-8c43abd8397e"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("30dd3eb6-6ea4-4262-ba92-7992082a07e5"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1a0a149-b5db-4b91-9c33-cdbad828da9e"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("34ffb774-e96e-4c25-b0cf-cf40a8b9f1f0"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("63b756a3-279f-496c-91e0-1c1d19926160"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("81cfd08b-3af9-4288-99ff-abd1d74ab28f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2e130e3-af54-4490-88f2-82e930e32673"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("184c5703-bafc-4d46-ac45-8c43abd8397e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("30dd3eb6-6ea4-4262-ba92-7992082a07e5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("34ffb774-e96e-4c25-b0cf-cf40a8b9f1f0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("63b756a3-279f-496c-91e0-1c1d19926160"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("81cfd08b-3af9-4288-99ff-abd1d74ab28f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("987f3df8-72ec-49c0-a4d6-1a65bb2de6a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae367502-3f47-49f1-b3bf-2feed7f66efe"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b6d665bb-d839-4688-bcfd-939c9236182e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1a0a149-b5db-4b91-9c33-cdbad828da9e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1e4e9fb-5066-4f16-9de9-59bdf6232e5f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2e130e3-af54-4490-88f2-82e930e32673"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f19888bc-81c5-470c-a43c-e2bcdefe7f1d"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdministratorUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StoreUserId",
                table: "Addresses");

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
        }
    }
}
