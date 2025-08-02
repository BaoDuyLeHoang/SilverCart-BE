using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class TPT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReports_AdministratorUsers_AdministratorUserId",
                table: "ProductReports");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReports_AdministratorUsers_AdministratorUserId",
                table: "UserReports");

            migrationBuilder.DropIndex(
                name: "IX_UserReports_AdministratorUserId",
                table: "UserReports");

            migrationBuilder.DropIndex(
                name: "IX_ProductReports_AdministratorUserId",
                table: "ProductReports");

            migrationBuilder.DeleteData(
                table: "AdministratorUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"));

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "AdministratorUserId",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductReviews");

            migrationBuilder.DropColumn(
                name: "AdministratorUserId",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ConversationMembers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ConversationMembers");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ConversationMembers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ConversationMembers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ConversationMembers");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ConversationMembers");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ConversationMembers");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ConversationMembers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "BaseEntity",
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
                    IsHardDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BaseEntity",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111161"), null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7776), null, null, null, null },
                    { new Guid("11111111-1111-1111-1111-111111111162"), null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7778), null, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222242"), null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7780), null, null, null, null },
                    { new Guid("22222222-2222-2222-2222-222222222243"), null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7782), null, null, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333353"), null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7784), null, null, null, null },
                    { new Guid("33333333-3333-3333-3333-333333333354"), null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7786), null, null, null, null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, null },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_BaseEntity_Id",
                table: "Addresses",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_BaseEntity_Id",
                table: "Cart",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_BaseEntity_Id",
                table: "CartItem",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_BaseEntity_Id",
                table: "Categories",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_BaseEntity_Id",
                table: "Consultations",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationMembers_BaseEntity_Id",
                table: "ConversationMembers",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_BaseEntity_Id",
                table: "Conversations",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_BaseEntity_Id",
                table: "CustomerAddresses",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaymentMethods_BaseEntity_Id",
                table: "CustomerPaymentMethods",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRanks_BaseEntity_Id",
                table: "CustomerRanks",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_BaseEntity_Id",
                table: "Messages",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_BaseEntity_Id",
                table: "OrderDetails",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BaseEntity_Id",
                table: "Orders",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatuses_BaseEntity_Id",
                table: "OrderStatuses",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OTPData_BaseEntity_Id",
                table: "OTPData",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_BaseEntity_Id",
                table: "PaymentHistories",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_BaseEntity_Id",
                table: "PaymentMethods",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_BaseEntity_Id",
                table: "ProductImages",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_BaseEntity_Id",
                table: "ProductItems",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReports_Reports_Id",
                table: "ProductReports",
                column: "Id",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_BaseEntity_Id",
                table: "ProductReviews",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BaseEntity_Id",
                table: "Products",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_BaseEntity_Id",
                table: "ProductVariants",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_BaseEntity_Id",
                table: "Promotions",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_BaseEntity_Id",
                table: "Reports",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistories_BaseEntity_Id",
                table: "StockHistories",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_BaseEntity_Id",
                table: "Stocks",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreAddresses_BaseEntity_Id",
                table: "StoreAddresses",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_BaseEntity_Id",
                table: "Stores",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPromotions_BaseEntity_Id",
                table: "UserPromotions",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReports_Reports_Id",
                table: "UserReports",
                column: "Id",
                principalTable: "Reports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_BaseEntity_Id",
                table: "Wallets",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_BaseEntity_Id",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_BaseEntity_Id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_BaseEntity_Id",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_BaseEntity_Id",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_BaseEntity_Id",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationMembers_BaseEntity_Id",
                table: "ConversationMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_BaseEntity_Id",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_BaseEntity_Id",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethods_BaseEntity_Id",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRanks_BaseEntity_Id",
                table: "CustomerRanks");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_BaseEntity_Id",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_BaseEntity_Id",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BaseEntity_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatuses_BaseEntity_Id",
                table: "OrderStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_OTPData_BaseEntity_Id",
                table: "OTPData");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_BaseEntity_Id",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_BaseEntity_Id",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_BaseEntity_Id",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_BaseEntity_Id",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReports_Reports_Id",
                table: "ProductReports");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_BaseEntity_Id",
                table: "ProductReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_BaseEntity_Id",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_BaseEntity_Id",
                table: "ProductVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_BaseEntity_Id",
                table: "Promotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_BaseEntity_Id",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_StockHistories_BaseEntity_Id",
                table: "StockHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_BaseEntity_Id",
                table: "Stocks");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreAddresses_BaseEntity_Id",
                table: "StoreAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_BaseEntity_Id",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPromotions_BaseEntity_Id",
                table: "UserPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReports_Reports_Id",
                table: "UserReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_BaseEntity_Id",
                table: "Wallets");

            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Wallets",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Wallets",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Wallets",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Wallets",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Wallets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Wallets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Wallets",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Wallets",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorUserId",
                table: "UserReports",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserReports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserReports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "UserReports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "UserReports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserReports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "UserReports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "UserReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "UserReports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "UserReports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserReports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserPromotions",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserPromotions",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "UserPromotions",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "UserPromotions",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserPromotions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "UserPromotions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "UserPromotions",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "UserPromotions",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Stores",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Stores",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Stores",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Stores",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Stores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Stores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Stores",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Stores",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StoreAddresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StoreAddresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StoreAddresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreAddresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoreAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "StoreAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StoreAddresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreAddresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Stocks",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Stocks",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Stocks",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Stocks",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Stocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Stocks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Stocks",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Stocks",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StockHistories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StockHistories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StockHistories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StockHistories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "StockHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StockHistories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "StockHistories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Reports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Reports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Reports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Reports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Reports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Reports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Reports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Promotions",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Promotions",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Promotions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Promotions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Promotions",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductVariants",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductVariants",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductVariants",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductVariants",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductVariants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductVariants",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductVariants",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductVariants",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Products",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Products",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Products",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductReviews",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductReviews",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductReviews",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductReviews",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductReviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductReviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductReviews",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductReviews",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorUserId",
                table: "ProductReports",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductReports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductReports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductReports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductReports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductReports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "ProductReports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductReports",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductReports",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProductReports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductItems",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductItems",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductItems",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductItems",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductItems",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductItems",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductImages",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductImages",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductImages",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductImages",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductImages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductImages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductImages",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductImages",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "PaymentMethods",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PaymentMethods",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "PaymentMethods",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "PaymentMethods",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "PaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "PaymentMethods",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "PaymentMethods",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "PaymentHistories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PaymentHistories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "PaymentHistories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "PaymentHistories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PaymentHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "PaymentHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "PaymentHistories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "PaymentHistories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "OTPData",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OTPData",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "OTPData",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "OTPData",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OTPData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "OTPData",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "OTPData",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "OTPData",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "OrderStatuses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OrderStatuses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "OrderStatuses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "OrderStatuses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "OrderStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "OrderStatuses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "OrderStatuses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Orders",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Orders",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Orders",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "OrderDetails",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OrderDetails",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "OrderDetails",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "OrderDetails",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "OrderDetails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "OrderDetails",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "OrderDetails",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Messages",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Messages",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Messages",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Messages",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Messages",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CustomerRanks",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerRanks",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CustomerRanks",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CustomerRanks",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerRanks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerRanks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CustomerRanks",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CustomerRanks",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerPaymentMethods",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CustomerPaymentMethods",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerPaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerPaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CustomerPaymentMethods",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CustomerAddresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerAddresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CustomerAddresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CustomerAddresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CustomerAddresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CustomerAddresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Conversations",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Conversations",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Conversations",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Conversations",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Conversations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Conversations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Conversations",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Conversations",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ConversationMembers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ConversationMembers",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ConversationMembers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ConversationMembers",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ConversationMembers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ConversationMembers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ConversationMembers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ConversationMembers",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Consultations",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Consultations",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Consultations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Consultations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Consultations",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Categories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Categories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Categories",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CartItem",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CartItem",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CartItem",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CartItem",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CartItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "CartItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CartItem",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CartItem",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Cart",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Cart",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Cart",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Cart",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cart",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Cart",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Cart",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Cart",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Addresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Addresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Addresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Addresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Addresses",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Email", "EmailConfirmed", "FullName", "Gender", "IsDeleted", "IsHardDelete", "LockoutEnabled", "LockoutEnd", "ModificationById", "ModificationDate", "NormalizedEmail", "NormalizedUserName", "OTPId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"), 0, "e8c0566e-8592-4ae3-835a-fc32683cfb81", null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "admin@elderly.com", true, "Super Admin", "Other", false, false, false, null, null, null, "ADMIN@ELDERLY.COM", "SUPERADMIN", null, "AQAAAAIAAYagAAAAEAB4MIoYu22wkakMr7DAOVyUVeiiNxUEItF6hTfHpY5o4wmdOei89I8MWazPY0JOug==", null, false, null, null, false, "superadmin" });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"),
                columns: new[] { "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[] { null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7776), null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"),
                columns: new[] { "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[] { null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7778), null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222242"),
                columns: new[] { "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[] { null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7780), null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222243"),
                columns: new[] { "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[] { null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7782), null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333353"),
                columns: new[] { "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[] { null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7784), null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333354"),
                columns: new[] { "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[] { null, new DateTime(2025, 7, 15, 13, 5, 19, 9, DateTimeKind.Utc).AddTicks(7786), null, null, null, null });

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[] { null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                columns: new[] { "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[] { null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, null, null });

            migrationBuilder.InsertData(
                table: "AdministratorUsers",
                columns: new[] { "Id", "RoleId" },
                values: new object[] { new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"), null });

            migrationBuilder.CreateIndex(
                name: "IX_UserReports_AdministratorUserId",
                table: "UserReports",
                column: "AdministratorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReports_AdministratorUserId",
                table: "ProductReports",
                column: "AdministratorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReports_AdministratorUsers_AdministratorUserId",
                table: "ProductReports",
                column: "AdministratorUserId",
                principalTable: "AdministratorUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReports_AdministratorUsers_AdministratorUserId",
                table: "UserReports",
                column: "AdministratorUserId",
                principalTable: "AdministratorUsers",
                principalColumn: "Id");
        }
    }
}
