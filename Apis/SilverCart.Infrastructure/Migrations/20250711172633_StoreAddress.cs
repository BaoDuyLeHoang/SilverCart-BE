using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class StoreAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "d7943075-3569-4a80-a02b-abd460513004", new DateTime(2025, 7, 11, 17, 26, 32, 650, DateTimeKind.Utc).AddTicks(5977), "AQAAAAIAAYagAAAAEJB3lm06j7Y7Lnxf5TyDZfnsTWKYNxhx9z1Z2lfiRLdWwC7DW/5HAG0trlYShVnk+g==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4479));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4483));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4463));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222224"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4466));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333334"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4493));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333335"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4495));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4468));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7119));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111163"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222233"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7130));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222234"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333345"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333346"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444449"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7145));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444450"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111151"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6375));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111152"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6378));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222232"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333343"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333344"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111141"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6274));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5945));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5949));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5955));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5967));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(6074));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222225"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222226"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333336"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333337"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5784));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444445"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444446"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5798));

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 26, 32, 604, DateTimeKind.Utc).AddTicks(4737));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "3a11c200-bcb4-49a2-86f6-2872a12bd3ac", new DateTime(2025, 7, 11, 17, 7, 16, 33, DateTimeKind.Utc).AddTicks(166), "AQAAAAIAAYagAAAAELnpiK3mQBKNyxLpFXvZaSaPJNw8Ka2byPrhxXDnVavWg7HSQchY+VDE/+6SEqCFcQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1134));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222224"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1139));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333334"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1142));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333335"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1144));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111163"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3977));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222233"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222234"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3981));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333345"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3984));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333346"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444449"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444450"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111151"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111152"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222232"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333343"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333344"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111141"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3068));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3081));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2871));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2875));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2878));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2880));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2883));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2889));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2907));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2909));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2912));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2735));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2746));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222225"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2749));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222226"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333336"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2754));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333337"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444445"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2758));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444446"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2772));

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2622));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1527));
        }
    }
}
