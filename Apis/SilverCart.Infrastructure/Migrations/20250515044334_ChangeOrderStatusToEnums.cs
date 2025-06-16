using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderStatusToEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("164979f8-eed3-4cc5-8a6b-6a2eed042ec0"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("56976094-ed22-44bb-b288-5e470e29b849"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("610e2c21-b7f1-4cac-a6f5-585d498d0e7a"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("7710aec6-4b5d-4fa6-92c8-3562733684de"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("79faf54c-c9b7-4573-aeec-f758d91623c0"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("8abc9e36-29e5-4856-bc90-ef616eac3135"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec42c064-4373-44cf-af7d-bdc00e5a65ff"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("277e87ad-c57c-492b-bb03-3599d47f5fa6"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("43c5fd08-5c37-431c-81d3-abe82192f410"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("4db3d749-633e-4f7b-91fe-923c199cc2e4"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("83ba848a-01e8-4e53-8d77-e2b22a9ecff9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("164979f8-eed3-4cc5-8a6b-6a2eed042ec0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("277e87ad-c57c-492b-bb03-3599d47f5fa6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("43c5fd08-5c37-431c-81d3-abe82192f410"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4db3d749-633e-4f7b-91fe-923c199cc2e4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("56976094-ed22-44bb-b288-5e470e29b849"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("610e2c21-b7f1-4cac-a6f5-585d498d0e7a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7710aec6-4b5d-4fa6-92c8-3562733684de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("79faf54c-c9b7-4573-aeec-f758d91623c0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("83ba848a-01e8-4e53-8d77-e2b22a9ecff9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8abc9e36-29e5-4856-bc90-ef616eac3135"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec42c064-4373-44cf-af7d-bdc00e5a65ff"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderStatusId",
                table: "Orders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderStatusId",
                table: "Orders",
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
                    { new Guid("164979f8-eed3-4cc5-8a6b-6a2eed042ec0"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("277e87ad-c57c-492b-bb03-3599d47f5fa6"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("43c5fd08-5c37-431c-81d3-abe82192f410"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("4db3d749-633e-4f7b-91fe-923c199cc2e4"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("56976094-ed22-44bb-b288-5e470e29b849"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("610e2c21-b7f1-4cac-a6f5-585d498d0e7a"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("7710aec6-4b5d-4fa6-92c8-3562733684de"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("79faf54c-c9b7-4573-aeec-f758d91623c0"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("83ba848a-01e8-4e53-8d77-e2b22a9ecff9"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("8abc9e36-29e5-4856-bc90-ef616eac3135"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("ec42c064-4373-44cf-af7d-bdc00e5a65ff"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "7bc42112-16b8-4fa0-bc43-10b2d2074d3e", new DateTime(2025, 5, 15, 4, 19, 55, 330, DateTimeKind.Utc).AddTicks(1621), "AQAAAAIAAYagAAAAEEue+KZKc1a3WcErr7m5Dt9yjhaDO1R54FIr+fork5GyDgcyIcVwhJMW9b/F0U5HVA==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("164979f8-eed3-4cc5-8a6b-6a2eed042ec0"),
                    new Guid("56976094-ed22-44bb-b288-5e470e29b849"),
                    new Guid("610e2c21-b7f1-4cac-a6f5-585d498d0e7a"),
                    new Guid("7710aec6-4b5d-4fa6-92c8-3562733684de"),
                    new Guid("79faf54c-c9b7-4573-aeec-f758d91623c0")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("8abc9e36-29e5-4856-bc90-ef616eac3135"),
                    new Guid("ec42c064-4373-44cf-af7d-bdc00e5a65ff")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("277e87ad-c57c-492b-bb03-3599d47f5fa6"),
                    new Guid("43c5fd08-5c37-431c-81d3-abe82192f410"),
                    new Guid("4db3d749-633e-4f7b-91fe-923c199cc2e4"),
                    new Guid("83ba848a-01e8-4e53-8d77-e2b22a9ecff9")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
