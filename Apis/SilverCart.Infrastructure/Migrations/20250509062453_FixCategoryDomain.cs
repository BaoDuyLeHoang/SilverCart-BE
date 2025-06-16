using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixCategoryDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AdministratorUsers_ApprovedUserId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("2511cad8-b5df-407c-9ce8-6c67274920a1"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d48cdf9-328c-4ea4-a116-b6c9eb8590b2"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("77c3c3e7-a21d-4036-8f83-3e61bdc2117b"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ba895e6-8c64-4230-ba10-ee65245f18fd"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5501a68-21a0-43c1-b256-8a9bd2c3cc60"));

            migrationBuilder.DeleteData(
                table: "AdministratorUsers",
                keyColumn: "Id",
                keyValue: new Guid("eb2cd484-46e6-4052-b28a-a58ed782d2e1"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("2aeb4405-aca7-4aa1-9322-d74c3e4a4f33"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("fbfa4d88-d271-4165-9b8c-3f85878e372d"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("0cca4fbb-79e2-4d11-9a00-3918144346b3"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("2ed48fad-01c7-4929-ae2f-85d32c898fef"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("7425fb83-a4d5-4b72-ae95-a65b7cbd95f7"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf7d2d46-1ae3-43a1-adf3-eff29546a6d5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0cca4fbb-79e2-4d11-9a00-3918144346b3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2511cad8-b5df-407c-9ce8-6c67274920a1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2aeb4405-aca7-4aa1-9322-d74c3e4a4f33"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2ed48fad-01c7-4929-ae2f-85d32c898fef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d48cdf9-328c-4ea4-a116-b6c9eb8590b2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7425fb83-a4d5-4b72-ae95-a65b7cbd95f7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77c3c3e7-a21d-4036-8f83-3e61bdc2117b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ba895e6-8c64-4230-ba10-ee65245f18fd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bf7d2d46-1ae3-43a1-adf3-eff29546a6d5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5501a68-21a0-43c1-b256-8a9bd2c3cc60"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fbfa4d88-d271-4165-9b8c-3f85878e372d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eb2cd484-46e6-4052-b28a-a58ed782d2e1"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovedUserId",
                table: "Categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovedById",
                table: "Categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("020c2d2c-7b6f-420b-88dd-74e93391a70d"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("3444d9f0-de44-4d4d-ba74-ddabd16f2628"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("41f45d10-5c2d-47ee-8be8-584fe85e4670"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("521c913a-8ca6-4c6c-87a3-04ce55d16ff6"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("5cca8407-6756-44a2-abc2-badc9f9f66db"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("7f7654d0-dedd-4deb-ab67-6ed475903598"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("98702079-0820-4d2a-a518-0ff65c9abeb7"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("b50a6a3f-e589-4757-a139-933b8837a11d"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("d2cdf8bb-310c-4a1e-ae48-e05dc1ef0221"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("d7df3caa-346d-420a-b722-c73cf82e4bb7"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("df4fd32f-4057-4888-9347-e67b89564fe3"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModificationById", "ModificationDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"), 0, "28fd18c9-aa5d-405f-8443-049e6ef9e220", null, new DateTime(2025, 5, 9, 6, 24, 52, 852, DateTimeKind.Utc).AddTicks(9056), null, null, "admin@elderly.com", true, "Super Admin", false, false, null, null, null, "ADMIN@ELDERLY.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEMR4c7Dw8l+30GdQjOIa5md6EZoYbi91iOW5KY/lcHF8t/CEBtUJguOP00nnvYHkPQ==", null, false, null, false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3444d9f0-de44-4d4d-ba74-ddabd16f2628"),
                    new Guid("41f45d10-5c2d-47ee-8be8-584fe85e4670"),
                    new Guid("521c913a-8ca6-4c6c-87a3-04ce55d16ff6"),
                    new Guid("98702079-0820-4d2a-a518-0ff65c9abeb7"),
                    new Guid("d7df3caa-346d-420a-b722-c73cf82e4bb7")
                });

            migrationBuilder.InsertData(
                table: "AdministratorUsers",
                columns: new[] { "Id", "RoleId" },
                values: new object[] { new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"), null });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("d2cdf8bb-310c-4a1e-ae48-e05dc1ef0221"),
                    new Guid("df4fd32f-4057-4888-9347-e67b89564fe3")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("020c2d2c-7b6f-420b-88dd-74e93391a70d"),
                    new Guid("5cca8407-6756-44a2-abc2-badc9f9f66db"),
                    new Guid("7f7654d0-dedd-4deb-ab67-6ed475903598"),
                    new Guid("b50a6a3f-e589-4757-a139-933b8837a11d")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AdministratorUsers_ApprovedUserId",
                table: "Categories",
                column: "ApprovedUserId",
                principalTable: "AdministratorUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AdministratorUsers_ApprovedUserId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3444d9f0-de44-4d4d-ba74-ddabd16f2628"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("41f45d10-5c2d-47ee-8be8-584fe85e4670"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("521c913a-8ca6-4c6c-87a3-04ce55d16ff6"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("98702079-0820-4d2a-a518-0ff65c9abeb7"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7df3caa-346d-420a-b722-c73cf82e4bb7"));

            migrationBuilder.DeleteData(
                table: "AdministratorUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2cdf8bb-310c-4a1e-ae48-e05dc1ef0221"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("df4fd32f-4057-4888-9347-e67b89564fe3"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("020c2d2c-7b6f-420b-88dd-74e93391a70d"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5cca8407-6756-44a2-abc2-badc9f9f66db"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f7654d0-dedd-4deb-ab67-6ed475903598"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("b50a6a3f-e589-4757-a139-933b8837a11d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("020c2d2c-7b6f-420b-88dd-74e93391a70d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3444d9f0-de44-4d4d-ba74-ddabd16f2628"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("41f45d10-5c2d-47ee-8be8-584fe85e4670"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("521c913a-8ca6-4c6c-87a3-04ce55d16ff6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5cca8407-6756-44a2-abc2-badc9f9f66db"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f7654d0-dedd-4deb-ab67-6ed475903598"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("98702079-0820-4d2a-a518-0ff65c9abeb7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b50a6a3f-e589-4757-a139-933b8837a11d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2cdf8bb-310c-4a1e-ae48-e05dc1ef0221"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7df3caa-346d-420a-b722-c73cf82e4bb7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("df4fd32f-4057-4888-9347-e67b89564fe3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovedUserId",
                table: "Categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApprovedById",
                table: "Categories",
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
                    { new Guid("0cca4fbb-79e2-4d11-9a00-3918144346b3"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("2511cad8-b5df-407c-9ce8-6c67274920a1"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("2aeb4405-aca7-4aa1-9322-d74c3e4a4f33"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("2ed48fad-01c7-4929-ae2f-85d32c898fef"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("3d48cdf9-328c-4ea4-a116-b6c9eb8590b2"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("7425fb83-a4d5-4b72-ae95-a65b7cbd95f7"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("77c3c3e7-a21d-4036-8f83-3e61bdc2117b"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("8ba895e6-8c64-4230-ba10-ee65245f18fd"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("bf7d2d46-1ae3-43a1-adf3-eff29546a6d5"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("e5501a68-21a0-43c1-b256-8a9bd2c3cc60"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("fbfa4d88-d271-4165-9b8c-3f85878e372d"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Email", "EmailConfirmed", "FullName", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModificationById", "ModificationDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("eb2cd484-46e6-4052-b28a-a58ed782d2e1"), 0, "41aff7b6-14dd-4214-a198-47c48ad1b2de", null, new DateTime(2025, 5, 9, 6, 12, 11, 371, DateTimeKind.Utc).AddTicks(9174), null, null, "admin@elderly.com", true, "Super Admin", false, false, null, null, null, "ADMIN@ELDERLY.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEJsCpEBbZAelY+9v2smYABf0sJiq+P7hopX2+V3g7r6yD+kTvZZTkxHawW+0vv1k9A==", null, false, null, false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("2511cad8-b5df-407c-9ce8-6c67274920a1"),
                    new Guid("3d48cdf9-328c-4ea4-a116-b6c9eb8590b2"),
                    new Guid("77c3c3e7-a21d-4036-8f83-3e61bdc2117b"),
                    new Guid("8ba895e6-8c64-4230-ba10-ee65245f18fd"),
                    new Guid("e5501a68-21a0-43c1-b256-8a9bd2c3cc60")
                });

            migrationBuilder.InsertData(
                table: "AdministratorUsers",
                columns: new[] { "Id", "RoleId" },
                values: new object[] { new Guid("eb2cd484-46e6-4052-b28a-a58ed782d2e1"), null });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("2aeb4405-aca7-4aa1-9322-d74c3e4a4f33"),
                    new Guid("fbfa4d88-d271-4165-9b8c-3f85878e372d")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0cca4fbb-79e2-4d11-9a00-3918144346b3"),
                    new Guid("2ed48fad-01c7-4929-ae2f-85d32c898fef"),
                    new Guid("7425fb83-a4d5-4b72-ae95-a65b7cbd95f7"),
                    new Guid("bf7d2d46-1ae3-43a1-adf3-eff29546a6d5")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AdministratorUsers_ApprovedUserId",
                table: "Categories",
                column: "ApprovedUserId",
                principalTable: "AdministratorUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
