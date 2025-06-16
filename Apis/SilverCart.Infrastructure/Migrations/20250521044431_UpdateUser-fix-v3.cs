using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserfixv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("075b9468-8ef5-42f9-8f3c-ed5983f3b301"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("5297f1ca-aaad-44a2-8525-40e0dc747792"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("77a9213c-39af-4e05-b331-088dd87a8822"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e9680cc-c29a-4fcf-8ecb-69d58ac1904f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("afd74a93-1690-4022-92f9-f150f85265f7"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("10aa5165-49b4-4346-b804-340ac6ba41cc"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f776114-1fca-4a59-aaeb-ff874edede82"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("86b2c1ae-c413-458b-8500-5f8976a054a1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("52d7cc4f-b1dc-4c5c-bb6a-3d39b22dd228"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("72cc6ab8-f456-45c0-b39a-957fdbfde10b"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("8fc07e42-16e0-4157-86e1-4ebde8354286"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbdf3de3-68e1-4d15-bebd-ede0398399df"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("075b9468-8ef5-42f9-8f3c-ed5983f3b301"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("10aa5165-49b4-4346-b804-340ac6ba41cc"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f776114-1fca-4a59-aaeb-ff874edede82"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5297f1ca-aaad-44a2-8525-40e0dc747792"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("52d7cc4f-b1dc-4c5c-bb6a-3d39b22dd228"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("72cc6ab8-f456-45c0-b39a-957fdbfde10b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("77a9213c-39af-4e05-b331-088dd87a8822"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7e9680cc-c29a-4fcf-8ecb-69d58ac1904f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("86b2c1ae-c413-458b-8500-5f8976a054a1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8fc07e42-16e0-4157-86e1-4ebde8354286"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("afd74a93-1690-4022-92f9-f150f85265f7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cbdf3de3-68e1-4d15-bebd-ede0398399df"));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("075b9468-8ef5-42f9-8f3c-ed5983f3b301"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("10aa5165-49b4-4346-b804-340ac6ba41cc"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("3f776114-1fca-4a59-aaeb-ff874edede82"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("5297f1ca-aaad-44a2-8525-40e0dc747792"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("52d7cc4f-b1dc-4c5c-bb6a-3d39b22dd228"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("72cc6ab8-f456-45c0-b39a-957fdbfde10b"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("77a9213c-39af-4e05-b331-088dd87a8822"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("7e9680cc-c29a-4fcf-8ecb-69d58ac1904f"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("86b2c1ae-c413-458b-8500-5f8976a054a1"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("8fc07e42-16e0-4157-86e1-4ebde8354286"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("afd74a93-1690-4022-92f9-f150f85265f7"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("cbdf3de3-68e1-4d15-bebd-ede0398399df"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "75c07c9d-99b6-42ff-b6a8-ab783b9450df", new DateTime(2025, 5, 21, 4, 24, 14, 601, DateTimeKind.Utc).AddTicks(6216), "AQAAAAIAAYagAAAAEKWvunv2yLXgbOsBe9dlJpMyx3M1ovbdeGNRdV2m4OEvJQvnwDVXbypylay1F/wOIQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("075b9468-8ef5-42f9-8f3c-ed5983f3b301"),
                    new Guid("5297f1ca-aaad-44a2-8525-40e0dc747792"),
                    new Guid("77a9213c-39af-4e05-b331-088dd87a8822"),
                    new Guid("7e9680cc-c29a-4fcf-8ecb-69d58ac1904f"),
                    new Guid("afd74a93-1690-4022-92f9-f150f85265f7")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("10aa5165-49b4-4346-b804-340ac6ba41cc"),
                    new Guid("3f776114-1fca-4a59-aaeb-ff874edede82"),
                    new Guid("86b2c1ae-c413-458b-8500-5f8976a054a1")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("52d7cc4f-b1dc-4c5c-bb6a-3d39b22dd228"),
                    new Guid("72cc6ab8-f456-45c0-b39a-957fdbfde10b"),
                    new Guid("8fc07e42-16e0-4157-86e1-4ebde8354286"),
                    new Guid("cbdf3de3-68e1-4d15-bebd-ede0398399df")
                });
        }
    }
}
