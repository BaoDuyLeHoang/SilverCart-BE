using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEntityHierarchyAndCustomerUserImplementationFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_GuardianUsers_GuardianUserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethods_CustomerUsers_CustomerId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_CustomerRoles_CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_GuardianUsers_GuardianUserId",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentUsers_AspNetUsers_Id",
                table: "DependentUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentUsers_GuardianUsers_GuardianId",
                table: "DependentUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_GuardianUsers_AspNetUsers_Id",
                table: "GuardianUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPaymentStatus_CustomerUsers_CustomerUserId",
                table: "OrderPaymentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_RecieveUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerUsers_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DependentUsers_DependentUserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_GuardianUsers_GuardianId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_UserPromotions_UserPromotionId",
                table: "Orders");

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
                name: "FK_ProductReviews_CustomerUsers_CustomerId",
                table: "ProductReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPromotions_CustomerUsers_UserId",
                table: "UserPromotions");

            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "CustomerRanks");

            migrationBuilder.DropIndex(
                name: "IX_PaymentHistories_CustomerPaymentMethodId",
                table: "PaymentHistories");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DependentUserID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_GuardianId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserPromotionId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderPaymentStatus_CustomerUserId",
                table: "OrderPaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_GuardianUserId",
                table: "CustomerUsers");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CustomerPaymentMethodId",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DependentUserID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GuardianId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserPromotionId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "ConsultantRecommendation",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "PaymentHistories",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_OrderId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_UserId");

            migrationBuilder.RenameColumn(
                name: "PayedById",
                table: "OrderPaymentStatus",
                newName: "PaidUserId");

            migrationBuilder.RenameColumn(
                name: "CustomerUserId",
                table: "OrderPaymentStatus",
                newName: "PaidById");

            migrationBuilder.RenameColumn(
                name: "GuardianUserId",
                table: "Carts",
                newName: "ConsultantUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_GuardianUserId",
                table: "Carts",
                newName: "IX_Carts_ConsultantUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Wallets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerUserId",
                table: "UserPromotions",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "UserPromotions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedAt",
                table: "UserPromotions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Points",
                table: "PaymentHistories",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentMethodId",
                table: "PaymentHistories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerUserId",
                table: "PaymentHistories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "PaymentHistories",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "NewBalance",
                table: "PaymentHistories",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PreviousBalance",
                table: "PaymentHistories",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PaymentHistories",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Relationship",
                table: "DependentUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "GuardianId",
                table: "DependentUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerRoleId",
                table: "DependentUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "CustomerPaymentMethods",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardLastFourDigits",
                table: "CustomerPaymentMethods",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardType",
                table: "CustomerPaymentMethods",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardholderName",
                table: "CustomerPaymentMethods",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDate",
                table: "CustomerPaymentMethods",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuardianUserId",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "CustomerPaymentMethods",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Carts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "BaseEntity",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), null, null, null, null, null, null },
                    { new Guid("00000000-0000-0000-0000-000000000002"), null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Description", "IconPath", "IsActive", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Thanh toán qua VNPay", "/images/payment/vnpay-icon.png", true, "VNPay", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Thanh toán qua tiền mặt", "/images/payment/cash-icon.png", true, "Tiền Mặt", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPromotions_CustomerUserId",
                table: "UserPromotions",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentStatus_PaidUserId",
                table: "OrderPaymentStatus",
                column: "PaidUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DependentUsers_CustomerRoleId",
                table: "DependentUsers",
                column: "CustomerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPaymentMethods_GuardianUserId",
                table: "CustomerPaymentMethods",
                column: "GuardianUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_ConsultantUsers_ConsultantUserId",
                table: "Carts",
                column: "ConsultantUserId",
                principalTable: "ConsultantUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaymentMethods_DependentUsers_CustomerId",
                table: "CustomerPaymentMethods",
                column: "CustomerId",
                principalTable: "DependentUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaymentMethods_GuardianUsers_GuardianUserId",
                table: "CustomerPaymentMethods",
                column: "GuardianUserId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DependentUsers_CustomerRoles_CustomerRoleId",
                table: "DependentUsers",
                column: "CustomerRoleId",
                principalTable: "CustomerRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DependentUsers_CustomerUsers_Id",
                table: "DependentUsers",
                column: "Id",
                principalTable: "CustomerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DependentUsers_GuardianUsers_GuardianId",
                table: "DependentUsers",
                column: "GuardianId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GuardianUsers_CustomerUsers_Id",
                table: "GuardianUsers",
                column: "Id",
                principalTable: "CustomerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPaymentStatus_AspNetUsers_PaidUserId",
                table: "OrderPaymentStatus",
                column: "PaidUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerUsers_RecieveUserId",
                table: "Orders",
                column: "RecieveUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_AspNetUsers_UserId",
                table: "PaymentHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_CustomerUsers_CustomerUserId",
                table: "PaymentHistories",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviews_DependentUsers_CustomerId",
                table: "ProductReviews",
                column: "CustomerId",
                principalTable: "DependentUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPromotions_AspNetUsers_UserId",
                table: "UserPromotions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPromotions_CustomerUsers_CustomerUserId",
                table: "UserPromotions",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_AspNetUsers_UserId",
                table: "Wallets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_ConsultantUsers_ConsultantUserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethods_DependentUsers_CustomerId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPaymentMethods_GuardianUsers_GuardianUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentUsers_CustomerRoles_CustomerRoleId",
                table: "DependentUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentUsers_CustomerUsers_Id",
                table: "DependentUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentUsers_GuardianUsers_GuardianId",
                table: "DependentUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_GuardianUsers_CustomerUsers_Id",
                table: "GuardianUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPaymentStatus_AspNetUsers_PaidUserId",
                table: "OrderPaymentStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerUsers_RecieveUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_AspNetUsers_UserId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_CustomerUsers_CustomerUserId",
                table: "PaymentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviews_DependentUsers_CustomerId",
                table: "ProductReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPromotions_AspNetUsers_UserId",
                table: "UserPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPromotions_CustomerUsers_CustomerUserId",
                table: "UserPromotions");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_AspNetUsers_UserId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_UserPromotions_CustomerUserId",
                table: "UserPromotions");

            migrationBuilder.DropIndex(
                name: "IX_OrderPaymentStatus_PaidUserId",
                table: "OrderPaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_DependentUsers_CustomerRoleId",
                table: "DependentUsers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPaymentMethods_GuardianUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "BaseEntity",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "BaseEntity",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "UsedAt",
                table: "UserPromotions");

            migrationBuilder.DropColumn(
                name: "NewBalance",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "PreviousBalance",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "CustomerRoleId",
                table: "DependentUsers");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "CardLastFourDigits",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "CardholderName",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "GuardianUserId",
                table: "CustomerPaymentMethods");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "CustomerPaymentMethods");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PaymentHistories",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentHistories_UserId",
                table: "PaymentHistories",
                newName: "IX_PaymentHistories_OrderId");

            migrationBuilder.RenameColumn(
                name: "PaidUserId",
                table: "OrderPaymentStatus",
                newName: "PayedById");

            migrationBuilder.RenameColumn(
                name: "PaidById",
                table: "OrderPaymentStatus",
                newName: "CustomerUserId");

            migrationBuilder.RenameColumn(
                name: "ConsultantUserId",
                table: "Carts",
                newName: "GuardianUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_ConsultantUserId",
                table: "Carts",
                newName: "IX_Carts_GuardianUserId");

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "PaymentHistories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentMethodId",
                table: "PaymentHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerUserId",
                table: "PaymentHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PaymentHistories",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerPaymentMethodId",
                table: "PaymentHistories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerUserId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DependentUserID",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuardianId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserPromotionId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Relationship",
                table: "DependentUsers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GuardianId",
                table: "DependentUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerRoleId",
                table: "CustomerUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Carts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ConsultantRecommendation",
                table: "Carts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_CustomerUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rank = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRanks_BaseEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerRanks_CustomerUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_CustomerPaymentMethodId",
                table: "PaymentHistories",
                column: "CustomerPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerUserId",
                table: "Orders",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DependentUserID",
                table: "Orders",
                column: "DependentUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GuardianId",
                table: "Orders",
                column: "GuardianId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserPromotionId",
                table: "Orders",
                column: "UserPromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentStatus_CustomerUserId",
                table: "OrderPaymentStatus",
                column: "CustomerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_CustomerRoleId",
                table: "CustomerUsers",
                column: "CustomerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_GuardianUserId",
                table: "CustomerUsers",
                column: "GuardianUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_AddressId",
                table: "CustomerAddresses",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_CustomerId",
                table: "CustomerAddresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerRanks_CustomerId",
                table: "CustomerRanks",
                column: "CustomerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_GuardianUsers_GuardianUserId",
                table: "Carts",
                column: "GuardianUserId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPaymentMethods_CustomerUsers_CustomerId",
                table: "CustomerPaymentMethods",
                column: "CustomerId",
                principalTable: "CustomerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_CustomerRoles_CustomerRoleId",
                table: "CustomerUsers",
                column: "CustomerRoleId",
                principalTable: "CustomerRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_GuardianUsers_GuardianUserId",
                table: "CustomerUsers",
                column: "GuardianUserId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DependentUsers_AspNetUsers_Id",
                table: "DependentUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DependentUsers_GuardianUsers_GuardianId",
                table: "DependentUsers",
                column: "GuardianId",
                principalTable: "GuardianUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuardianUsers_AspNetUsers_Id",
                table: "GuardianUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPaymentStatus_CustomerUsers_CustomerUserId",
                table: "OrderPaymentStatus",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_RecieveUserId",
                table: "Orders",
                column: "RecieveUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerUsers_CustomerUserId",
                table: "Orders",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DependentUsers_DependentUserID",
                table: "Orders",
                column: "DependentUserID",
                principalTable: "DependentUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_GuardianUsers_GuardianId",
                table: "Orders",
                column: "GuardianId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_UserPromotions_UserPromotionId",
                table: "Orders",
                column: "UserPromotionId",
                principalTable: "UserPromotions",
                principalColumn: "Id");

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
                name: "FK_ProductReviews_CustomerUsers_CustomerId",
                table: "ProductReviews",
                column: "CustomerId",
                principalTable: "CustomerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPromotions_CustomerUsers_UserId",
                table: "UserPromotions",
                column: "UserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
