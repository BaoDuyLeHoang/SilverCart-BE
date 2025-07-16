using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Categories_CategoryId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Products_ProductId",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategories");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "6f265841-de53-40de-a66d-f4c88495cf67", new DateTime(2025, 7, 12, 2, 3, 39, 926, DateTimeKind.Utc).AddTicks(1899), "AQAAAAIAAYagAAAAEL9WuRGrhGYnFfN73sEQWXI+jomgIUhPQH2Xh4QpyyqF60+Uv/xtjXHYmPlr2G8kjA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9643));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9656));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9659));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9648));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222224"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9651));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333334"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9673));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333335"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3252));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3258));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111163"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222233"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3267));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222234"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333345"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3273));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333346"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444449"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444450"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111151"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111152"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222232"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333343"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333344"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111141"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5951));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5966));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5971));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5975));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5005));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5033));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5041));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4025));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4032));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222225"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222226"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4068));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333336"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333337"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4082));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444445"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444446"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9924));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Categories_CategoryId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Products_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Categories_CategoryId",
                table: "ProductCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Products_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
