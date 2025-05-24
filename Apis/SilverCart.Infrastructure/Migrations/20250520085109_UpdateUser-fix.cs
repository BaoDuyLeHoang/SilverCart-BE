using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_AspNetUsers_UserId",
                table: "StoreUsers");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("144c925d-ea53-4589-b3b8-49efb4f74166"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("4cd3a5e3-ed3a-4a72-a3fa-fc23a411ea24"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f7f719b-91d2-40c5-9f03-5879403de082"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f9635e7-eb3d-4115-86e9-9ac897b1f23f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2aef7af-4e6a-4d95-bcda-13312435d243"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("08ab4e35-0549-4baa-b9d2-e8182bd942a2"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("32980f1d-fccb-4679-9f6f-affb638f857e"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8edb8e8-181e-4f3d-9598-e7bb03533cec"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a2242e3-70ee-4258-a1aa-e6462862d0e8"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a7e28d9-cb38-4399-9c46-a43dda28919a"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d326475-dc4b-4603-b02e-7ef19e296434"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("955d6d06-8c09-4f7f-a5cf-c0932751da9e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("08ab4e35-0549-4baa-b9d2-e8182bd942a2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a2242e3-70ee-4258-a1aa-e6462862d0e8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("144c925d-ea53-4589-b3b8-49efb4f74166"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("32980f1d-fccb-4679-9f6f-affb638f857e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4a7e28d9-cb38-4399-9c46-a43dda28919a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4cd3a5e3-ed3a-4a72-a3fa-fc23a411ea24"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d326475-dc4b-4603-b02e-7ef19e296434"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f7f719b-91d2-40c5-9f03-5879403de082"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f9635e7-eb3d-4115-86e9-9ac897b1f23f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("955d6d06-8c09-4f7f-a5cf-c0932751da9e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e2aef7af-4e6a-4d95-bcda-13312435d243"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8edb8e8-181e-4f3d-9598-e7bb03533cec"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "StoreUsers",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1aae0341-c8bd-474f-afb2-d6bcf3daa331"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("2c6db6ae-6bc0-40d9-a94f-3892891ad743"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("302c5dee-c581-46d6-a6dd-198599fea694"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("3178dd96-39af-4868-8096-52d245c60955"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("33ba3181-ce48-4b9b-b112-741320cdb8ef"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("3daaf432-fb3a-4b1d-8e15-d7d7a9726f81"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("543fdcdd-995d-4289-8c5c-8667d71c12c0"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("959c60b8-7ae2-4d88-8424-be9803d2f303"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("af94e231-ddc9-4678-8dae-5f30a54725a4"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("b163c6fb-6b3b-4ce7-8f3e-99995a499a2f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("c3e3c11d-48ac-42a3-8049-b0c638fc07b7"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("d01674e2-8fa5-4617-9a97-c79f82d8a501"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "4947d753-995c-440e-8f7d-5675bcdb2260", new DateTime(2025, 5, 20, 8, 51, 8, 500, DateTimeKind.Utc).AddTicks(9075), "AQAAAAIAAYagAAAAEA433vEsdyjnQ+15DZRXMN0fDrkkt+CAO7SAcnVg47ahA+GP/qeBpD05Z+D0c0yYNQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("2c6db6ae-6bc0-40d9-a94f-3892891ad743"),
                    new Guid("3178dd96-39af-4868-8096-52d245c60955"),
                    new Guid("3daaf432-fb3a-4b1d-8e15-d7d7a9726f81"),
                    new Guid("543fdcdd-995d-4289-8c5c-8667d71c12c0"),
                    new Guid("b163c6fb-6b3b-4ce7-8f3e-99995a499a2f")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("959c60b8-7ae2-4d88-8424-be9803d2f303"),
                    new Guid("c3e3c11d-48ac-42a3-8049-b0c638fc07b7"),
                    new Guid("d01674e2-8fa5-4617-9a97-c79f82d8a501")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1aae0341-c8bd-474f-afb2-d6bcf3daa331"),
                    new Guid("302c5dee-c581-46d6-a6dd-198599fea694"),
                    new Guid("33ba3181-ce48-4b9b-b112-741320cdb8ef"),
                    new Guid("af94e231-ddc9-4678-8dae-5f30a54725a4")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_AspNetUsers_UserId",
                table: "StoreUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_AspNetUsers_UserId",
                table: "StoreUsers");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c6db6ae-6bc0-40d9-a94f-3892891ad743"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3178dd96-39af-4868-8096-52d245c60955"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3daaf432-fb3a-4b1d-8e15-d7d7a9726f81"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("543fdcdd-995d-4289-8c5c-8667d71c12c0"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b163c6fb-6b3b-4ce7-8f3e-99995a499a2f"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("959c60b8-7ae2-4d88-8424-be9803d2f303"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3e3c11d-48ac-42a3-8049-b0c638fc07b7"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("d01674e2-8fa5-4617-9a97-c79f82d8a501"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("1aae0341-c8bd-474f-afb2-d6bcf3daa331"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("302c5dee-c581-46d6-a6dd-198599fea694"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("33ba3181-ce48-4b9b-b112-741320cdb8ef"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("af94e231-ddc9-4678-8dae-5f30a54725a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1aae0341-c8bd-474f-afb2-d6bcf3daa331"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2c6db6ae-6bc0-40d9-a94f-3892891ad743"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("302c5dee-c581-46d6-a6dd-198599fea694"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3178dd96-39af-4868-8096-52d245c60955"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("33ba3181-ce48-4b9b-b112-741320cdb8ef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3daaf432-fb3a-4b1d-8e15-d7d7a9726f81"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("543fdcdd-995d-4289-8c5c-8667d71c12c0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("959c60b8-7ae2-4d88-8424-be9803d2f303"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("af94e231-ddc9-4678-8dae-5f30a54725a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b163c6fb-6b3b-4ce7-8f3e-99995a499a2f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3e3c11d-48ac-42a3-8049-b0c638fc07b7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d01674e2-8fa5-4617-9a97-c79f82d8a501"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "StoreUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("08ab4e35-0549-4baa-b9d2-e8182bd942a2"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("0a2242e3-70ee-4258-a1aa-e6462862d0e8"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("144c925d-ea53-4589-b3b8-49efb4f74166"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("32980f1d-fccb-4679-9f6f-affb638f857e"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("4a7e28d9-cb38-4399-9c46-a43dda28919a"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("4cd3a5e3-ed3a-4a72-a3fa-fc23a411ea24"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("5d326475-dc4b-4603-b02e-7ef19e296434"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("5f7f719b-91d2-40c5-9f03-5879403de082"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("8f9635e7-eb3d-4115-86e9-9ac897b1f23f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("955d6d06-8c09-4f7f-a5cf-c0932751da9e"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("e2aef7af-4e6a-4d95-bcda-13312435d243"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("f8edb8e8-181e-4f3d-9598-e7bb03533cec"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "8ff6043f-eb8c-4fa1-9c3d-54ab321b5603", new DateTime(2025, 5, 20, 8, 49, 43, 372, DateTimeKind.Utc).AddTicks(5433), "AQAAAAIAAYagAAAAEJfAFobhRpTq+5MrGNgz0YwNRnf1He8m1GQtpXB3nrAxAcpBkIh/PyT8m5/SjI/iGg==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("144c925d-ea53-4589-b3b8-49efb4f74166"),
                    new Guid("4cd3a5e3-ed3a-4a72-a3fa-fc23a411ea24"),
                    new Guid("5f7f719b-91d2-40c5-9f03-5879403de082"),
                    new Guid("8f9635e7-eb3d-4115-86e9-9ac897b1f23f"),
                    new Guid("e2aef7af-4e6a-4d95-bcda-13312435d243")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("08ab4e35-0549-4baa-b9d2-e8182bd942a2"),
                    new Guid("32980f1d-fccb-4679-9f6f-affb638f857e"),
                    new Guid("f8edb8e8-181e-4f3d-9598-e7bb03533cec")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0a2242e3-70ee-4258-a1aa-e6462862d0e8"),
                    new Guid("4a7e28d9-cb38-4399-9c46-a43dda28919a"),
                    new Guid("5d326475-dc4b-4603-b02e-7ef19e296434"),
                    new Guid("955d6d06-8c09-4f7f-a5cf-c0932751da9e")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_AspNetUsers_UserId",
                table: "StoreUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
