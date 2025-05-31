using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("6d860692-eacf-4786-a7c7-111cc10f93bf"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8929047f-aae7-4227-9603-52bd969aebd1"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("c2eee3dd-ee29-4ca0-91d9-456d2e1ae8b4"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("eaa3f66a-a84a-4f7c-a7b0-a229f7961318"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("fd007112-e207-414c-8943-408220098807"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("a754df40-3abf-46e7-a37c-9b6267e0fea7"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("b9bc3ec2-1092-4ac2-81cc-838d22eda373"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ea1a69c-d2af-43a4-93eb-4e47a4f850ac"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("9017c8f6-9016-4393-bd2e-fccb7fa27cc8"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("edda69db-1fa7-495f-81ba-8240393ac487"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("fccbc8ba-f04a-4b01-b2ec-6c747bfe1cb8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ea1a69c-d2af-43a4-93eb-4e47a4f850ac"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6d860692-eacf-4786-a7c7-111cc10f93bf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8929047f-aae7-4227-9603-52bd969aebd1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9017c8f6-9016-4393-bd2e-fccb7fa27cc8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a754df40-3abf-46e7-a37c-9b6267e0fea7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b9bc3ec2-1092-4ac2-81cc-838d22eda373"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c2eee3dd-ee29-4ca0-91d9-456d2e1ae8b4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("eaa3f66a-a84a-4f7c-a7b0-a229f7961318"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("edda69db-1fa7-495f-81ba-8240393ac487"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fccbc8ba-f04a-4b01-b2ec-6c747bfe1cb8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fd007112-e207-414c-8943-408220098807"));

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Addresses",
                newName: "WardCode");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Addresses",
                newName: "ToProvinceName");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Addresses",
                newName: "ToDistrictName");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreAddressId",
                table: "Stores",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StoreAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModificationById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteById = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    WardCode = table.Column<string>(type: "text", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    DistrictName = table.Column<string>(type: "text", nullable: false),
                    ProvinceName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreAddress", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreAddressId",
                table: "Stores",
                column: "StoreAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CustomerUsers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "CustomerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_StoreAddress_StoreAddressId",
                table: "Stores",
                column: "StoreAddressId",
                principalTable: "StoreAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CustomerUsers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerUsers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_StoreAddress_StoreAddressId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "StoreAddress");

            migrationBuilder.DropIndex(
                name: "IX_Stores_StoreAddressId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses");

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

            migrationBuilder.DropColumn(
                name: "StoreAddressId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "WardCode",
                table: "Addresses",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "ToProvinceName",
                table: "Addresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "ToDistrictName",
                table: "Addresses",
                newName: "Country");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Stores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1ea1a69c-d2af-43a4-93eb-4e47a4f850ac"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("6d860692-eacf-4786-a7c7-111cc10f93bf"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("8929047f-aae7-4227-9603-52bd969aebd1"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("9017c8f6-9016-4393-bd2e-fccb7fa27cc8"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("a754df40-3abf-46e7-a37c-9b6267e0fea7"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("b9bc3ec2-1092-4ac2-81cc-838d22eda373"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("c2eee3dd-ee29-4ca0-91d9-456d2e1ae8b4"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("eaa3f66a-a84a-4f7c-a7b0-a229f7961318"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("edda69db-1fa7-495f-81ba-8240393ac487"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("fccbc8ba-f04a-4b01-b2ec-6c747bfe1cb8"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("fd007112-e207-414c-8943-408220098807"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "defa6ea1-ba71-4c5d-bc5c-e9ff48387be7", new DateTime(2025, 5, 15, 6, 52, 36, 674, DateTimeKind.Utc).AddTicks(6019), "AQAAAAIAAYagAAAAEKmx+lCuy35PE34kAJ+5aq08mnRt8YSTaddHR/shGypUghS8iKQ5nGS79q8XdvR/nw==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("6d860692-eacf-4786-a7c7-111cc10f93bf"),
                    new Guid("8929047f-aae7-4227-9603-52bd969aebd1"),
                    new Guid("c2eee3dd-ee29-4ca0-91d9-456d2e1ae8b4"),
                    new Guid("eaa3f66a-a84a-4f7c-a7b0-a229f7961318"),
                    new Guid("fd007112-e207-414c-8943-408220098807")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("a754df40-3abf-46e7-a37c-9b6267e0fea7"),
                    new Guid("b9bc3ec2-1092-4ac2-81cc-838d22eda373")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1ea1a69c-d2af-43a4-93eb-4e47a4f850ac"),
                    new Guid("9017c8f6-9016-4393-bd2e-fccb7fa27cc8"),
                    new Guid("edda69db-1fa7-495f-81ba-8240393ac487"),
                    new Guid("fccbc8ba-f04a-4b01-b2ec-6c747bfe1cb8")
                });
        }
    }
}
