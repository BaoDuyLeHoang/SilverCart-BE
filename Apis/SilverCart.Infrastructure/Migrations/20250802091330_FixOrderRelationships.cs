using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreUserRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerUserId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerUserId",
                table: "Orders",
                column: "CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerUsers_CustomerUserId",
                table: "Orders",
                column: "CustomerUserId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerUsers_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "StoreUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeleteById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsHardDelete = table.Column<bool>(type: "boolean", nullable: false),
                    ModificationById = table.Column<Guid>(type: "uuid", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_StoreUserRoles_StoreRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "StoreRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreUserRoles_StoreUsers_StoreUserId",
                        column: x => x.StoreUserId,
                        principalTable: "StoreUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreUserRoles_RoleId",
                table: "StoreUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreUserRoles_StoreUserId",
                table: "StoreUserRoles",
                column: "StoreUserId");
        }
    }
}
