using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class Refactor_Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerUsers_PaymentStatus_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentStatus_CustomerUserId",
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
                name: "PaymentStatus_PaymentStatus",
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

            migrationBuilder.CreateTable(
                name: "OrderPaymentStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: false),
                    PayedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CustomerUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPaymentStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderPaymentStatus_CustomerUsers_CustomerUserId",
                        column: x => x.CustomerUserId,
                        principalTable: "CustomerUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderPaymentStatus_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderShippingStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    TrackingCode = table.Column<string>(type: "text", nullable: true),
                    TrackingUrl = table.Column<string>(type: "text", nullable: true),
                    TrackingMessage = table.Column<string>(type: "text", nullable: true),
                    ShipSource = table.Column<string>(type: "text", nullable: true),
                    TrackingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderShippingStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderShippingStatus_Orders_Id",
                        column: x => x.Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPaymentStatus_CustomerUserId",
                table: "OrderPaymentStatus",
                column: "CustomerUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPaymentStatus");

            migrationBuilder.DropTable(
                name: "OrderShippingStatus");

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
                name: "PaymentStatus_PaymentStatus",
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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentStatus_CustomerUserId",
                table: "Orders",
                column: "PaymentStatus_CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerUsers_PaymentStatus_CustomerUserId",
                table: "Orders",
                column: "PaymentStatus_CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");
        }
    }
}
