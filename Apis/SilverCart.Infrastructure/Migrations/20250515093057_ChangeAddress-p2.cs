using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAddressp2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("051caf3d-380e-42fb-9b90-32dfd5cd0288"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("161ce72d-c189-435a-94e3-771318dff948"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("52950c5c-71ec-4adf-b358-620c0c0031d3"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("966664ee-4f2f-4177-b8ba-b22324b2fab6"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3f27f16-ce84-4d3c-b5c6-379716285731"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b17af49-03bf-4e17-9a7e-232bbb608286"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("b4907ea9-09cd-4e7d-9bbb-16bca66145d9"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e3136b3-4460-4f38-b99a-b8eb3bc28b81"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc69609e-89cc-4c25-822d-65a22b23db66"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d27f9543-ddb2-415e-8af0-04c93ce6f346"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7b76694-9d37-4605-8d81-15e0cbc8bc74"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("051caf3d-380e-42fb-9b90-32dfd5cd0288"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("161ce72d-c189-435a-94e3-771318dff948"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2b17af49-03bf-4e17-9a7e-232bbb608286"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e3136b3-4460-4f38-b99a-b8eb3bc28b81"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("52950c5c-71ec-4adf-b358-620c0c0031d3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("966664ee-4f2f-4177-b8ba-b22324b2fab6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b4907ea9-09cd-4e7d-9bbb-16bca66145d9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cc69609e-89cc-4c25-822d-65a22b23db66"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d27f9543-ddb2-415e-8af0-04c93ce6f346"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3f27f16-ce84-4d3c-b5c6-379716285731"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7b76694-9d37-4605-8d81-15e0cbc8bc74"));

            migrationBuilder.RenameColumn(
                name: "ProvinceName",
                table: "StoreAddress",
                newName: "FromProvinceName");

            migrationBuilder.RenameColumn(
                name: "DistrictName",
                table: "StoreAddress",
                newName: "FromDistrictName");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "FromProvinceName",
                table: "StoreAddress",
                newName: "ProvinceName");

            migrationBuilder.RenameColumn(
                name: "FromDistrictName",
                table: "StoreAddress",
                newName: "DistrictName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("051caf3d-380e-42fb-9b90-32dfd5cd0288"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("161ce72d-c189-435a-94e3-771318dff948"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("2b17af49-03bf-4e17-9a7e-232bbb608286"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("3e3136b3-4460-4f38-b99a-b8eb3bc28b81"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("52950c5c-71ec-4adf-b358-620c0c0031d3"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("966664ee-4f2f-4177-b8ba-b22324b2fab6"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("b4907ea9-09cd-4e7d-9bbb-16bca66145d9"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("cc69609e-89cc-4c25-822d-65a22b23db66"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("d27f9543-ddb2-415e-8af0-04c93ce6f346"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("d3f27f16-ce84-4d3c-b5c6-379716285731"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("e7b76694-9d37-4605-8d81-15e0cbc8bc74"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "9b088cfe-95aa-4657-8832-936214b286c1", new DateTime(2025, 5, 15, 7, 57, 22, 273, DateTimeKind.Utc).AddTicks(5468), "AQAAAAIAAYagAAAAENtf8Yw0x3XviMONeV49oiG9JP4L45BuLylKKHoCy7qmTukfZ4sqCNw4c0cib8A1dw==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("051caf3d-380e-42fb-9b90-32dfd5cd0288"),
                    new Guid("161ce72d-c189-435a-94e3-771318dff948"),
                    new Guid("52950c5c-71ec-4adf-b358-620c0c0031d3"),
                    new Guid("966664ee-4f2f-4177-b8ba-b22324b2fab6"),
                    new Guid("d3f27f16-ce84-4d3c-b5c6-379716285731")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("2b17af49-03bf-4e17-9a7e-232bbb608286"),
                    new Guid("b4907ea9-09cd-4e7d-9bbb-16bca66145d9")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3e3136b3-4460-4f38-b99a-b8eb3bc28b81"),
                    new Guid("cc69609e-89cc-4c25-822d-65a22b23db66"),
                    new Guid("d27f9543-ddb2-415e-8af0-04c93ce6f346"),
                    new Guid("e7b76694-9d37-4605-8d81-15e0cbc8bc74")
                });
        }
    }
}
