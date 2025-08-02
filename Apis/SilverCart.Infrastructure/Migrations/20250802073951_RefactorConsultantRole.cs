using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class RefactorConsultantRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantUsers_ConsultantRoles_RoleId",
                table: "ConsultantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentUsers_CustomerRoles_CustomerRoleId",
                table: "DependentUsers");

            migrationBuilder.DropIndex(
                name: "IX_DependentUsers_CustomerRoleId",
                table: "DependentUsers");

            migrationBuilder.DropIndex(
                name: "IX_ConsultantUsers_RoleId",
                table: "ConsultantUsers");

            migrationBuilder.DeleteData(
                table: "ConsultantRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d61"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1c"));

            migrationBuilder.DropColumn(
                name: "CustomerRoleId",
                table: "DependentUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ConsultantUsers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ConsultantRoles");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "ConsultantRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerRoleId",
                table: "CustomerUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultantRoleId",
                table: "ConsultantUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_CustomerRoleId",
                table: "CustomerUsers",
                column: "CustomerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantUsers_ConsultantRoleId",
                table: "ConsultantUsers",
                column: "ConsultantRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantRoles_AspNetRoles_Id",
                table: "ConsultantRoles",
                column: "Id",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantUsers_ConsultantRoles_ConsultantRoleId",
                table: "ConsultantUsers",
                column: "ConsultantRoleId",
                principalTable: "ConsultantRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUsers_CustomerRoles_CustomerRoleId",
                table: "CustomerUsers",
                column: "CustomerRoleId",
                principalTable: "CustomerRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantRoles_AspNetRoles_Id",
                table: "ConsultantRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsultantUsers_ConsultantRoles_ConsultantRoleId",
                table: "ConsultantUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_CustomerRoles_CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.DropIndex(
                name: "IX_ConsultantUsers_ConsultantRoleId",
                table: "ConsultantUsers");

            migrationBuilder.DropColumn(
                name: "CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.DropColumn(
                name: "ConsultantRoleId",
                table: "ConsultantUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerRoleId",
                table: "DependentUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "ConsultantUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ConsultantRoles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "ConsultantRoles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "IsHardDelete", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[] { new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1c"), null, null, null, null, null, "Người khách là người khách và có quyền khách.", false, false, null, null, "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "ConsultantRoles",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[] { new Guid("0c09b112-baf9-4ec3-bc79-cce452219d61"), "Chuyên viên tư vấn là người tư vấn cho người cao tuổi và có quyền tư vấn cho người cao tuổi.", "Consultant" });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                value: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1c"));

            migrationBuilder.CreateIndex(
                name: "IX_DependentUsers_CustomerRoleId",
                table: "DependentUsers",
                column: "CustomerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantUsers_RoleId",
                table: "ConsultantUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsultantUsers_ConsultantRoles_RoleId",
                table: "ConsultantUsers",
                column: "RoleId",
                principalTable: "ConsultantRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DependentUsers_CustomerRoles_CustomerRoleId",
                table: "DependentUsers",
                column: "CustomerRoleId",
                principalTable: "CustomerRoles",
                principalColumn: "Id");
        }
    }
}
