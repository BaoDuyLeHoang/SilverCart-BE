using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Người giám hộ", "GUARDIAN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Quản trị viên", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Siêu quản trị viên", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Chủ cửa hàng", "STOREOWNER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Hỗ trợ cửa hàng", "STORESUPPORT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Người phụ thuộc", "DEPENDENTUSER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d60"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Guardian", "Người giám hộ" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e61cc83-d3c4-43b1-9334-8dd0c9d22833"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "Quản trị viên" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5c2cb3f3-d9b1-4d5f-8a9c-1e6f689ee0f4"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "SuperAdmin", "Siêu quản trị viên" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "StoreOwner", "Chủ cửa hàng" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "StoreSupport", "Hỗ trợ cửa hàng" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "DependentUser", "Người phụ thuộc" });
        }
    }
}
