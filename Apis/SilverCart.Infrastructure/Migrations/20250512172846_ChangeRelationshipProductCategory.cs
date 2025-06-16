using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e6cf206-24d0-408c-af66-79d8e71a83b5"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3facadb1-5be0-4312-a85a-4dba7a56f342"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae8c009d-fb0c-4ee9-9dc8-fc40a2d0d517"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0e2d4ae-9dec-4aed-937b-0696201e674e"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e687ca60-1b7f-4c3f-9968-ca580a27d71f"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("27985ce1-855d-46d3-8e73-367f43375805"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("a51776ab-0eaf-41ce-a0cf-8be810f1c6e3"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("79b26a97-6503-4176-a3c5-7a7822968c30"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("a94fde08-759e-445b-b4be-a1ab0058e19a"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb911613-03f8-4fb3-8f7c-eb8c710f730f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8153911-a5a4-4387-b830-cd940391f7ba"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("27985ce1-855d-46d3-8e73-367f43375805"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3e6cf206-24d0-408c-af66-79d8e71a83b5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3facadb1-5be0-4312-a85a-4dba7a56f342"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("79b26a97-6503-4176-a3c5-7a7822968c30"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a51776ab-0eaf-41ce-a0cf-8be810f1c6e3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a94fde08-759e-445b-b4be-a1ab0058e19a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae8c009d-fb0c-4ee9-9dc8-fc40a2d0d517"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bb911613-03f8-4fb3-8f7c-eb8c710f730f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c0e2d4ae-9dec-4aed-937b-0696201e674e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e687ca60-1b7f-4c3f-9968-ca580a27d71f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8153911-a5a4-4387-b830-cd940391f7ba"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductVariants",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "ProductVariants",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "ProductVariants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "VideoPath",
                table: "Products",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01a8eff1-3c68-4ce0-a767-2b06157c18b1"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("0e76832e-9cc0-47c3-94f2-f96473f37e79"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("3c0f7754-1a28-4ae1-9613-ddb55679a5c1"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("4ad6c7a4-5d01-4031-bc97-019c9a5dfe7f"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("4e439685-c17c-4c44-b7ac-602852ac4161"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("89c31de1-46a9-401a-a941-9affb9636e8d"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("8d1a9e12-6710-4f15-a689-5f8b79fdda3e"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("adbade04-b559-4777-b1a0-2f245af04bad"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("bd7fcea7-fe6d-4fa6-8360-ee644ecd18f4"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("bd8c2df3-0401-43e3-b9cc-c2a829157ce5"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("c577c87f-f067-4ceb-ad0d-f5de6f0bc3ce"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "5abc5f88-e78e-4ac6-a4fe-521ee129a0f2", new DateTime(2025, 5, 12, 17, 28, 44, 203, DateTimeKind.Utc).AddTicks(3519), "AQAAAAIAAYagAAAAEFmqjVCTi5c3idhmit5y2zlVJ69mSB+ftpJy2Qm0P5sx/qS8UxnZzMqjHtcVyjeFzg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("4ad6c7a4-5d01-4031-bc97-019c9a5dfe7f"),
                    new Guid("4e439685-c17c-4c44-b7ac-602852ac4161"),
                    new Guid("89c31de1-46a9-401a-a941-9affb9636e8d"),
                    new Guid("8d1a9e12-6710-4f15-a689-5f8b79fdda3e"),
                    new Guid("bd7fcea7-fe6d-4fa6-8360-ee644ecd18f4")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("adbade04-b559-4777-b1a0-2f245af04bad"),
                    new Guid("bd8c2df3-0401-43e3-b9cc-c2a829157ce5")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("01a8eff1-3c68-4ce0-a767-2b06157c18b1"),
                    new Guid("0e76832e-9cc0-47c3-94f2-f96473f37e79"),
                    new Guid("3c0f7754-1a28-4ae1-9613-ddb55679a5c1"),
                    new Guid("c577c87f-f067-4ceb-ad0d-f5de6f0bc3ce")
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ad6c7a4-5d01-4031-bc97-019c9a5dfe7f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e439685-c17c-4c44-b7ac-602852ac4161"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("89c31de1-46a9-401a-a941-9affb9636e8d"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d1a9e12-6710-4f15-a689-5f8b79fdda3e"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd7fcea7-fe6d-4fa6-8360-ee644ecd18f4"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("adbade04-b559-4777-b1a0-2f245af04bad"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd8c2df3-0401-43e3-b9cc-c2a829157ce5"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("01a8eff1-3c68-4ce0-a767-2b06157c18b1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e76832e-9cc0-47c3-94f2-f96473f37e79"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c0f7754-1a28-4ae1-9613-ddb55679a5c1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c577c87f-f067-4ceb-ad0d-f5de6f0bc3ce"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01a8eff1-3c68-4ce0-a767-2b06157c18b1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e76832e-9cc0-47c3-94f2-f96473f37e79"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c0f7754-1a28-4ae1-9613-ddb55679a5c1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ad6c7a4-5d01-4031-bc97-019c9a5dfe7f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4e439685-c17c-4c44-b7ac-602852ac4161"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("89c31de1-46a9-401a-a941-9affb9636e8d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d1a9e12-6710-4f15-a689-5f8b79fdda3e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("adbade04-b559-4777-b1a0-2f245af04bad"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd7fcea7-fe6d-4fa6-8360-ee644ecd18f4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bd8c2df3-0401-43e3-b9cc-c2a829157ce5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c577c87f-f067-4ceb-ad0d-f5de6f0bc3ce"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "VideoPath",
                table: "Products",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("27985ce1-855d-46d3-8e73-367f43375805"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("3e6cf206-24d0-408c-af66-79d8e71a83b5"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("3facadb1-5be0-4312-a85a-4dba7a56f342"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("79b26a97-6503-4176-a3c5-7a7822968c30"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("a51776ab-0eaf-41ce-a0cf-8be810f1c6e3"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("a94fde08-759e-445b-b4be-a1ab0058e19a"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("ae8c009d-fb0c-4ee9-9dc8-fc40a2d0d517"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("bb911613-03f8-4fb3-8f7c-eb8c710f730f"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("c0e2d4ae-9dec-4aed-937b-0696201e674e"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("e687ca60-1b7f-4c3f-9968-ca580a27d71f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("e8153911-a5a4-4387-b830-cd940391f7ba"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "0076726d-430e-4d36-ad2e-5c23bfb96583", new DateTime(2025, 5, 9, 6, 27, 2, 554, DateTimeKind.Utc).AddTicks(8988), "AQAAAAIAAYagAAAAECcNKYQjE4nguXbkeYa7tViOXEt/3ANYmcvcD2Z5LZ8aU8MytPCafakeq7MK71Apnw==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("3e6cf206-24d0-408c-af66-79d8e71a83b5"),
                    new Guid("3facadb1-5be0-4312-a85a-4dba7a56f342"),
                    new Guid("ae8c009d-fb0c-4ee9-9dc8-fc40a2d0d517"),
                    new Guid("c0e2d4ae-9dec-4aed-937b-0696201e674e"),
                    new Guid("e687ca60-1b7f-4c3f-9968-ca580a27d71f")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("27985ce1-855d-46d3-8e73-367f43375805"),
                    new Guid("a51776ab-0eaf-41ce-a0cf-8be810f1c6e3")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("79b26a97-6503-4176-a3c5-7a7822968c30"),
                    new Guid("a94fde08-759e-445b-b4be-a1ab0058e19a"),
                    new Guid("bb911613-03f8-4fb3-8f7c-eb8c710f730f"),
                    new Guid("e8153911-a5a4-4387-b830-cd940391f7ba")
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
