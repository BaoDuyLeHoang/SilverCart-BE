using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Update_New_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Stores_StoreId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_StoreUsers_StoreUserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_ConsultantUsers_ConsultantId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_DependentUsers_CustomerId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_AspNetUsers_User1Id",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_AspNetUsers_User2Id",
                table: "Conversations");

            migrationBuilder.DropTable(
                name: "OrderReviews");

            migrationBuilder.DropTable(
                name: "ScheduledTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_User1Id",
                table: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_Conversations_User2Id",
                table: "Conversations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StoreId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("11111111-1111-1111-1111-111111111163"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("22222222-2222-2222-2222-222222222233"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("22222222-2222-2222-2222-222222222234"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("33333333-3333-3333-3333-333333333345"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("33333333-3333-3333-3333-333333333346"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("44444444-4444-4444-4444-444444444449"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyColumnType: "uuid",
                keyValue: new Guid("44444444-4444-4444-4444-444444444450"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "IconPath",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "User1Id",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "User2Id",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "ConsultationId",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IsBanned",
                table: "Stores",
                newName: "IsHardDelete");

            migrationBuilder.RenameColumn(
                name: "Infomation",
                table: "Stores",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PaymentMethodHistories",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "PaymentMethodHistories",
                newName: "IsHardDelete");

            migrationBuilder.RenameColumn(
                name: "UserRank",
                table: "Orders",
                newName: "PaymentStatus_PaymentStatus");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Consultations",
                newName: "DependentUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_CustomerId",
                table: "Consultations",
                newName: "IX_Consultations_DependentUserId");

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "UserReports",
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
                name: "StoreId",
                table: "StoreUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "StoreUserRoles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Stores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "AvatarPath",
                table: "Stores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorUserId",
                table: "Stores",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WardName",
                table: "StoreAddresses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "WardCode",
                table: "StoreAddresses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceName",
                table: "StoreAddresses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "DistrictName",
                table: "StoreAddresses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StoreAddresses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "StoreAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "StockHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Reports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Promotions",
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
                name: "ProductId1",
                table: "ProductVariants",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultationId",
                table: "Products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
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

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductReports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
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

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductItems",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "StockId",
                table: "ProductItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductImages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "ProductImages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ProductImages",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductCategories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 97);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModificationById",
                table: "ProductCategories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 98);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductCategories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 99);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeleteById",
                table: "ProductCategories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCategories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 95);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "ProductCategories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "ProductCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "PaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PaymentMethodHistories",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerPaymentMethodId",
                table: "PaymentMethodHistories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerUserId",
                table: "PaymentMethodHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "PaymentMethodHistories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "PaymentMethodHistories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PromotionId",
                table: "PaymentMethodHistories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                table: "PaymentMethodHistories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "OTPData",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OTPData",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "OrderStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "OrderGhnCode",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CancelledAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EarnedPoints",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FinalPrice",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Orders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentStatus_Amount",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentStatus_CustomerUserId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentStatus_PayedById",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentStatus_PaymentDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus_PaymentMethod",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingStatus_ShipSource",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShippingStatus_Status",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingStatus_TrackingCode",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingStatus_TrackingMessage",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShippingStatus_TrackingTime",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingStatus_TrackingUrl",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsedPoints",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "OrderDetails",
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
                name: "WalletId",
                table: "CustomerUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerRanks",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerUserId",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerPaymentMethods",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId1",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "CustomerAddresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Conversations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Conversations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Consultations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "CartItem",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreUserId",
                table: "Cart",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<bool>(
                name: "IsConsultantUserRecommend",
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

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Other");

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "AspNetRoles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHardDelete",
                table: "Addresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.CreateTable(
                name: "ConversationMembers",
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
                    IsHardDelete = table.Column<bool>(type: "boolean", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationMembers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationMembers_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
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
                    IsHardDelete = table.Column<bool>(type: "boolean", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_CustomerUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
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
                    IsHardDelete = table.Column<bool>(type: "boolean", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ReservedQuantity = table.Column<int>(type: "integer", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "integer", nullable: false),
                    SoldQuantity = table.Column<int>(type: "integer", nullable: false),
                    ReturnedQuantity = table.Column<int>(type: "integer", nullable: false),
                    DamagedQuantity = table.Column<int>(type: "integer", nullable: false),
                    ProductItemId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
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
                    IsHardDelete = table.Column<bool>(type: "boolean", nullable: false),
                    Balance = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    TotalSpent = table.Column<int>(type: "integer", nullable: false),
                    TotalReceived = table.Column<int>(type: "integer", nullable: false),
                    TotalRefunded = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"),
                column: "IsHardDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"),
                column: "IsHardDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c8499d3-6ec2-4745-b2f7-6e33182f6f6f"),
                column: "IsHardDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"),
                column: "IsHardDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                column: "IsHardDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                column: "IsHardDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                column: "IsHardDelete",
                value: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "IsHardDelete", "PasswordHash" },
                values: new object[] { "bd5692b4-e4cb-4230-af9b-5be397689aab", new DateTime(2025, 7, 12, 17, 31, 33, 469, DateTimeKind.Utc).AddTicks(2705), false, "AQAAAAIAAYagAAAAEFS/qrGaKPFRdTLke/11NXn8ALdaBNYEMaqoFWixh790RIZ0A2wpSy64W9j1BMpcsQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7014), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7056), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7059), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7063), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7022), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7066), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222224"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7070), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7025), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333334"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7072), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333335"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7075), false });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 396, DateTimeKind.Utc).AddTicks(7052), false });

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
                    { new Guid("33333333-3333-3333-3333-333333333335"), new Guid("33333333-3333-3333-3333-333333333337"), null, null, null, null, false, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444445"), null, null, null, null, false, null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("44444444-4444-4444-4444-444444444446"), null, null, null, null, false, null, null }
                });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111151"),
                columns: new[] { "CreationDate", "IsHardDelete", "IsMain", "Order" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9981), false, false, 0 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111152"),
                columns: new[] { "CreationDate", "IsHardDelete", "IsMain", "Order" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9985), false, false, 0 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222232"),
                columns: new[] { "CreationDate", "IsHardDelete", "IsMain", "Order" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9988), false, false, 0 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333343"),
                columns: new[] { "CreationDate", "IsHardDelete", "IsMain", "Order" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9996), false, false, 0 });

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333344"),
                columns: new[] { "CreationDate", "IsHardDelete", "IsMain", "Order" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(9999), false, false, 0 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111141"),
                columns: new[] { "CreationDate", "IsHardDelete", "StockId" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7475), false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"),
                columns: new[] { "CreationDate", "IsHardDelete", "StockId" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7487), false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"),
                columns: new[] { "CreationDate", "IsHardDelete", "StockId" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7491), false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"),
                columns: new[] { "CreationDate", "IsHardDelete", "StockId" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7496), false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"),
                columns: new[] { "CreationDate", "IsHardDelete", "StockId" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7500), false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"),
                columns: new[] { "CreationDate", "IsHardDelete", "StockId" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(7506), false, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4468), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4485), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4490), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4493), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4496), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4504), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4508), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4511), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4513), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4516), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4522), false, null });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"),
                columns: new[] { "CreationDate", "IsHardDelete", "ProductId1" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 416, DateTimeKind.Utc).AddTicks(4524), false, null });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6773), true, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6781), true, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6785), true, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222225"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6789), true, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222226"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6800), true, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333336"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6804), true, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333337"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6807), true, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444445"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6811), true, false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444446"),
                columns: new[] { "ConsultationId", "CreationDate", "IsActive", "IsHardDelete" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 414, DateTimeKind.Utc).AddTicks(6815), true, false });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "AvailableQuantity", "CreatedById", "CreationDate", "DamagedQuantity", "DeleteById", "DeletionDate", "IsHardDelete", "ModificationById", "ModificationDate", "ProductItemId", "Quantity", "ReservedQuantity", "ReturnedQuantity", "SoldQuantity" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111161"), 25, null, new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3117), 0, null, null, false, null, null, new Guid("11111111-1111-1111-1111-111111111141"), 25, 0, 0, 0 },
                    { new Guid("11111111-1111-1111-1111-111111111162"), 15, null, new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3123), 0, null, null, false, null, null, new Guid("11111111-1111-1111-1111-111111111142"), 15, 0, 0, 0 },
                    { new Guid("22222222-2222-2222-2222-222222222242"), 50, null, new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3127), 0, null, null, false, null, null, new Guid("22222222-2222-2222-2222-222222222230"), 50, 0, 0, 0 },
                    { new Guid("22222222-2222-2222-2222-222222222243"), 75, null, new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3130), 0, null, null, false, null, null, new Guid("22222222-2222-2222-2222-222222222231"), 75, 0, 0, 0 },
                    { new Guid("33333333-3333-3333-3333-333333333353"), 20, null, new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3134), 0, null, null, false, null, null, new Guid("33333333-3333-3333-3333-333333333341"), 20, 0, 0, 0 },
                    { new Guid("33333333-3333-3333-3333-333333333354"), 8, null, new DateTime(2025, 7, 12, 17, 31, 33, 423, DateTimeKind.Utc).AddTicks(3145), 0, null, null, false, null, null, new Guid("33333333-3333-3333-3333-333333333342"), 8, 0, 0, 0 }
                });

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "CreationDate", "IsHardDelete" },
                values: new object[] { new DateTime(2025, 7, 12, 17, 31, 33, 418, DateTimeKind.Utc).AddTicks(3886), false });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                columns: new[] { "AdministratorUserId", "CreationDate" },
                values: new object[] { null, new DateTime(2025, 7, 12, 17, 31, 33, 424, DateTimeKind.Utc).AddTicks(1383) });

            migrationBuilder.CreateIndex(
                name: "IX_StoreUsers_StoreId",
                table: "StoreUsers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_AdministratorUserId",
                table: "Stores",
                column: "AdministratorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId1",
                table: "ProductVariants",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ConsultationId",
                table: "Products",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotions_ProductId1",
                table: "ProductPromotions",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotions_PromotionId1",
                table: "ProductPromotions",
                column: "PromotionId1");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodHistories_CustomerPaymentMethodId",
                table: "PaymentMethodHistories",
                column: "CustomerPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodHistories_CustomerUserId",
                table: "PaymentMethodHistories",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodHistories_OrderId",
                table: "PaymentMethodHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodHistories_PromotionId",
                table: "PaymentMethodHistories",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodHistories_WalletId",
                table: "PaymentMethodHistories",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentStatus_CustomerUserId",
                table: "Orders",
                column: "PaymentStatus_CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_WalletId",
                table: "CustomerUsers",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentMethods_CustomerUserId",
                table: "CustomerPaymentMethods",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentMethods_PaymentMethodId1",
                table: "CustomerPaymentMethods",
                column: "PaymentMethodId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMembers_ConversationId",
                table: "ConversationMembers",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMembers_UserId",
                table: "ConversationMembers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_CustomerId",
                table: "ProductReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductItemId",
                table: "Stocks",
                column: "ProductItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_StoreUsers_StoreUserId",
                table: "Cart",
                column: "StoreUserId",
                principalTable: "StoreUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_ConsultantUsers_ConsultantId",
                table: "Consultations",
                column: "ConsultantId",
                principalTable: "ConsultantUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_DependentUsers_DependentUserId",
                table: "Consultations",
                column: "DependentUserId",
                principalTable: "DependentUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_CustomerUsers_Wallets_WalletId",
                table: "CustomerUsers",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerUsers_PaymentStatus_CustomerUserId",
                table: "Orders",
                column: "PaymentStatus_CustomerUserId",
                principalTable: "CustomerUsers",
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
                name: "FK_Products_Consultations_ConsultationId",
                table: "Products",
                column: "ConsultationId",
                principalTable: "Consultations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Products_ProductId1",
                table: "ProductVariants",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AdministratorUsers_AdministratorUserId",
                table: "Stores",
                column: "AdministratorUserId",
                principalTable: "AdministratorUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_Stores_StoreId",
                table: "StoreUsers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_StoreUsers_StoreUserId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_ConsultantUsers_ConsultantId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_DependentUsers_DependentUserId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethods_CustomerUsers_CustomerUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethods_PaymentMethods_PaymentMethodId1",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_Wallets_WalletId",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerUsers_PaymentStatus_CustomerUserId",
                table: "Orders");

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
                name: "FK_PaymentMethodHistories_Promotions_PromotionId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethodHistories_Wallets_WalletId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromotions_Products_ProductId1",
                table: "ProductPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromotions_Promotions_PromotionId1",
                table: "ProductPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Consultations_ConsultationId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Products_ProductId1",
                table: "ProductVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AdministratorUsers_AdministratorUserId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_Stores_StoreId",
                table: "StoreUsers");

            migrationBuilder.DropTable(
                name: "ConversationMembers");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_StoreUsers_StoreId",
                table: "StoreUsers");

            migrationBuilder.DropIndex(
                name: "IX_Stores_AdministratorUserId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ProductId1",
                table: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_Products_ConsultationId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductPromotions_ProductId1",
                table: "ProductPromotions");

            migrationBuilder.DropIndex(
                name: "IX_ProductPromotions_PromotionId1",
                table: "ProductPromotions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethodHistories_CustomerPaymentMethodId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethodHistories_CustomerUserId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethodHistories_OrderId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethodHistories_PromotionId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethodHistories_WalletId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentStatus_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_WalletId",
                table: "CustomerUsers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPaymentMethods_CustomerUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPaymentMethods_PaymentMethodId1",
                table: "CustomerPaymentMethods");

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

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "UserReports");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "StoreUserRoles");

            migrationBuilder.DropColumn(
                name: "AdministratorUserId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "StockHistories");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductVariants");

            migrationBuilder.DropColumn(
                name: "ConsultationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductPromotions");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductPromotions");

            migrationBuilder.DropColumn(
                name: "PromotionId1",
                table: "ProductPromotions");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "CustomerPaymentMethodId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "PaymentMethodHistories");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "PaymentMethodHistories");

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
                name: "IsHardDelete",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "OTPData");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "OrderStatuses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CancelledAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ConfirmedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EarnedPoints",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus_Amount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus_PayedById",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus_PaymentDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus_PaymentMethod",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingStatus_ShipSource",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingStatus_Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingStatus_TrackingCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingStatus_TrackingMessage",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingStatus_TrackingTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingStatus_TrackingUrl",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UsedPoints",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "CustomerRanks");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId1",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "IsConsultantUserRecommend",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "IsHardDelete",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "IsHardDelete",
                table: "Stores",
                newName: "IsBanned");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Stores",
                newName: "Infomation");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "PaymentMethodHistories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "IsHardDelete",
                table: "PaymentMethodHistories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus_PaymentStatus",
                table: "Orders",
                newName: "UserRank");

            migrationBuilder.RenameColumn(
                name: "DependentUserId",
                table: "Consultations",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_DependentUserId",
                table: "Consultations",
                newName: "IX_Consultations_CustomerId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Stores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AvatarPath",
                table: "Stores",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Stores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IsVerified",
                table: "Stores",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "WardName",
                table: "StoreAddresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "WardCode",
                table: "StoreAddresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ProvinceName",
                table: "StoreAddresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "DistrictName",
                table: "StoreAddresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StoreAddresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductVariants",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "ProductVariants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "ProductItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "ProductCategories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModificationById",
                table: "ProductCategories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "ProductCategories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeleteById",
                table: "ProductCategories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ProductCategories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "ProductCategories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProductCategories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductCategories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "PaymentMethods",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "PaymentMethodHistories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PaymentMethodHistories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IconPath",
                table: "PaymentMethodHistories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "OTPData",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OTPData",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "OrderGhnCode",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "User1Id",
                table: "Conversations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "User2Id",
                table: "Conversations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultationId",
                table: "Consultations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreUserId",
                table: "Cart",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cart",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Cart",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "Other",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Unknown");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OrderReviews",
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
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderReviews_CustomerUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderReviews_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTasks",
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
                    StoreUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ScheduledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TaskPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledTasks_StoreUsers_StoreUserId",
                        column: x => x.StoreUserId,
                        principalTable: "StoreUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "StoreId" },
                values: new object[] { "6f265841-de53-40de-a66d-f4c88495cf67", new DateTime(2025, 7, 12, 2, 3, 39, 926, DateTimeKind.Utc).AddTicks(1899), "AQAAAAIAAYagAAAAEL9WuRGrhGYnFfN73sEQWXI+jomgIUhPQH2Xh4QpyyqF60+Uv/xtjXHYmPlr2G8kjA==", null });

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

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate", "ProductId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111161"), new Guid("11111111-1111-1111-1111-111111111112"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3252), null, null, null, null, new Guid("11111111-1111-1111-1111-111111111121") },
                    { new Guid("11111111-1111-1111-1111-111111111162"), new Guid("11111111-1111-1111-1111-111111111113"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3258), null, null, null, null, new Guid("11111111-1111-1111-1111-111111111122") },
                    { new Guid("11111111-1111-1111-1111-111111111163"), new Guid("11111111-1111-1111-1111-111111111114"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3264), null, null, null, null, new Guid("11111111-1111-1111-1111-111111111123") },
                    { new Guid("22222222-2222-2222-2222-222222222233"), new Guid("22222222-2222-2222-2222-222222222223"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3267), null, null, null, null, new Guid("22222222-2222-2222-2222-222222222225") },
                    { new Guid("22222222-2222-2222-2222-222222222234"), new Guid("22222222-2222-2222-2222-222222222224"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3270), null, null, null, null, new Guid("22222222-2222-2222-2222-222222222226") },
                    { new Guid("33333333-3333-3333-3333-333333333345"), new Guid("33333333-3333-3333-3333-333333333334"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3273), null, null, null, null, new Guid("33333333-3333-3333-3333-333333333336") },
                    { new Guid("33333333-3333-3333-3333-333333333346"), new Guid("33333333-3333-3333-3333-333333333335"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3275), null, null, null, null, new Guid("33333333-3333-3333-3333-333333333337") },
                    { new Guid("44444444-4444-4444-4444-444444444449"), new Guid("44444444-4444-4444-4444-444444444444"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3278), null, null, null, null, new Guid("44444444-4444-4444-4444-444444444445") },
                    { new Guid("44444444-4444-4444-4444-444444444450"), new Guid("44444444-4444-4444-4444-444444444444"), null, new DateTime(2025, 7, 12, 2, 3, 39, 881, DateTimeKind.Utc).AddTicks(3281), null, null, null, null, new Guid("44444444-4444-4444-4444-444444444446") }
                });

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
                columns: new[] { "CreationDate", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5941), 25 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"),
                columns: new[] { "CreationDate", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5951), 15 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"),
                columns: new[] { "CreationDate", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5959), 50 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"),
                columns: new[] { "CreationDate", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5966), 75 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"),
                columns: new[] { "CreationDate", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5971), 20 });

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"),
                columns: new[] { "CreationDate", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5975), 8 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(4998), 850000m, 50 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5005), 850000m, 30 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5010), 1200000m, 25 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5014), 1500000m, 20 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5017), 280000m, 100 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5026), 520000m, 80 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5030), 180000m, 150 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5033), 450000m, 40 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5037), 450000m, 35 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5041), 2800000m, 15 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5052), 500000m, 999 });

            migrationBuilder.UpdateData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"),
                columns: new[] { "CreationDate", "Price", "Stock" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(5056), 2000000m, 999 });

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
                columns: new[] { "CreationDate", "IsActive", "IsVerified" },
                values: new object[] { new DateTime(2025, 7, 12, 2, 3, 39, 880, DateTimeKind.Utc).AddTicks(9924), true, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_User1Id",
                table: "Conversations",
                column: "User1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_User2Id",
                table: "Conversations",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StoreId",
                table: "AspNetUsers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReviews_CustomerId",
                table: "OrderReviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReviews_OrderId",
                table: "OrderReviews",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTasks_StoreUserId",
                table: "ScheduledTasks",
                column: "StoreUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Stores_StoreId",
                table: "AspNetUsers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_StoreUsers_StoreUserId",
                table: "Cart",
                column: "StoreUserId",
                principalTable: "StoreUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_ConsultantUsers_ConsultantId",
                table: "Consultations",
                column: "ConsultantId",
                principalTable: "ConsultantUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_DependentUsers_CustomerId",
                table: "Consultations",
                column: "CustomerId",
                principalTable: "DependentUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_AspNetUsers_User1Id",
                table: "Conversations",
                column: "User1Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_AspNetUsers_User2Id",
                table: "Conversations",
                column: "User2Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
