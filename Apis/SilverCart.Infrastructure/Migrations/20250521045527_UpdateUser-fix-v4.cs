using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserfixv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreAddress_StoreAddressId",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreAddress",
                table: "StoreAddress");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("181a5ea7-ed88-40b2-bb1d-ea7ec2733d02"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3440d377-6763-4710-92c6-c8a59b3686fc"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f574761-4cd2-4546-be59-9f7626f52e4f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("d12dbad8-8451-44cc-871a-df24c6e34b76"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef554548-b8b6-4a99-868c-570e60f8f294"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("04dc7a5b-bc12-45d8-b60e-74ffb5fe6293"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("4528dec9-5c3b-417c-9020-faa717abdc78"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf41eefa-93be-4e44-a7f3-19f156bb9473"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("68696b80-0ce8-47db-b715-d2165a996500"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("b669f69e-1b76-4e86-9b37-2fe97779cc6f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("b806966b-ad6c-402f-a102-b0e1539c5bcd"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9cba236-47dc-4aaf-ba25-686eec0d95fc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04dc7a5b-bc12-45d8-b60e-74ffb5fe6293"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("181a5ea7-ed88-40b2-bb1d-ea7ec2733d02"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3440d377-6763-4710-92c6-c8a59b3686fc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f574761-4cd2-4546-be59-9f7626f52e4f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4528dec9-5c3b-417c-9020-faa717abdc78"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("68696b80-0ce8-47db-b715-d2165a996500"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b669f69e-1b76-4e86-9b37-2fe97779cc6f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b806966b-ad6c-402f-a102-b0e1539c5bcd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cf41eefa-93be-4e44-a7f3-19f156bb9473"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d12dbad8-8451-44cc-871a-df24c6e34b76"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e9cba236-47dc-4aaf-ba25-686eec0d95fc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef554548-b8b6-4a99-868c-570e60f8f294"));

            migrationBuilder.RenameTable(
                name: "StoreAddress",
                newName: "StoreAddresses");

            migrationBuilder.AddColumn<Guid>(
                name: "DependentUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuardianUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreAddresses",
                table: "StoreAddresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GuardianUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OTP_Code = table.Column<string>(type: "text", nullable: true),
                    OTP_ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OTP_IsUsed = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardianUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuardianUsers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DependentUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GuardianId = table.Column<Guid>(type: "uuid", nullable: false),
                    OTP_Code = table.Column<string>(type: "text", nullable: true),
                    OTP_ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OTP_IsUsed = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependentUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependentUsers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DependentUsers_GuardianUsers_GuardianId",
                        column: x => x.GuardianId,
                        principalTable: "GuardianUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DependentUserId",
                table: "Addresses",
                column: "DependentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_GuardianUserId",
                table: "Addresses",
                column: "GuardianUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DependentUsers_GuardianId",
                table: "DependentUsers",
                column: "GuardianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_DependentUsers_DependentUserId",
                table: "Addresses",
                column: "DependentUserId",
                principalTable: "DependentUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_GuardianUsers_GuardianUserId",
                table: "Addresses",
                column: "GuardianUserId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreAddresses_StoreAddressId",
                table: "Stores",
                column: "StoreAddressId",
                principalTable: "StoreAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_DependentUsers_DependentUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_GuardianUsers_GuardianUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreAddresses_StoreAddressId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "DependentUsers");

            migrationBuilder.DropTable(
                name: "GuardianUsers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DependentUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_GuardianUserId",
                table: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreAddresses",
                table: "StoreAddresses");

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
                name: "DependentUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "GuardianUserId",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "StoreAddresses",
                newName: "StoreAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreAddress",
                table: "StoreAddress",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("04dc7a5b-bc12-45d8-b60e-74ffb5fe6293"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("181a5ea7-ed88-40b2-bb1d-ea7ec2733d02"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("3440d377-6763-4710-92c6-c8a59b3686fc"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("3f574761-4cd2-4546-be59-9f7626f52e4f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("4528dec9-5c3b-417c-9020-faa717abdc78"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("68696b80-0ce8-47db-b715-d2165a996500"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("b669f69e-1b76-4e86-9b37-2fe97779cc6f"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("b806966b-ad6c-402f-a102-b0e1539c5bcd"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("cf41eefa-93be-4e44-a7f3-19f156bb9473"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("d12dbad8-8451-44cc-871a-df24c6e34b76"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("e9cba236-47dc-4aaf-ba25-686eec0d95fc"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("ef554548-b8b6-4a99-868c-570e60f8f294"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "b322853e-724c-4405-9119-788875b90fe9", new DateTime(2025, 5, 21, 4, 44, 30, 802, DateTimeKind.Utc).AddTicks(642), "AQAAAAIAAYagAAAAECd878vTL6m/BtGU5ESQbbr0WBfts0hJ+kwKDs0RPAc3SNpODhJtwCNYdsSKguuN6A==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("181a5ea7-ed88-40b2-bb1d-ea7ec2733d02"),
                    new Guid("3440d377-6763-4710-92c6-c8a59b3686fc"),
                    new Guid("3f574761-4cd2-4546-be59-9f7626f52e4f"),
                    new Guid("d12dbad8-8451-44cc-871a-df24c6e34b76"),
                    new Guid("ef554548-b8b6-4a99-868c-570e60f8f294")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("04dc7a5b-bc12-45d8-b60e-74ffb5fe6293"),
                    new Guid("4528dec9-5c3b-417c-9020-faa717abdc78"),
                    new Guid("cf41eefa-93be-4e44-a7f3-19f156bb9473")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("68696b80-0ce8-47db-b715-d2165a996500"),
                    new Guid("b669f69e-1b76-4e86-9b37-2fe97779cc6f"),
                    new Guid("b806966b-ad6c-402f-a102-b0e1539c5bcd"),
                    new Guid("e9cba236-47dc-4aaf-ba25-686eec0d95fc")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreAddress_StoreAddressId",
                table: "Stores",
                column: "StoreAddressId",
                principalTable: "StoreAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
