using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationBetweenStoreUserAndStore : Migration
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

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_Stores_StoreId",
                table: "StoreUsers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
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
    }
}
