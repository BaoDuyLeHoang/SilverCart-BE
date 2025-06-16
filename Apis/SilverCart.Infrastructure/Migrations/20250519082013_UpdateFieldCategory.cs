using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e3c5dea-400c-473e-ae9e-fa3f23aa7164"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("31c40f7f-b9f9-40a9-a635-ddfc23e9f6d1"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a8ddf2f-309d-40c3-bb03-c529933dc29d"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("ccb2acd7-4927-4d52-ab3b-6bc0f475146b"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4fcbe07-e5eb-4c80-8faf-be07546c6f52"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("b8fc5a86-8496-4a59-88d0-7f8b5463035d"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("daad913e-4bef-42e3-8aca-e4025f49a480"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5374baef-238d-46fa-8c23-2f1b79fac9de"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ef14084-bf9e-4887-90c0-c300b8c36b47"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c445d322-b9b0-459d-8cec-0a7d94820a14"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("f22c5276-f7cd-40a6-8e43-3f158d3e8ab3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2e3c5dea-400c-473e-ae9e-fa3f23aa7164"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("31c40f7f-b9f9-40a9-a635-ddfc23e9f6d1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a8ddf2f-309d-40c3-bb03-c529933dc29d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5374baef-238d-46fa-8c23-2f1b79fac9de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8ef14084-bf9e-4887-90c0-c300b8c36b47"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b8fc5a86-8496-4a59-88d0-7f8b5463035d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c445d322-b9b0-459d-8cec-0a7d94820a14"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ccb2acd7-4927-4d52-ab3b-6bc0f475146b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d4fcbe07-e5eb-4c80-8faf-be07546c6f52"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("daad913e-4bef-42e3-8aca-e4025f49a480"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f22c5276-f7cd-40a6-8e43-3f158d3e8ab3"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("04c1cf37-fd32-4df2-bd65-d686a7b4758f"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("06d58718-38dd-4509-8423-1506ac151451"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("1d5e5d5a-0953-4e8a-b811-495250c59f54"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("238f6ea5-0c16-4de8-95f0-dc506e1d976d"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("2b6ed63e-fc79-4823-987e-2a10d357e56b"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("33d95935-d7d0-4ab6-9954-81e0ae56ddd9"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("55084aae-0227-41ed-a38c-2235c92561d2"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("5f7bf7da-cee1-4feb-95d2-0fa06d0a05a7"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("6fb36102-e63e-4392-acd5-adf35e46190b"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("83875e46-e936-48fd-8e96-efa49423c0dd"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("fdc148e2-e39c-4e98-ae18-737e0b479d28"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "036cf9be-0cb3-4ba3-abe1-72ddf9382200", new DateTime(2025, 5, 19, 8, 20, 12, 281, DateTimeKind.Utc).AddTicks(2727), "AQAAAAIAAYagAAAAEDHoyzOEjsg15gebmbjdl5lDTtERd2wFxlyF39nLvkF17XR5S0QMmOJXvCxq5AoGUg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("238f6ea5-0c16-4de8-95f0-dc506e1d976d"),
                    new Guid("2b6ed63e-fc79-4823-987e-2a10d357e56b"),
                    new Guid("33d95935-d7d0-4ab6-9954-81e0ae56ddd9"),
                    new Guid("6fb36102-e63e-4392-acd5-adf35e46190b"),
                    new Guid("fdc148e2-e39c-4e98-ae18-737e0b479d28")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1d5e5d5a-0953-4e8a-b811-495250c59f54"),
                    new Guid("55084aae-0227-41ed-a38c-2235c92561d2")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("04c1cf37-fd32-4df2-bd65-d686a7b4758f"),
                    new Guid("06d58718-38dd-4509-8423-1506ac151451"),
                    new Guid("5f7bf7da-cee1-4feb-95d2-0fa06d0a05a7"),
                    new Guid("83875e46-e936-48fd-8e96-efa49423c0dd")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("238f6ea5-0c16-4de8-95f0-dc506e1d976d"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b6ed63e-fc79-4823-987e-2a10d357e56b"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("33d95935-d7d0-4ab6-9954-81e0ae56ddd9"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fb36102-e63e-4392-acd5-adf35e46190b"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("fdc148e2-e39c-4e98-ae18-737e0b479d28"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d5e5d5a-0953-4e8a-b811-495250c59f54"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("55084aae-0227-41ed-a38c-2235c92561d2"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("04c1cf37-fd32-4df2-bd65-d686a7b4758f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("06d58718-38dd-4509-8423-1506ac151451"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f7bf7da-cee1-4feb-95d2-0fa06d0a05a7"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("83875e46-e936-48fd-8e96-efa49423c0dd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04c1cf37-fd32-4df2-bd65-d686a7b4758f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("06d58718-38dd-4509-8423-1506ac151451"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1d5e5d5a-0953-4e8a-b811-495250c59f54"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("238f6ea5-0c16-4de8-95f0-dc506e1d976d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b6ed63e-fc79-4823-987e-2a10d357e56b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33d95935-d7d0-4ab6-9954-81e0ae56ddd9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("55084aae-0227-41ed-a38c-2235c92561d2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f7bf7da-cee1-4feb-95d2-0fa06d0a05a7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6fb36102-e63e-4392-acd5-adf35e46190b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83875e46-e936-48fd-8e96-efa49423c0dd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fdc148e2-e39c-4e98-ae18-737e0b479d28"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2e3c5dea-400c-473e-ae9e-fa3f23aa7164"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("31c40f7f-b9f9-40a9-a635-ddfc23e9f6d1"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("4a8ddf2f-309d-40c3-bb03-c529933dc29d"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("5374baef-238d-46fa-8c23-2f1b79fac9de"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("8ef14084-bf9e-4887-90c0-c300b8c36b47"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("b8fc5a86-8496-4a59-88d0-7f8b5463035d"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("c445d322-b9b0-459d-8cec-0a7d94820a14"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("ccb2acd7-4927-4d52-ab3b-6bc0f475146b"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("d4fcbe07-e5eb-4c80-8faf-be07546c6f52"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("daad913e-4bef-42e3-8aca-e4025f49a480"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("f22c5276-f7cd-40a6-8e43-3f158d3e8ab3"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "eb22898a-75c2-4084-bd2b-c56d66c19b82", new DateTime(2025, 5, 15, 9, 30, 56, 648, DateTimeKind.Utc).AddTicks(4621), "AQAAAAIAAYagAAAAEEh7O+avCvoewyKGCuAlr4Rjk6u+SpuxulKSVSFEsAye2ei+AKTRqfv40AjIxJIUjg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("2e3c5dea-400c-473e-ae9e-fa3f23aa7164"),
                    new Guid("31c40f7f-b9f9-40a9-a635-ddfc23e9f6d1"),
                    new Guid("4a8ddf2f-309d-40c3-bb03-c529933dc29d"),
                    new Guid("ccb2acd7-4927-4d52-ab3b-6bc0f475146b"),
                    new Guid("d4fcbe07-e5eb-4c80-8faf-be07546c6f52")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("b8fc5a86-8496-4a59-88d0-7f8b5463035d"),
                    new Guid("daad913e-4bef-42e3-8aca-e4025f49a480")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("5374baef-238d-46fa-8c23-2f1b79fac9de"),
                    new Guid("8ef14084-bf9e-4887-90c0-c300b8c36b47"),
                    new Guid("c445d322-b9b0-459d-8cec-0a7d94820a14"),
                    new Guid("f22c5276-f7cd-40a6-8e43-3f158d3e8ab3")
                });
        }
    }
}
