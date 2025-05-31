using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("6674cd67-fb1b-4dc5-883d-4c6e279343c9"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("86aa1485-6cb5-46eb-bc49-b268b5399920"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b23e19f-ead0-436b-9bc1-3e3a7018dff4"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e3c861b4-ea2a-4c8e-80d8-29d52e31ef56"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5a4209b-774c-4e7f-82f5-bd16c9e09a72"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("458d3575-ba86-4a1f-a959-0410c5ebec19"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("758a67a8-c377-4a35-be02-9df80002e5ba"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("23718b51-d3ab-4561-a505-822f31991a6d"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("817b06dc-8244-4de9-be16-1ebb143299e1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3f7f997-b685-4d1e-9caa-f7569c73f780"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef917eb2-08df-4c7d-bded-b4605bdcabae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23718b51-d3ab-4561-a505-822f31991a6d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("458d3575-ba86-4a1f-a959-0410c5ebec19"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6674cd67-fb1b-4dc5-883d-4c6e279343c9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("758a67a8-c377-4a35-be02-9df80002e5ba"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("817b06dc-8244-4de9-be16-1ebb143299e1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("86aa1485-6cb5-46eb-bc49-b268b5399920"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b23e19f-ead0-436b-9bc1-3e3a7018dff4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3f7f997-b685-4d1e-9caa-f7569c73f780"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e3c861b4-ea2a-4c8e-80d8-29d52e31ef56"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5a4209b-774c-4e7f-82f5-bd16c9e09a72"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef917eb2-08df-4c7d-bded-b4605bdcabae"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("23718b51-d3ab-4561-a505-822f31991a6d"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("458d3575-ba86-4a1f-a959-0410c5ebec19"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("6674cd67-fb1b-4dc5-883d-4c6e279343c9"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("758a67a8-c377-4a35-be02-9df80002e5ba"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("817b06dc-8244-4de9-be16-1ebb143299e1"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("86aa1485-6cb5-46eb-bc49-b268b5399920"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("9b23e19f-ead0-436b-9bc1-3e3a7018dff4"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("d3f7f997-b685-4d1e-9caa-f7569c73f780"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("e3c861b4-ea2a-4c8e-80d8-29d52e31ef56"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("e5a4209b-774c-4e7f-82f5-bd16c9e09a72"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("ef917eb2-08df-4c7d-bded-b4605bdcabae"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" }
                });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("6674cd67-fb1b-4dc5-883d-4c6e279343c9"),
                    new Guid("86aa1485-6cb5-46eb-bc49-b268b5399920"),
                    new Guid("9b23e19f-ead0-436b-9bc1-3e3a7018dff4"),
                    new Guid("e3c861b4-ea2a-4c8e-80d8-29d52e31ef56"),
                    new Guid("e5a4209b-774c-4e7f-82f5-bd16c9e09a72")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("458d3575-ba86-4a1f-a959-0410c5ebec19"),
                    new Guid("758a67a8-c377-4a35-be02-9df80002e5ba")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("23718b51-d3ab-4561-a505-822f31991a6d"),
                    new Guid("817b06dc-8244-4de9-be16-1ebb143299e1"),
                    new Guid("d3f7f997-b685-4d1e-9caa-f7569c73f780"),
                    new Guid("ef917eb2-08df-4c7d-bded-b4605bdcabae")
                });
        }
    }
}
