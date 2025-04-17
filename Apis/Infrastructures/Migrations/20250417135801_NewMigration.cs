using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "BaseFullEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    ModificationById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeleteById = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFullEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseFullEntity_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Province = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatus_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IconPath = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    VideoPath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ProductType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountType = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    MinimumQuantity = table.Column<int>(type: "integer", nullable: false),
                    MaximumQuantity = table.Column<int>(type: "integer", nullable: false),
                    MinimumPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    MaximumPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotion_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Infomation = table.Column<string>(type: "text", nullable: true),
                    AvatarPath = table.Column<string>(type: "text", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    IsBanned = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerified = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    SignInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
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

            migrationBuilder.CreateTable(
                name: "PaymentMethodHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IconPath = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "text", nullable: true),
                    PaymentMethodId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethodHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethodHistory_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentMethodHistory_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariant_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariant_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockHistory_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockHistory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPromotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    PromotionId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPromotion_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPromotion_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPromotion_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductPromotion_Promotion_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPromotion_Promotion_PromotionId1",
                        column: x => x.PromotionId1,
                        principalTable: "Promotion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdministratorUserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministratorUserRole_Roles_Id",
                        column: x => x.Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreRole_Roles_Id",
                        column: x => x.Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RankId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerUsers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreUser_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreUser_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SKU = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    DiscountedPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    VariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductImageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItem_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductItem_ProductVariant_VariantId",
                        column: x => x.VariantId,
                        principalTable: "ProductVariant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministratorUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministratorUser_AdministratorUserRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AdministratorUserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdministratorUser_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_CustomerUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPaymentMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    PaymentMethodId = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    PaymentMethodId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPaymentMethod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentMethod_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentMethod_CustomerUsers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPaymentMethod_PaymentMethod_PaymentMethodId1",
                        column: x => x.PaymentMethodId1,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRank",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRank_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRank_CustomerUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPromotion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPromotion_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPromotion_CustomerUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPromotion_Promotion_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StoreUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_StoreUser_StoreUserId",
                        column: x => x.StoreUserId,
                        principalTable: "StoreUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledTask",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    TaskPath = table.Column<string>(type: "text", nullable: true),
                    ScheduledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StoreUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledTask_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduledTask_StoreUser_StoreUserId",
                        column: x => x.StoreUserId,
                        principalTable: "StoreUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreUserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreUserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreUserRole_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreUserRole_StoreRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "StoreRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreUserRole_StoreUser_StoreUserId",
                        column: x => x.StoreUserId,
                        principalTable: "StoreUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductItemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImage_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImage_ProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ApprovedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ApprovedUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_AdministratorUser_ApprovedUserId",
                        column: x => x.ApprovedUserId,
                        principalTable: "AdministratorUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    FilePath = table.Column<string>(type: "text", nullable: false),
                    AdministratorUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_AdministratorUser_AdministratorUserId",
                        column: x => x.AdministratorUserId,
                        principalTable: "AdministratorUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Report_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    UserRank = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<double>(type: "double precision", nullable: false),
                    OrderStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    DeadlineDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstimatedArrivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArrivedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserPromotionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_UserPromotion_UserPromotionId",
                        column: x => x.UserPromotionId,
                        principalTable: "UserPromotion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    IsSelected = table.Column<bool>(type: "boolean", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_ProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_CategoryProduct_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Product_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReport_Report_Id",
                        column: x => x.Id,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserReport_Report_Id",
                        column: x => x.Id,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ProductItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_ProductItem_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderReview_BaseFullEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseFullEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderReview_CustomerUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderReview_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorUser_RoleId",
                table: "AdministratorUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_StoreUserId",
                table: "Cart",
                column: "StoreUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductItemId",
                table: "CartItem",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_StoreId",
                table: "CartItem",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ApprovedUserId",
                table: "Category",
                column: "ApprovedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_AddressId",
                table: "CustomerAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_CustomerId",
                table: "CustomerAddress",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentMethod_CustomerId1",
                table: "CustomerPaymentMethod",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentMethod_PaymentMethodId1",
                table: "CustomerPaymentMethod",
                column: "PaymentMethodId1");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRank_CustomerId",
                table: "CustomerRank",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserPromotionId",
                table: "Order",
                column: "UserPromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductItemId",
                table: "OrderItem",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_CustomerId",
                table: "OrderReview",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderReview_OrderId",
                table: "OrderReview",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethodHistory_PaymentMethodId",
                table: "PaymentMethodHistory",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductId",
                table: "ProductImage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_ProductItemId",
                table: "ProductImage",
                column: "ProductItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductItem_VariantId",
                table: "ProductItem",
                column: "VariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotion_ProductId",
                table: "ProductPromotion",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotion_ProductId1",
                table: "ProductPromotion",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotion_PromotionId",
                table: "ProductPromotion",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotion_PromotionId1",
                table: "ProductPromotion",
                column: "PromotionId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariant_ProductId",
                table: "ProductVariant",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_AdministratorUserId",
                table: "Report",
                column: "AdministratorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledTask_StoreUserId",
                table: "ScheduledTask",
                column: "StoreUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StockHistory_ProductId",
                table: "StockHistory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreUser_StoreId",
                table: "StoreUser",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreUserRole_RoleId",
                table: "StoreUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreUserRole_StoreUserId",
                table: "StoreUserRole",
                column: "StoreUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPromotion_PromotionId",
                table: "UserPromotion",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPromotion_UserId",
                table: "UserPromotion",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.DropTable(
                name: "CustomerPaymentMethod");

            migrationBuilder.DropTable(
                name: "CustomerRank");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderReview");

            migrationBuilder.DropTable(
                name: "PaymentMethodHistory");

            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "ProductPromotion");

            migrationBuilder.DropTable(
                name: "ProductReport");

            migrationBuilder.DropTable(
                name: "ScheduledTask");

            migrationBuilder.DropTable(
                name: "StockHistory");

            migrationBuilder.DropTable(
                name: "StoreUserRole");

            migrationBuilder.DropTable(
                name: "UserReport");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "ProductItem");

            migrationBuilder.DropTable(
                name: "StoreRole");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "StoreUser");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "UserPromotion");

            migrationBuilder.DropTable(
                name: "ProductVariant");

            migrationBuilder.DropTable(
                name: "AdministratorUser");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "CustomerUsers");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AdministratorUserRole");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BaseFullEntity");

            migrationBuilder.DropTable(
                name: "BaseEntity");
        }
    }
}
