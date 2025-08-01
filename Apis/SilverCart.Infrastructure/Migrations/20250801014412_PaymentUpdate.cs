using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class PaymentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_Wallets_WalletId",
                table: "CustomerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentHistories_Orders_OrderId",
                table: "PaymentHistories");

            migrationBuilder.DropIndex(
                name: "IX_PaymentHistories_OrderId",
                table: "PaymentHistories");

            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_WalletId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "WalletId",
                table: "CustomerUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "GuardianUserId",
                table: "Wallets",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Wallets",
                type: "uuid",
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

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_GuardianUserId",
                table: "Wallets",
                column: "GuardianUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_CustomerUsers_UserId",
                table: "Wallets",
                column: "UserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_GuardianUsers_GuardianUserId",
                table: "Wallets",
                column: "GuardianUserId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_CustomerUsers_UserId",
                table: "Wallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_GuardianUsers_GuardianUserId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_GuardianUserId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "GuardianUserId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "NewBalance",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "PreviousBalance",
                table: "PaymentHistories");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PaymentHistories");

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
                name: "OrderId",
                table: "PaymentHistories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WalletId",
                table: "CustomerUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentHistories_OrderId",
                table: "PaymentHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_WalletId",
                table: "CustomerUsers",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_Wallets_WalletId",
                table: "CustomerUsers",
                column: "WalletId",
                principalTable: "Wallets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentHistories_Orders_OrderId",
                table: "PaymentHistories",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
