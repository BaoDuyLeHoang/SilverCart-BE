using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Warning_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethods_CustomerUsers_CustomerUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethods_PaymentMethods_PaymentMethodId1",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethodHistories_CustomerPaymentMethods_CustomerPayme~",
                table: "PaymentMethodHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethodHistories_CustomerUsers_CustomerUserId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethodHistories_Orders_OrderId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethodHistories_PaymentMethods_PaymentMethodId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethodHistories_Promotions_PromotionId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethodHistories_Wallets_WalletId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Stores_StoreId",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromotions_Products_ProductId1",
                table: "ProductPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromotions_Promotions_PromotionId1",
                table: "ProductPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Products_ProductId1",
                table: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ProductId1",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPromotions",
                table: "ProductPromotions");

            migrationBuilder.DropIndex(
                name: "IX_ProductPromotions_ProductId",
                table: "ProductPromotions");

            migrationBuilder.DropIndex(
                name: "IX_ProductPromotions_ProductId1",
                table: "ProductPromotions");

            migrationBuilder.DropIndex(
                name: "IX_ProductPromotions_PromotionId1",
                table: "ProductPromotions");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_StoreId",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPaymentMethods_CustomerUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPaymentMethods_PaymentMethodId1",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethodHistories",
                table: "PaymentMethodHistories");

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111121") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111122") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111123") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222223"), new Guid("22222222-2222-2222-2222-222222222225") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("22222222-2222-2222-2222-222222222224"), new Guid("22222222-2222-2222-2222-222222222226") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("33333333-3333-3333-3333-333333333334"), new Guid("33333333-3333-3333-3333-333333333336") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("33333333-3333-3333-3333-333333333335"), new Guid("33333333-3333-3333-3333-333333333337") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444445") });

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444446") });

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111151"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111152"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222232"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333343"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333344"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222224"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333334"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333335"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111141"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444445"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444446"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222226"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222225"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333336"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333337"));

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductPromotions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductPromotions");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductPromotions");

            migrationBuilder.DropColumn(
                name: "PromotionId1",
                table: "ProductPromotions");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId1",
                table: "CustomerPaymentMethods");

            migrationBuilder.RenameTable(
                name: "PaymentMethodHistories",
                newName: "PaymentHistories");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethodHistories_WalletId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethodHistories_PromotionId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_PromotionId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethodHistories_PaymentMethodId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethodHistories_OrderId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethodHistories_CustomerUserId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_CustomerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethodHistories_CustomerPaymentMethodId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_CustomerPaymentMethodId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Wallets",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "UserReports",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "UserPromotions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Stores",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "StoreAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Stocks",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "StockHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Reports",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Promotions",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "VariantName",
                table: "ProductVariants",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductVariants",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductVariants",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductReviews",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductReports",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductPromotions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 97);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModificationById",
                table: "ProductPromotions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 98);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductPromotions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 99);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeleteById",
                table: "ProductPromotions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductPromotions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 95);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "ProductPromotions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 96);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "ProductItems",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalPrice",
                table: "ProductItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductItems",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductItems",
                type: "boolean",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountedPrice",
                table: "ProductItems",
                type: "numeric(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "ProductImages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "ProductImages",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductImages",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ProductImages",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "ProductImages",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "PaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "OTPData",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "OrderStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "OrderDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerRanks",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerPaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "CustomerPaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Conversations",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ConversationMembers",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Consultations",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "CartItem",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Cart",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Addresses",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "PaymentHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPromotions",
                table: "ProductPromotions",
                columns: new[] { "ProductId", "PromotionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentHistories",
                table: "PaymentHistories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "e8c0566e-8592-4ae3-835a-fc32683cfb81", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "AQAAAAIAAYagAAAAEAB4MIoYu22wkakMr7DAOVyUVeiiNxUEItF6hTfHpY5o4wmdOei89I8MWazPY0JOug==" });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7776));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222242"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222243"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7782));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333353"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7784));

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333354"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7786));

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Address", "CreationDate", "DistrictId", "ProvinceName", "WardCode", "WardName" },
                values: new object[] { "123 Đường Độc Lập", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "TP.HCM", "00001", "Phường 1" });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "CreationDate",
                value: new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_CustomerPaymentMethods_CustomerPaymentMeth~",
                table: "PaymentHistories",
                column: "CustomerPaymentMethodId",
                principalTable: "CustomerPaymentMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_CustomerUsers_CustomerUserId",
                table: "PaymentHistories",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_Orders_OrderId",
                table: "PaymentHistories",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_PaymentMethods_PaymentMethodId",
                table: "PaymentHistories",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_Promotions_PromotionId",
                table: "PaymentHistories",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_Wallets_WalletId",
                table: "PaymentHistories",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_CustomerPaymentMethods_CustomerPaymentMeth~",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_CustomerUsers_CustomerUserId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_Orders_OrderId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_PaymentMethods_PaymentMethodId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_Promotions_PromotionId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_Wallets_WalletId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StoreId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPromotions",
                table: "ProductPromotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentHistories",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "PaymentHistories",
                newName: "PaymentMethodHistories");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_WalletId",
                table: "PaymentMethodHistories",
                newName: "IX_PaymentMethodHistories_WalletId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_PromotionId",
                table: "PaymentMethodHistories",
                newName: "IX_PaymentMethodHistories_PromotionId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_PaymentMethodId",
                table: "PaymentMethodHistories",
                newName: "IX_PaymentMethodHistories_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_OrderId",
                table: "PaymentMethodHistories",
                newName: "IX_PaymentMethodHistories_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_CustomerUserId",
                table: "PaymentMethodHistories",
                newName: "IX_PaymentMethodHistories_CustomerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_CustomerPaymentMethodId",
                table: "PaymentMethodHistories",
                newName: "IX_PaymentMethodHistories_CustomerPaymentMethodId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Wallets",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "UserReports",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "UserPromotions",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Stores",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "StoreAddresses",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Stocks",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "StockHistories",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Reports",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Promotions",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "VariantName",
                table: "ProductVariants",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductVariants",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductVariants",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductVariants",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Products",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductReviews",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductReports",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductPromotions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModificationById",
                table: "ProductPromotions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductPromotions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeleteById",
                table: "ProductPromotions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductPromotions",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "ProductPromotions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProductPromotions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductPromotions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductPromotions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PromotionId1",
                table: "ProductPromotions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SKU",
                table: "ProductItems",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "OriginalPrice",
                table: "ProductItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductItems",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductItems",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DiscountedPrice",
                table: "ProductItems",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "ProductItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "ProductImages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMain",
                table: "ProductImages",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ProductImages",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ProductImages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "ProductImages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "PaymentMethods",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "OTPData",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "OrderStatuses",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Orders",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "OrderDetails",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Messages",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerRanks",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerPaymentMethods",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDefault",
                table: "CustomerPaymentMethods",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerUserId",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId1",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerAddresses",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Conversations",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "ConversationMembers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Consultations",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Categories",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "CartItem",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Cart",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "Addresses",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsHardDelete",
                table: "PaymentMethodHistories",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPromotions",
                table: "ProductPromotions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethodHistories",
                table: "PaymentMethodHistories",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "437c89a4-6cd4-4f97-94e6-6be67c8e056f", new DateTime(2025, 7, 15, 13, 5, 19, 76, DateTimeKind.Utc).AddTicks(5020), "AQAAAAIAAYagAAAAEAUkz2vCBhY+gykPhZMUdwWKnkQqWMX1FjtggImuF+XaKDhieSvyNK6MlBbAvg+PTg==" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ApprovedById", "ApprovedUserId", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "ImageUrl", "IsHardDelete", "ModificationById", "ModificationDate", "Name", "ParentCategoryId", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7737), null, null, "Các thiết bị y tế hỗ trợ chăm sóc sức khỏe người cao tuổi", null, false, null, null, "Thiết bị y tế", null, "Active" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7744), null, null, "Thực phẩm bổ sung dinh dưỡng cho người cao tuổi", null, false, null, null, "Thực phẩm dinh dưỡng", null, "Active" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7746), null, null, "Các dụng cụ hỗ trợ sinh hoạt hàng ngày", null, false, null, null, "Dụng cụ hỗ trợ", null, "Active" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7748), null, null, "Các dịch vụ tư vấn chăm sóc sức khỏe", null, false, null, null, "Dịch vụ tư vấn", null, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "ConsultationId", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsActive", "IsHardDelete", "ModificationById", "ModificationDate", "Name", "ProductType", "VideoPath" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111121"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(422), null, null, "Máy đo huyết áp điện tử tự động, dễ sử dụng cho người cao tuổi", true, false, null, null, "Máy đo huyết áp Omron HEM-7130", "Physical", "/videos/products/omron-hem-7130.mp4" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(468), null, null, "Máy đo đường huyết chính xác, ít đau khi lấy máu", true, false, null, null, "Máy đo đường huyết Accu-Chek Guide", "Physical", "/videos/products/accu-chek-guide.mp4" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(472), null, null, "Máy xông mũi họng siêu âm, hiệu quả cao", true, false, null, null, "Máy xông mũi họng Omron NE-C28", "Physical", "/videos/products/omron-ne-c28.mp4" },
                    { new Guid("22222222-2222-2222-2222-222222222225"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(476), null, null, "Sữa dinh dưỡng bổ sung protein và vitamin cho người cao tuổi", true, false, null, null, "Sữa Ensure Gold", "Consumable", "/videos/products/ensure-gold.mp4" },
                    { new Guid("22222222-2222-2222-2222-222222222226"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(482), null, null, "Bổ sung vitamin D3 và K2 cho xương khớp", true, false, null, null, "Vitamin D3 + K2", "Consumable", "/videos/products/vitamin-d3-k2.mp4" },
                    { new Guid("33333333-3333-3333-3333-333333333336"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(492), null, null, "Gậy chống 4 chân chống trượt, an toàn cho người cao tuổi", true, false, null, null, "Gậy chống 4 chân", "Physical", "/videos/products/gay-chong-4-chan.mp4" },
                    { new Guid("33333333-3333-3333-3333-333333333337"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(496), null, null, "Xe lăn tay gấp gọn, nhẹ và dễ di chuyển", true, false, null, null, "Xe lăn tay gấp gọn", "Physical", "/videos/products/xe-lan-tay.mp4" },
                    { new Guid("44444444-4444-4444-4444-444444444445"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(499), null, null, "Dịch vụ tư vấn dinh dưỡng trực tuyến với chuyên gia", true, false, null, null, "Tư vấn dinh dưỡng online", "Service", "/videos/services/tu-van-dinh-duong.mp4" },
                    { new Guid("44444444-4444-4444-4444-444444444446"), null, null, new DateTime(2025, 7, 15, 13, 5, 19, 27, DateTimeKind.Utc).AddTicks(504), null, null, "Gói khám sức khỏe định kỳ cho người cao tuổi", true, false, null, null, "Khám sức khỏe định kỳ", "Service", "/videos/services/kham-suc-khoe.mp4" }
                });

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
                columns: new[] { "Address", "CreationDate", "DistrictId", "ProvinceName", "WardCode", "WardName" },
                values: new object[] { "123 Đường Lê Lợi", new DateTime(2025, 7, 15, 13, 5, 19, 30, DateTimeKind.Utc).AddTicks(8181), 7601, "TP. Hồ Chí Minh", "7601001", "Bến Nghé" });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "CreationDate",
                value: new DateTime(2025, 7, 15, 13, 5, 19, 35, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ApprovedById", "ApprovedUserId", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "ImageUrl", "IsHardDelete", "ModificationById", "ModificationDate", "Name", "ParentCategoryId", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111112"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7752), null, null, "Các loại máy đo huyết áp điện tử", null, false, null, null, "Máy đo huyết áp", new Guid("11111111-1111-1111-1111-111111111111"), "Active" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7762), null, null, "Thiết bị đo đường huyết tại nhà", null, false, null, null, "Máy đo đường huyết", new Guid("11111111-1111-1111-1111-111111111111"), "Active" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7764), null, null, "Thiết bị xông mũi họng tại nhà", null, false, null, null, "Máy xông mũi họng", new Guid("11111111-1111-1111-1111-111111111111"), "Active" },
                    { new Guid("22222222-2222-2222-2222-222222222223"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7799), null, null, "Các loại sữa bổ sung dinh dưỡng", null, false, null, null, "Sữa dinh dưỡng", new Guid("22222222-2222-2222-2222-222222222222"), "Active" },
                    { new Guid("22222222-2222-2222-2222-222222222224"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7802), null, null, "Thực phẩm chức năng bổ sung vitamin", null, false, null, null, "Vitamin và khoáng chất", new Guid("22222222-2222-2222-2222-222222222222"), "Active" },
                    { new Guid("33333333-3333-3333-3333-333333333334"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7805), null, null, "Các loại gậy hỗ trợ đi lại", null, false, null, null, "Gậy chống", new Guid("33333333-3333-3333-3333-333333333333"), "Active" },
                    { new Guid("33333333-3333-3333-3333-333333333335"), null, null, null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7809), null, null, "Xe lăn hỗ trợ di chuyển", null, false, null, null, "Xe lăn", new Guid("33333333-3333-3333-3333-333333333333"), "Active" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "IsHardDelete", "ModificationById", "ModificationDate" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444445"), null, null, null, null, false, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444446"), null, null, null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "IsActive", "IsHardDelete", "ModificationById", "ModificationDate", "ProductId", "ProductId1", "VariantName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111131"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7318), null, null, true, false, null, null, new Guid("11111111-1111-1111-1111-111111111121"), null, "Máy đo huyết áp Omron HEM-7130 - Màu trắng" },
                    { new Guid("11111111-1111-1111-1111-111111111132"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7333), null, null, true, false, null, null, new Guid("11111111-1111-1111-1111-111111111121"), null, "Máy đo huyết áp Omron HEM-7130 - Màu xanh" },
                    { new Guid("11111111-1111-1111-1111-111111111133"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7338), null, null, true, false, null, null, new Guid("11111111-1111-1111-1111-111111111122"), null, "Máy đo đường huyết Accu-Chek Guide - Bộ cơ bản" },
                    { new Guid("11111111-1111-1111-1111-111111111134"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7341), null, null, true, false, null, null, new Guid("11111111-1111-1111-1111-111111111122"), null, "Máy đo đường huyết Accu-Chek Guide - Bộ đầy đủ" },
                    { new Guid("22222222-2222-2222-2222-222222222227"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7350), null, null, true, false, null, null, new Guid("22222222-2222-2222-2222-222222222225"), null, "Sữa Ensure Gold - Hộp 400g" },
                    { new Guid("22222222-2222-2222-2222-222222222228"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7352), null, null, true, false, null, null, new Guid("22222222-2222-2222-2222-222222222225"), null, "Sữa Ensure Gold - Hộp 850g" },
                    { new Guid("22222222-2222-2222-2222-222222222229"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7400), null, null, true, false, null, null, new Guid("22222222-2222-2222-2222-222222222226"), null, "Vitamin D3+K2 - Lọ 60 viên" },
                    { new Guid("33333333-3333-3333-3333-333333333338"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7403), null, null, true, false, null, null, new Guid("33333333-3333-3333-3333-333333333336"), null, "Gậy chống 4 chân - Màu đen" },
                    { new Guid("33333333-3333-3333-3333-333333333339"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7406), null, null, true, false, null, null, new Guid("33333333-3333-3333-3333-333333333336"), null, "Gậy chống 4 chân - Màu xanh" },
                    { new Guid("33333333-3333-3333-3333-333333333340"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7409), null, null, true, false, null, null, new Guid("33333333-3333-3333-3333-333333333337"), null, "Xe lăn tay gấp gọn - Màu xanh" },
                    { new Guid("44444444-4444-4444-4444-444444444447"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7414), null, null, true, false, null, null, new Guid("44444444-4444-4444-4444-444444444445"), null, "Tư vấn dinh dưỡng - 1 buổi" },
                    { new Guid("44444444-4444-4444-4444-444444444448"), null, new DateTime(2025, 7, 15, 13, 5, 19, 28, DateTimeKind.Utc).AddTicks(7418), null, null, true, false, null, null, new Guid("44444444-4444-4444-4444-444444444445"), null, "Tư vấn dinh dưỡng - Gói 5 buổi" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "IsHardDelete", "ModificationById", "ModificationDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111121"), null, null, null, null, false, null, null },
                    { new Guid("11111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111122"), null, null, null, null, false, null, null },
                    { new Guid("11111111-1111-1111-1111-111111111114"), new Guid("11111111-1111-1111-1111-111111111123"), null, null, null, null, false, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222223"), new Guid("22222222-2222-2222-2222-222222222225"), null, null, null, null, false, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222224"), new Guid("22222222-2222-2222-2222-222222222226"), null, null, null, null, false, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333334"), new Guid("33333333-3333-3333-3333-333333333336"), null, null, null, null, false, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333335"), new Guid("33333333-3333-3333-3333-333333333337"), null, null, null, null, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "DiscountedPrice", "Height", "IsActive", "IsHardDelete", "Length", "ModificationById", "ModificationDate", "OriginalPrice", "SKU", "StockId", "StoreId", "VariantId", "Weight", "Width" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111141"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1311), null, null, 800000m, 10, true, false, 20, null, null, 850000m, "OMRON-HEM-7130-WHITE-DL", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("11111111-1111-1111-1111-111111111131"), 500, 15 },
                    { new Guid("11111111-1111-1111-1111-111111111142"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1321), null, null, 1100000m, 5, true, false, 15, null, null, 1200000m, "ACCU-CHEK-GUIDE-BASIC-DL", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("11111111-1111-1111-1111-111111111133"), 300, 10 },
                    { new Guid("22222222-2222-2222-2222-222222222230"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1327), null, null, 250000m, 6, true, false, 12, null, null, 280000m, "ENSURE-GOLD-400G-DL", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("22222222-2222-2222-2222-222222222227"), 400, 8 },
                    { new Guid("22222222-2222-2222-2222-222222222231"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1332), null, null, 160000m, 3, true, false, 8, null, null, 180000m, "VITAMIN-D3-K2-60-DL", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("22222222-2222-2222-2222-222222222229"), 100, 5 },
                    { new Guid("33333333-3333-3333-3333-333333333341"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1337), null, null, 420000m, 5, true, false, 120, null, null, 450000m, "GAY-CHONG-4-CHAN-BLACK-DL", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("33333333-3333-3333-3333-333333333338"), 800, 5 },
                    { new Guid("33333333-3333-3333-3333-333333333342"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(1341), null, null, 2600000m, 90, true, false, 100, null, null, 2800000m, "XE-LAN-TAY-XANH-DL", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("33333333-3333-3333-3333-333333333340"), 15000, 60 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ImageName", "ImagePath", "IsHardDelete", "IsMain", "ModificationById", "ModificationDate", "Order", "ProductId", "ProductItemId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111151"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4123), null, null, "Máy đo huyết áp Omron HEM-7130 - Ảnh 1", "/images/products/omron-hem-7130-white-1.jpg", false, false, null, null, 0, null, new Guid("11111111-1111-1111-1111-111111111141") },
                    { new Guid("11111111-1111-1111-1111-111111111152"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4129), null, null, "Máy đo huyết áp Omron HEM-7130 - Ảnh 2", "/images/products/omron-hem-7130-white-2.jpg", false, false, null, null, 0, null, new Guid("11111111-1111-1111-1111-111111111141") },
                    { new Guid("22222222-2222-2222-2222-222222222232"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4136), null, null, "Sữa Ensure Gold 400g - Ảnh 1", "/images/products/ensure-gold-400g-1.jpg", false, false, null, null, 0, null, new Guid("22222222-2222-2222-2222-222222222230") },
                    { new Guid("33333333-3333-3333-3333-333333333343"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4139), null, null, "Gậy chống 4 chân đen - Ảnh 1", "/images/products/gay-chong-4-chan-black-1.jpg", false, false, null, null, 0, null, new Guid("33333333-3333-3333-3333-333333333341") },
                    { new Guid("33333333-3333-3333-3333-333333333344"), null, new DateTime(2025, 7, 15, 13, 5, 19, 29, DateTimeKind.Utc).AddTicks(4142), null, null, "Xe lăn tay xanh - Ảnh 1", "/images/products/xe-lan-tay-xanh-1.jpg", false, false, null, null, 0, null, new Guid("33333333-3333-3333-3333-333333333342") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId1",
                table: "ProductVariants",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotions_ProductId",
                table: "ProductPromotions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotions_ProductId1",
                table: "ProductPromotions",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotions_PromotionId1",
                table: "ProductPromotions",
                column: "PromotionId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_StoreId",
                table: "ProductItems",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentMethods_CustomerUserId",
                table: "CustomerPaymentMethods",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentMethods_PaymentMethodId1",
                table: "CustomerPaymentMethods",
                column: "PaymentMethodId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaymentMethods_CustomerUsers_CustomerUserId",
                table: "CustomerPaymentMethods",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaymentMethods_PaymentMethods_PaymentMethodId1",
                table: "CustomerPaymentMethods",
                column: "PaymentMethodId1",
                principalTable: "PaymentMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethodHistories_CustomerPaymentMethods_CustomerPayme~",
                table: "PaymentMethodHistories",
                column: "CustomerPaymentMethodId",
                principalTable: "CustomerPaymentMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethodHistories_CustomerUsers_CustomerUserId",
                table: "PaymentMethodHistories",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethodHistories_Orders_OrderId",
                table: "PaymentMethodHistories",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethodHistories_PaymentMethods_PaymentMethodId",
                table: "PaymentMethodHistories",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethodHistories_Promotions_PromotionId",
                table: "PaymentMethodHistories",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethodHistories_Wallets_WalletId",
                table: "PaymentMethodHistories",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductItems_ProductItemId",
                table: "ProductImages",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Stores_StoreId",
                table: "ProductItems",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPromotions_Products_ProductId1",
                table: "ProductPromotions",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPromotions_Promotions_PromotionId1",
                table: "ProductPromotions",
                column: "PromotionId1",
                principalTable: "Promotions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Products_ProductId1",
                table: "ProductVariants",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
