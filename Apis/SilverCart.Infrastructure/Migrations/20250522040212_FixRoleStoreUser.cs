using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixRoleStoreUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_AspNetUsers_UserId",
                table: "StoreUsers");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("062b123d-945f-45cb-9b5a-bb6ed559175c"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("7014bc9f-793a-4741-85a6-c6ba4c233a26"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("857dc733-6ce7-4e02-96e4-164caf9c5499"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b5ecff3e-d434-4a9b-b5d6-cc077d2fb862"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("d8de2667-3e4c-48ee-ab18-e54828fdc9b8"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d4b2437-a767-4bee-a5ca-2d80eee75060"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ac37188-0e64-4ea6-b5ce-d87517228615"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef0f6c5c-262c-4cfd-b3bb-3ccb3b818301"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("3754d19a-97dd-4745-9438-35cba29f7bc4"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("6942b432-a7f5-4ca4-ab08-8d353f507adb"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5e7ee51-5b0e-4eab-b2b2-37b982879d49"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("fcf73fe8-c07e-48b9-b33f-37c487ebb217"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("062b123d-945f-45cb-9b5a-bb6ed559175c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3754d19a-97dd-4745-9438-35cba29f7bc4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d4b2437-a767-4bee-a5ca-2d80eee75060"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6942b432-a7f5-4ca4-ab08-8d353f507adb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7014bc9f-793a-4741-85a6-c6ba4c233a26"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ac37188-0e64-4ea6-b5ce-d87517228615"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("857dc733-6ce7-4e02-96e4-164caf9c5499"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b5ecff3e-d434-4a9b-b5d6-cc077d2fb862"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c5e7ee51-5b0e-4eab-b2b2-37b982879d49"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d8de2667-3e4c-48ee-ab18-e54828fdc9b8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef0f6c5c-262c-4cfd-b3bb-3ccb3b818301"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fcf73fe8-c07e-48b9-b33f-37c487ebb217"));

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "RoleInStore",
                table: "StoreUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "StoreUsers",
                newName: "BaseUserId");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "StoreUsers",
                newName: "OTP_ExpirationTime");

            migrationBuilder.RenameIndex(
                name: "IX_StoreUsers_UserId",
                table: "StoreUsers",
                newName: "IX_StoreUsers_BaseUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StoreUsers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OTP_ExpirationTime",
                table: "StoreUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<string>(
                name: "OTP_Code",
                table: "StoreUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OTP_IsUsed",
                table: "StoreUsers",
                type: "boolean",
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

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StoreUserId",
                table: "Addresses",
                column: "StoreUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StoreUsers_StoreUserId",
                table: "Addresses",
                column: "StoreUserId",
                principalTable: "StoreUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_AspNetUsers_BaseUserId",
                table: "StoreUsers",
                column: "BaseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_AspNetUsers_Id",
                table: "StoreUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StoreUsers_StoreUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_AspNetUsers_BaseUserId",
                table: "StoreUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_AspNetUsers_Id",
                table: "StoreUsers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StoreUserId",
                table: "Addresses");

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

            migrationBuilder.DropColumn(
                name: "OTP_Code",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "OTP_IsUsed",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "StoreUserId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "OTP_ExpirationTime",
                table: "StoreUsers",
                newName: "ModificationDate");

            migrationBuilder.RenameColumn(
                name: "BaseUserId",
                table: "StoreUsers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreUsers_BaseUserId",
                table: "StoreUsers",
                newName: "IX_StoreUsers_UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StoreUsers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StoreUsers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StoreUsers",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StoreUsers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreUsers",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoreUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StoreUsers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<int>(
                name: "RoleInStore",
                table: "StoreUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("062b123d-945f-45cb-9b5a-bb6ed559175c"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("3754d19a-97dd-4745-9438-35cba29f7bc4"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("3d4b2437-a767-4bee-a5ca-2d80eee75060"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("6942b432-a7f5-4ca4-ab08-8d353f507adb"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("7014bc9f-793a-4741-85a6-c6ba4c233a26"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("7ac37188-0e64-4ea6-b5ce-d87517228615"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("857dc733-6ce7-4e02-96e4-164caf9c5499"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("b5ecff3e-d434-4a9b-b5d6-cc077d2fb862"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("c5e7ee51-5b0e-4eab-b2b2-37b982879d49"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("d8de2667-3e4c-48ee-ab18-e54828fdc9b8"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("ef0f6c5c-262c-4cfd-b3bb-3ccb3b818301"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("fcf73fe8-c07e-48b9-b33f-37c487ebb217"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "95aedf20-149c-4a69-bc94-ded282acc449", new DateTime(2025, 5, 21, 4, 55, 26, 486, DateTimeKind.Utc).AddTicks(5409), "AQAAAAIAAYagAAAAEB858685p9M6X8VlmmHs3uHZP0GwNHgpMWWacTZ7mitqi8mXmOohMgGsns/fNooRpQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("062b123d-945f-45cb-9b5a-bb6ed559175c"),
                    new Guid("7014bc9f-793a-4741-85a6-c6ba4c233a26"),
                    new Guid("857dc733-6ce7-4e02-96e4-164caf9c5499"),
                    new Guid("b5ecff3e-d434-4a9b-b5d6-cc077d2fb862"),
                    new Guid("d8de2667-3e4c-48ee-ab18-e54828fdc9b8")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3d4b2437-a767-4bee-a5ca-2d80eee75060"),
                    new Guid("7ac37188-0e64-4ea6-b5ce-d87517228615"),
                    new Guid("ef0f6c5c-262c-4cfd-b3bb-3ccb3b818301")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3754d19a-97dd-4745-9438-35cba29f7bc4"),
                    new Guid("6942b432-a7f5-4ca4-ab08-8d353f507adb"),
                    new Guid("c5e7ee51-5b0e-4eab-b2b2-37b982879d49"),
                    new Guid("fcf73fe8-c07e-48b9-b33f-37c487ebb217")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_AspNetUsers_UserId",
                table: "StoreUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
