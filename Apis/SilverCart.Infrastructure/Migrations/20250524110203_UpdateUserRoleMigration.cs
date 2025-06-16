using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" },
                    { new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" },
                    { new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "29cf4e19-2dfc-4a61-a70f-871e3dae3715", new DateTime(2025, 5, 24, 11, 2, 3, 75, DateTimeKind.Utc).AddTicks(1787), "AQAAAAIAAYagAAAAECICBWqq57bfWwfcsdPrfgGi0H2cU/x9MropgiL+WmL4mT8dk1cn8mRTIeTXUqyX2A==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"),
                    new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"),
                    new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"),
                    new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                    new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"));

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
        }
    }
}
