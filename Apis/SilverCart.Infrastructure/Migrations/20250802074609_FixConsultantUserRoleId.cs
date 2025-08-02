using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixConsultantUserRoleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "IsHardDelete", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[] { new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a19"), null, null, null, null, null, "Người tư vấn là người tư vấn cho người khách và có quyền tư vấn cho người khách.", false, false, null, null, "Consultant", "CONSULTANT" });

            migrationBuilder.InsertData(
                table: "ConsultantRoles",
                column: "Id",
                value: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a19"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConsultantRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a19"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c66a403b-e1f9-47f3-9f6b-d8c3913b7a19"));
        }
    }
}
