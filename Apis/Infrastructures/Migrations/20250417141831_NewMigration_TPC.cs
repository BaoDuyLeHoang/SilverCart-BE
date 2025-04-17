using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration_TPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_BaseFullEntity_Id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_AdministratorUser_Users_Id",
                table: "AdministratorUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AdministratorUserRole_Roles_Id",
                table: "AdministratorUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseFullEntity_BaseEntity_Id",
                table: "BaseFullEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_BaseFullEntity_Id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_BaseFullEntity_Id",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_BaseFullEntity_Id",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddress_BaseFullEntity_Id",
                table: "CustomerAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethod_BaseFullEntity_Id",
                table: "CustomerPaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRank_BaseFullEntity_Id",
                table: "CustomerRank");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_Users_Id",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_BaseFullEntity_Id",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_BaseFullEntity_Id",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderReview_BaseFullEntity_Id",
                table: "OrderReview");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatus_BaseFullEntity_Id",
                table: "OrderStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_BaseFullEntity_Id",
                table: "PaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethodHistory_BaseFullEntity_Id",
                table: "PaymentMethodHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_BaseFullEntity_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_BaseFullEntity_Id",
                table: "ProductImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItem_BaseFullEntity_Id",
                table: "ProductItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromotion_BaseFullEntity_Id",
                table: "ProductPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReport_Report_Id",
                table: "ProductReport");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariant_BaseFullEntity_Id",
                table: "ProductVariant");

            migrationBuilder.DropForeignKey(
                name: "FK_Promotion_BaseFullEntity_Id",
                table: "Promotion");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_BaseFullEntity_Id",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_BaseFullEntity_Id",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledTask_BaseFullEntity_Id",
                table: "ScheduledTask");

            migrationBuilder.DropForeignKey(
                name: "FK_StockHistory_BaseFullEntity_Id",
                table: "StockHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_BaseFullEntity_Id",
                table: "Store");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreRole_Roles_Id",
                table: "StoreRole");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreUser_Users_Id",
                table: "StoreUser");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreUserRole_BaseFullEntity_Id",
                table: "StoreUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPromotion_BaseFullEntity_Id",
                table: "UserPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReport_Report_Id",
                table: "UserReport");

            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorUserId",
                table: "UserReport",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserReport",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserReport",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "UserReport",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "UserReport",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserReport",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "UserReport",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserReport",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "UserReport",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "UserReport",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserReport",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserPromotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "UserPromotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "UserPromotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "UserPromotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserPromotion",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "UserPromotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "UserPromotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StoreUserRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StoreUserRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StoreUserRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreUserRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoreUserRole",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StoreUserRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreUserRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StoreUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StoreUser",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StoreUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreUser",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "StoreUser",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "StoreUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoreUser",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "StoreUser",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "StoreUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StoreUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreUser",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "StoreUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "StoreUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "StoreUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignInTime",
                table: "StoreUser",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StoreRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StoreRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StoreRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "StoreRole",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoreRole",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StoreRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StoreRole",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "StoreRole",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Store",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Store",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Store",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Store",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Store",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Store",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Store",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StockHistory",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StockHistory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StockHistory",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StockHistory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockHistory",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StockHistory",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "StockHistory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ScheduledTask",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ScheduledTask",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ScheduledTask",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ScheduledTask",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ScheduledTask",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ScheduledTask",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ScheduledTask",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Roles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Roles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Report",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Report",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Report",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Report",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Report",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Report",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Report",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Promotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Promotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Promotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Promotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Promotion",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Promotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Promotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductVariant",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductVariant",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductVariant",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductVariant",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductVariant",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductVariant",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductVariant",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorUserId",
                table: "ProductReport",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductReport",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductReport",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductReport",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductReport",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductReport",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "ProductReport",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductReport",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductReport",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductReport",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProductReport",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductPromotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductPromotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductPromotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductPromotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductPromotion",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductPromotion",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductPromotion",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ProductImage",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductImage",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "ProductImage",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductImage",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductImage",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "ProductImage",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductImage",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Product",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Product",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Product",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Product",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "PaymentMethodHistory",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PaymentMethodHistory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "PaymentMethodHistory",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "PaymentMethodHistory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PaymentMethodHistory",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "PaymentMethodHistory",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "PaymentMethodHistory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "PaymentMethod",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PaymentMethod",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "PaymentMethod",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "PaymentMethod",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PaymentMethod",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "PaymentMethod",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "PaymentMethod",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "OrderStatus",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OrderStatus",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "OrderStatus",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "OrderStatus",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderStatus",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "OrderStatus",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "OrderStatus",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "OrderReview",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OrderReview",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "OrderReview",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "OrderReview",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderReview",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "OrderReview",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "OrderReview",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "OrderItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "OrderItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "OrderItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "OrderItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "OrderItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "OrderItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Order",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Order",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Order",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Order",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Order",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Order",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Order",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CustomerUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CustomerUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CustomerUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "CustomerUsers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "CustomerUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "CustomerUsers",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "CustomerUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CustomerUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CustomerUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "CustomerUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CustomerUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "CustomerUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignInTime",
                table: "CustomerUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CustomerRank",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerRank",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CustomerRank",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CustomerRank",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerRank",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CustomerRank",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CustomerRank",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CustomerPaymentMethod",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerPaymentMethod",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CustomerPaymentMethod",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CustomerPaymentMethod",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerPaymentMethod",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CustomerPaymentMethod",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CustomerPaymentMethod",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CustomerAddress",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CustomerAddress",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CustomerAddress",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CustomerAddress",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CustomerAddress",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CustomerAddress",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CustomerAddress",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Category",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Category",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Category",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Category",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Category",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Category",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Category",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CartItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CartItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "CartItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "CartItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CartItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "CartItem",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CartItem",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Cart",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Cart",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Cart",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Cart",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Cart",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Cart",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Cart",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BaseFullEntity",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AdministratorUserRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AdministratorUserRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "AdministratorUserRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "AdministratorUserRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AdministratorUserRole",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdministratorUserRole",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "AdministratorUserRole",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "AdministratorUserRole",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AdministratorUserRole",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedName",
                table: "AdministratorUserRole",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AdministratorUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AdministratorUser",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "AdministratorUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "AdministratorUser",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AdministratorUser",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AdministratorUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdministratorUser",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "AdministratorUser",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AdministratorUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "AdministratorUser",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "AdministratorUser",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AdministratorUser",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AdministratorUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AdministratorUser",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignInTime",
                table: "AdministratorUser",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Address",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Address",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "Address",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "Address",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Address",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "Address",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Address",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserReport_AdministratorUserId",
                table: "UserReport",
                column: "AdministratorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReport_AdministratorUserId",
                table: "ProductReport",
                column: "AdministratorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReport_AdministratorUser_AdministratorUserId",
                table: "ProductReport",
                column: "AdministratorUserId",
                principalTable: "AdministratorUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReport_AdministratorUser_AdministratorUserId",
                table: "UserReport",
                column: "AdministratorUserId",
                principalTable: "AdministratorUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductReport_AdministratorUser_AdministratorUserId",
                table: "ProductReport");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReport_AdministratorUser_AdministratorUserId",
                table: "UserReport");

            migrationBuilder.DropIndex(
                name: "IX_UserReport_AdministratorUserId",
                table: "UserReport");

            migrationBuilder.DropIndex(
                name: "IX_ProductReport_AdministratorUserId",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "AdministratorUserId",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserReport");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserPromotion");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "UserPromotion");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "UserPromotion");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "UserPromotion");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserPromotion");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "UserPromotion");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "UserPromotion");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StoreUserRole");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StoreUserRole");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StoreUserRole");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StoreUserRole");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoreUserRole");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StoreUserRole");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "StoreUserRole");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "SignInTime",
                table: "StoreUser");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "StoreRole");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StockHistory");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StockHistory");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StockHistory");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StockHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockHistory");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StockHistory");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "StockHistory");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ScheduledTask");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ScheduledTask");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ScheduledTask");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ScheduledTask");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ScheduledTask");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ScheduledTask");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ScheduledTask");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductVariant");

            migrationBuilder.DropColumn(
                name: "AdministratorUserId",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProductReport");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductPromotion");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductPromotion");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductPromotion");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductPromotion");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductPromotion");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductPromotion");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductPromotion");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductItem");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PaymentMethodHistory");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PaymentMethodHistory");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "PaymentMethodHistory");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "PaymentMethodHistory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PaymentMethodHistory");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "PaymentMethodHistory");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "PaymentMethodHistory");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "PaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "OrderReview");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OrderReview");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "OrderReview");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "OrderReview");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderReview");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "OrderReview");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "OrderReview");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "SignInTime",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CustomerRank");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CustomerRank");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "CustomerRank");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "CustomerRank");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerRank");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "CustomerRank");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CustomerRank");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CustomerPaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CustomerPaymentMethod");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "CustomerPaymentMethod");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "CustomerPaymentMethod");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerPaymentMethod");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "CustomerPaymentMethod");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CustomerPaymentMethod");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Category");

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
                name: "ModificationById",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BaseFullEntity");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "NormalizedName",
                table: "AdministratorUserRole");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "SignInTime",
                table: "AdministratorUser");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Address");

            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    SignInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_BaseFullEntity_Id",
                table: "Address",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorUser_Users_Id",
                table: "AdministratorUser",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorUserRole_Roles_Id",
                table: "AdministratorUserRole",
                column: "Id",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseFullEntity_BaseEntity_Id",
                table: "BaseFullEntity",
                column: "Id",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_BaseFullEntity_Id",
                table: "Cart",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_BaseFullEntity_Id",
                table: "CartItem",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_BaseFullEntity_Id",
                table: "Category",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddress_BaseFullEntity_Id",
                table: "CustomerAddress",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaymentMethod_BaseFullEntity_Id",
                table: "CustomerPaymentMethod",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRank_BaseFullEntity_Id",
                table: "CustomerRank",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_Users_Id",
                table: "CustomerUsers",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_BaseFullEntity_Id",
                table: "Order",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_BaseFullEntity_Id",
                table: "OrderItem",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderReview_BaseFullEntity_Id",
                table: "OrderReview",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatus_BaseFullEntity_Id",
                table: "OrderStatus",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_BaseFullEntity_Id",
                table: "PaymentMethod",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethodHistory_BaseFullEntity_Id",
                table: "PaymentMethodHistory",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_BaseFullEntity_Id",
                table: "Product",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_BaseFullEntity_Id",
                table: "ProductImage",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItem_BaseFullEntity_Id",
                table: "ProductItem",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPromotion_BaseFullEntity_Id",
                table: "ProductPromotion",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReport_Report_Id",
                table: "ProductReport",
                column: "Id",
                principalTable: "Report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariant_BaseFullEntity_Id",
                table: "ProductVariant",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promotion_BaseFullEntity_Id",
                table: "Promotion",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Report_BaseFullEntity_Id",
                table: "Report",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_BaseFullEntity_Id",
                table: "Roles",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledTask_BaseFullEntity_Id",
                table: "ScheduledTask",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockHistory_BaseFullEntity_Id",
                table: "StockHistory",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_BaseFullEntity_Id",
                table: "Store",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreRole_Roles_Id",
                table: "StoreRole",
                column: "Id",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUser_Users_Id",
                table: "StoreUser",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUserRole_BaseFullEntity_Id",
                table: "StoreUserRole",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPromotion_BaseFullEntity_Id",
                table: "UserPromotion",
                column: "Id",
                principalTable: "BaseFullEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReport_Report_Id",
                table: "UserReport",
                column: "Id",
                principalTable: "Report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
