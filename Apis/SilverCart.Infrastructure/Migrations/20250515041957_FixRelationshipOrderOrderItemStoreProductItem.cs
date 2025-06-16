using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationshipOrderOrderItemStoreProductItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ProductItems_ProductItemId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductItem_Orders_OrderId",
                table: "StoreProductItem");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductItem_Stores_StoreId",
                table: "StoreProductItem");

            migrationBuilder.DropIndex(
                name: "IX_StoreProductItem_OrderId",
                table: "StoreProductItem");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b222fc6-996c-4e7d-aa15-591a19b3513b"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("51985efe-7247-4c32-ab82-78ebcbe08514"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f216312-4baa-4a3b-a62d-716a4f6d7998"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("95d8fcb2-e0a6-4b07-9426-4829b4d496ac"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd64cdc8-4fda-4a0d-a6a2-1f716711f629"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd630d9f-b7b9-41e5-9b9c-9e9aee82378e"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff7ed986-8b22-4583-bd71-d98e5c96deee"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("9de669cf-d4ea-45bf-8f2f-382a5801a3fb"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c73e0a06-ca87-4e67-8e35-2a3964b0ad0b"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d974a44d-0d31-45aa-8b38-55c4aee8f850"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("f56bdf7f-5289-4835-b384-0402fe0b8080"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b222fc6-996c-4e7d-aa15-591a19b3513b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("51985efe-7247-4c32-ab82-78ebcbe08514"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f216312-4baa-4a3b-a62d-716a4f6d7998"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("95d8fcb2-e0a6-4b07-9426-4829b4d496ac"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9de669cf-d4ea-45bf-8f2f-382a5801a3fb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd630d9f-b7b9-41e5-9b9c-9e9aee82378e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c73e0a06-ca87-4e67-8e35-2a3964b0ad0b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d974a44d-0d31-45aa-8b38-55c4aee8f850"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dd64cdc8-4fda-4a0d-a6a2-1f716711f629"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f56bdf7f-5289-4835-b384-0402fe0b8080"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff7ed986-8b22-4583-bd71-d98e5c96deee"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "StoreProductItem");

            migrationBuilder.RenameColumn(
                name: "ProductItemId",
                table: "OrderItems",
                newName: "StoreProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductItemId",
                table: "OrderItems",
                newName: "IX_OrderItems_StoreProductItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "StoreProductItem",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("164979f8-eed3-4cc5-8a6b-6a2eed042ec0"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("277e87ad-c57c-492b-bb03-3599d47f5fa6"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("43c5fd08-5c37-431c-81d3-abe82192f410"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("4db3d749-633e-4f7b-91fe-923c199cc2e4"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("56976094-ed22-44bb-b288-5e470e29b849"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("610e2c21-b7f1-4cac-a6f5-585d498d0e7a"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("7710aec6-4b5d-4fa6-92c8-3562733684de"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("79faf54c-c9b7-4573-aeec-f758d91623c0"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("83ba848a-01e8-4e53-8d77-e2b22a9ecff9"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("8abc9e36-29e5-4856-bc90-ef616eac3135"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("ec42c064-4373-44cf-af7d-bdc00e5a65ff"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "7bc42112-16b8-4fa0-bc43-10b2d2074d3e", new DateTime(2025, 5, 15, 4, 19, 55, 330, DateTimeKind.Utc).AddTicks(1621), "AQAAAAIAAYagAAAAEEue+KZKc1a3WcErr7m5Dt9yjhaDO1R54FIr+fork5GyDgcyIcVwhJMW9b/F0U5HVA==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("164979f8-eed3-4cc5-8a6b-6a2eed042ec0"),
                    new Guid("56976094-ed22-44bb-b288-5e470e29b849"),
                    new Guid("610e2c21-b7f1-4cac-a6f5-585d498d0e7a"),
                    new Guid("7710aec6-4b5d-4fa6-92c8-3562733684de"),
                    new Guid("79faf54c-c9b7-4573-aeec-f758d91623c0")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("8abc9e36-29e5-4856-bc90-ef616eac3135"),
                    new Guid("ec42c064-4373-44cf-af7d-bdc00e5a65ff")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("277e87ad-c57c-492b-bb03-3599d47f5fa6"),
                    new Guid("43c5fd08-5c37-431c-81d3-abe82192f410"),
                    new Guid("4db3d749-633e-4f7b-91fe-923c199cc2e4"),
                    new Guid("83ba848a-01e8-4e53-8d77-e2b22a9ecff9")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_StoreProductItem_StoreProductItemId",
                table: "OrderItems",
                column: "StoreProductItemId",
                principalTable: "StoreProductItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductItem_Stores_StoreId",
                table: "StoreProductItem",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_StoreProductItem_StoreProductItemId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreProductItem_Stores_StoreId",
                table: "StoreProductItem");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("164979f8-eed3-4cc5-8a6b-6a2eed042ec0"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("56976094-ed22-44bb-b288-5e470e29b849"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("610e2c21-b7f1-4cac-a6f5-585d498d0e7a"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("7710aec6-4b5d-4fa6-92c8-3562733684de"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("79faf54c-c9b7-4573-aeec-f758d91623c0"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("8abc9e36-29e5-4856-bc90-ef616eac3135"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec42c064-4373-44cf-af7d-bdc00e5a65ff"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("277e87ad-c57c-492b-bb03-3599d47f5fa6"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("43c5fd08-5c37-431c-81d3-abe82192f410"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("4db3d749-633e-4f7b-91fe-923c199cc2e4"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("83ba848a-01e8-4e53-8d77-e2b22a9ecff9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("164979f8-eed3-4cc5-8a6b-6a2eed042ec0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("277e87ad-c57c-492b-bb03-3599d47f5fa6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43c5fd08-5c37-431c-81d3-abe82192f410"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4db3d749-633e-4f7b-91fe-923c199cc2e4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("56976094-ed22-44bb-b288-5e470e29b849"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("610e2c21-b7f1-4cac-a6f5-585d498d0e7a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7710aec6-4b5d-4fa6-92c8-3562733684de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("79faf54c-c9b7-4573-aeec-f758d91623c0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83ba848a-01e8-4e53-8d77-e2b22a9ecff9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8abc9e36-29e5-4856-bc90-ef616eac3135"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec42c064-4373-44cf-af7d-bdc00e5a65ff"));

            migrationBuilder.RenameColumn(
                name: "StoreProductItemId",
                table: "OrderItems",
                newName: "ProductItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_StoreProductItemId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductItemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "StoreProductItem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "StoreProductItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1b222fc6-996c-4e7d-aa15-591a19b3513b"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("51985efe-7247-4c32-ab82-78ebcbe08514"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("5f216312-4baa-4a3b-a62d-716a4f6d7998"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("95d8fcb2-e0a6-4b07-9426-4829b4d496ac"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("9de669cf-d4ea-45bf-8f2f-382a5801a3fb"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("bd630d9f-b7b9-41e5-9b9c-9e9aee82378e"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("c73e0a06-ca87-4e67-8e35-2a3964b0ad0b"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("d974a44d-0d31-45aa-8b38-55c4aee8f850"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("dd64cdc8-4fda-4a0d-a6a2-1f716711f629"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("f56bdf7f-5289-4835-b384-0402fe0b8080"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("ff7ed986-8b22-4583-bd71-d98e5c96deee"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "11d5604b-b99f-49aa-a85a-d40a170a5799", new DateTime(2025, 5, 14, 6, 25, 15, 905, DateTimeKind.Utc).AddTicks(8642), "AQAAAAIAAYagAAAAEDEW78sIekxtInlfvEdEPoJ59io9FA9JJHigfIZokZtyi9XzvdIgEFKu81Si+pL3Ww==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1b222fc6-996c-4e7d-aa15-591a19b3513b"),
                    new Guid("51985efe-7247-4c32-ab82-78ebcbe08514"),
                    new Guid("5f216312-4baa-4a3b-a62d-716a4f6d7998"),
                    new Guid("95d8fcb2-e0a6-4b07-9426-4829b4d496ac"),
                    new Guid("dd64cdc8-4fda-4a0d-a6a2-1f716711f629")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("bd630d9f-b7b9-41e5-9b9c-9e9aee82378e"),
                    new Guid("ff7ed986-8b22-4583-bd71-d98e5c96deee")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("9de669cf-d4ea-45bf-8f2f-382a5801a3fb"),
                    new Guid("c73e0a06-ca87-4e67-8e35-2a3964b0ad0b"),
                    new Guid("d974a44d-0d31-45aa-8b38-55c4aee8f850"),
                    new Guid("f56bdf7f-5289-4835-b384-0402fe0b8080")
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreProductItem_OrderId",
                table: "StoreProductItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ProductItems_ProductItemId",
                table: "OrderItems",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductItem_Orders_OrderId",
                table: "StoreProductItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProductItem_Stores_StoreId",
                table: "StoreProductItem",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
