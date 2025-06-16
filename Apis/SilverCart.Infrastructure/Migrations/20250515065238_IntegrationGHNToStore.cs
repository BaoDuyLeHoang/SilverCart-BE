using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class IntegrationGHNToStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b566284-1d07-4b3d-a7a8-7f3056618534"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("34ed4271-a6a0-4b75-8947-ab0b1b366dee"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("620fab42-e220-47c1-99da-092b804b9096"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b2c98545-9808-4eca-bc36-5e0be81ae905"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b311a18c-4765-4f52-9fbd-85010839c698"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("0534e3a8-c35e-4470-8953-b2f72e0ce08d"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c59c213b-ada7-40f1-b077-d74c912e0b53"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("2852d33e-2f23-4512-898c-fa43fd79118a"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("62aad848-0f8e-4e8e-8c13-8ed17198fdd3"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f425631-3eda-40de-bc9e-c2d7cccd543a"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("b9737876-e4d1-407c-bb64-88534fe8f3b8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0534e3a8-c35e-4470-8953-b2f72e0ce08d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1b566284-1d07-4b3d-a7a8-7f3056618534"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2852d33e-2f23-4512-898c-fa43fd79118a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("34ed4271-a6a0-4b75-8947-ab0b1b366dee"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("620fab42-e220-47c1-99da-092b804b9096"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62aad848-0f8e-4e8e-8c13-8ed17198fdd3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f425631-3eda-40de-bc9e-c2d7cccd543a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b2c98545-9808-4eca-bc36-5e0be81ae905"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b311a18c-4765-4f52-9fbd-85010839c698"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b9737876-e4d1-407c-bb64-88534fe8f3b8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c59c213b-ada7-40f1-b077-d74c912e0b53"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Stores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GhnShopId",
                table: "Stores",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGhnSynced",
                table: "Stores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ProductType",
                table: "Products",
                type: "integer",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "smallint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimatedArrivedDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeadlineDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivedDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "GhnShopId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsGhnSynced",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderItems");

            migrationBuilder.AlterColumn<byte>(
                name: "ProductType",
                table: "Products",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EstimatedArrivedDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeadlineDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivedDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0534e3a8-c35e-4470-8953-b2f72e0ce08d"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("1b566284-1d07-4b3d-a7a8-7f3056618534"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("2852d33e-2f23-4512-898c-fa43fd79118a"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("34ed4271-a6a0-4b75-8947-ab0b1b366dee"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("620fab42-e220-47c1-99da-092b804b9096"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("62aad848-0f8e-4e8e-8c13-8ed17198fdd3"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("7f425631-3eda-40de-bc9e-c2d7cccd543a"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("b2c98545-9808-4eca-bc36-5e0be81ae905"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("b311a18c-4765-4f52-9fbd-85010839c698"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("b9737876-e4d1-407c-bb64-88534fe8f3b8"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("c59c213b-ada7-40f1-b077-d74c912e0b53"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "fdba939a-10e8-443f-963d-efcc265fa981", new DateTime(2025, 5, 15, 4, 43, 33, 640, DateTimeKind.Utc).AddTicks(3022), "AQAAAAIAAYagAAAAECJa3+HWZgvTjhvUqtQuC7I6PQI7CLxDweEtvZv/wSap8ifXKHohq1IFNWOm3o+ugA==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1b566284-1d07-4b3d-a7a8-7f3056618534"),
                    new Guid("34ed4271-a6a0-4b75-8947-ab0b1b366dee"),
                    new Guid("620fab42-e220-47c1-99da-092b804b9096"),
                    new Guid("b2c98545-9808-4eca-bc36-5e0be81ae905"),
                    new Guid("b311a18c-4765-4f52-9fbd-85010839c698")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0534e3a8-c35e-4470-8953-b2f72e0ce08d"),
                    new Guid("c59c213b-ada7-40f1-b077-d74c912e0b53")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("2852d33e-2f23-4512-898c-fa43fd79118a"),
                    new Guid("62aad848-0f8e-4e8e-8c13-8ed17198fdd3"),
                    new Guid("7f425631-3eda-40de-bc9e-c2d7cccd543a"),
                    new Guid("b9737876-e4d1-407c-bb64-88534fe8f3b8")
                });
        }
    }
}
