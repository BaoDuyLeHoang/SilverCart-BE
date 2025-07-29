using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "ShopOwner", "SHOPOWNER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Staff", "STAFF" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                column: "Name",
                value: "Guardian");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "IsHardDelete", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[] { new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1c"), null, null, null, null, null, "Người khách là người khách và có quyền khách.", false, false, null, null, "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                value: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1c"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("60cb3e42-0903-4c3f-8e9c-bfdc6f6a1a01"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "StoreOwner", "STOREOWNER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2a02247-2a41-4a38-8804-4be8038fa78b"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "StoreSupport", "STORESUPPORT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a1b"),
                column: "Name",
                value: "DependentUser");
        }
    }
}
