using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class FixConsultant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConsultantRoles",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[] { new Guid("0c09b112-baf9-4ec3-bc79-cce452219d61"), "Chuyên viên tư vấn là người tư vấn cho người cao tuổi và có quyền tư vấn cho người cao tuổi.", "Consultant" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConsultantRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c09b112-baf9-4ec3-bc79-cce452219d61"));
        }
    }
}
