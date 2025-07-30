using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Role_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "ConsultantRoles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "Người giám hộ là người giám hộ cho người phụ thuộc và có quyền giám hộ cho người phụ thuộc.", "Người giám hộ" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "Quản trị viên là người quản lý cửa hàng và có quyền quản lý cửa hàng.", "Quản trị viên" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "Siêu quản trị viên là người quản lý toàn bộ hệ thống và có quyền quản lý toàn bộ hệ thống.", "Siêu quản trị viên" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "Chủ cửa hàng là người quản lý cửa hàng và có quyền quản lý cửa hàng.", "Chủ cửa hàng" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "Hỗ trợ cửa hàng là người hỗ trợ cửa hàng và có quyền hỗ trợ cửa hàng.", "Hỗ trợ cửa hàng" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "Người phụ thuộc là người phụ thuộc cho người giám hộ và có quyền phụ thuộc cho người giám hộ.", "Người phụ thuộc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "437c89a4-6cd4-4f97-94e6-6be67c8e056f", new DateTime(2025, 7, 15, 13, 5, 19, 76, DateTimeKind.Utc).AddTicks(5020), "AQAAAAIAAYagAAAAEAUkz2vCBhY+gykPhZMUdwWKnkQqWMX1FjtggImuF+XaKDhieSvyNK6MlBbAvg+PTg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7737), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7752), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7762), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7764), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7744), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7799), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222224"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7802), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7746), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333334"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7805), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333335"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7809), null });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreationDate", "ImageUrl" },
                values: new object[] { new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7748), null });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111151"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111152"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222232"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333343"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4139));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333344"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111141"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1311));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1327));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1332));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7318));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7333));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7338));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7341));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(468));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(472));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222225"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(476));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222226"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333336"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333337"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444445"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444446"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(504));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 35, DateTimeKind.Utc).AddTicks(1583));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 35, DateTimeKind.Utc).AddTicks(1587));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222242"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 35, DateTimeKind.Utc).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222243"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 35, DateTimeKind.Utc).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333353"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 35, DateTimeKind.Utc).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333354"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 35, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 30, DateTimeKind.Utc).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 35, DateTimeKind.Utc).AddTicks(7533));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "ConsultantRoles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "", "GUARDIAN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "", "STOREOWNER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "", "STORESUPPORT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                columns: new[] { "Description", "NormalizedName" },
                values: new object[] { "", "DEPENDENTUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "IsHardDelete", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[] { new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"), null, null, null, null, null, "", false, false, null, null, "Customer", "CUSTOMER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "bd5692b4-e4cb-4230-af9b-5be397689aab", new DateTime(2025, 7, 12, 17, 31, 33, 469, DateTimeKind.Utc).AddTicks(2705), "AQAAAAIAAYagAAAAEFS/qrGaKPFRdTLke/11NXn8ALdaBNYEMaqoFWixh790RIZ0A2wpSy64W9j1BMpcsQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7014) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7056) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7059) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7063) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7022) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7066) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222224"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7025) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333334"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7072) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333335"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7075) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreatedDate", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7052) });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111151"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111152"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222232"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9988));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333343"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9996));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333344"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111141"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7487));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4496));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4504));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4508));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4516));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4522));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6781));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222225"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222226"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333336"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333337"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6807));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444445"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6811));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444446"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6815));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222242"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222243"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333353"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333354"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 418, DateTimeKind.Utc).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 17, 31, 33, 424, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                value: new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"));
        }
    }
}
