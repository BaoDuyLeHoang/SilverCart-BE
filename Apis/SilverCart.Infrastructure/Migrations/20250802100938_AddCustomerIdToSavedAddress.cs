using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerIdToSavedAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_BaseUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_BaseUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "BaseUserId",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Addresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "GhnShopId",
                value: 197207);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "BaseUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                column: "GhnShopId",
                value: 5732305);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BaseUserId",
                table: "Addresses",
                column: "BaseUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_BaseUserId",
                table: "Addresses",
                column: "BaseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
