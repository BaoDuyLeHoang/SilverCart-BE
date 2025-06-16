using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StoreUsers_StoreUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_AspNetUsers_Id",
                table: "StoreUsers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StoreUserId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("987f3df8-72ec-49c0-a4d6-1a65bb2de6a4"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae367502-3f47-49f1-b3bf-2feed7f66efe"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b6d665bb-d839-4688-bcfd-939c9236182e"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1e4e9fb-5066-4f16-9de9-59bdf6232e5f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("f19888bc-81c5-470c-a43c-e2bcdefe7f1d"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("184c5703-bafc-4d46-ac45-8c43abd8397e"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("30dd3eb6-6ea4-4262-ba92-7992082a07e5"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1a0a149-b5db-4b91-9c33-cdbad828da9e"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("34ffb774-e96e-4c25-b0cf-cf40a8b9f1f0"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("63b756a3-279f-496c-91e0-1c1d19926160"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("81cfd08b-3af9-4288-99ff-abd1d74ab28f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2e130e3-af54-4490-88f2-82e930e32673"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("184c5703-bafc-4d46-ac45-8c43abd8397e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("30dd3eb6-6ea4-4262-ba92-7992082a07e5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("34ffb774-e96e-4c25-b0cf-cf40a8b9f1f0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("63b756a3-279f-496c-91e0-1c1d19926160"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("81cfd08b-3af9-4288-99ff-abd1d74ab28f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("987f3df8-72ec-49c0-a4d6-1a65bb2de6a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae367502-3f47-49f1-b3bf-2feed7f66efe"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b6d665bb-d839-4688-bcfd-939c9236182e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1a0a149-b5db-4b91-9c33-cdbad828da9e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c1e4e9fb-5066-4f16-9de9-59bdf6232e5f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d2e130e3-af54-4490-88f2-82e930e32673"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f19888bc-81c5-470c-a43c-e2bcdefe7f1d"));

            migrationBuilder.DropColumn(
                name: "OTP_Code",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "OTP_IsUsed",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "StoreUserId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "OTP_ExpirationTime",
                table: "StoreUsers",
                newName: "ModificationDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StoreUsers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "StoreUsers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "StoreUsers",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleteById",
                table: "StoreUsers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreUsers",
                type: "timestamp with time zone",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoreUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ModificationById",
                table: "StoreUsers",
                type: "uuid",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AddColumn<int>(
                name: "RoleInStore",
                table: "StoreUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "StoreUsers",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_StoreUsers_UserId",
                table: "StoreUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_AspNetUsers_UserId",
                table: "StoreUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreUsers_AspNetUsers_UserId",
                table: "StoreUsers");

            migrationBuilder.DropIndex(
                name: "IX_StoreUsers_UserId",
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

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "DeleteById",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "DeletionDate",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "ModificationById",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "RoleInStore",
                table: "StoreUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StoreUsers");

            migrationBuilder.RenameColumn(
                name: "ModificationDate",
                table: "StoreUsers",
                newName: "OTP_ExpirationTime");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StoreUsers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OTP_ExpirationTime",
                table: "StoreUsers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 97);

            migrationBuilder.AddColumn<string>(
                name: "OTP_Code",
                table: "StoreUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OTP_IsUsed",
                table: "StoreUsers",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("184c5703-bafc-4d46-ac45-8c43abd8397e"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("30dd3eb6-6ea4-4262-ba92-7992082a07e5"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("34ffb774-e96e-4c25-b0cf-cf40a8b9f1f0"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("63b756a3-279f-496c-91e0-1c1d19926160"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("81cfd08b-3af9-4288-99ff-abd1d74ab28f"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("987f3df8-72ec-49c0-a4d6-1a65bb2de6a4"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("ae367502-3f47-49f1-b3bf-2feed7f66efe"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("b6d665bb-d839-4688-bcfd-939c9236182e"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("c1a0a149-b5db-4b91-9c33-cdbad828da9e"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("c1e4e9fb-5066-4f16-9de9-59bdf6232e5f"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("d2e130e3-af54-4490-88f2-82e930e32673"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("f19888bc-81c5-470c-a43c-e2bcdefe7f1d"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "d348f007-1072-46f9-90bc-f18caa1935f3", new DateTime(2025, 5, 20, 7, 25, 39, 442, DateTimeKind.Utc).AddTicks(736), "AQAAAAIAAYagAAAAEDY1V92Y14qw/39neyohO/5boC84xF5mylQA1JTJIa/coJclLCVL1DLoibU+AcsWLA==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("987f3df8-72ec-49c0-a4d6-1a65bb2de6a4"),
                    new Guid("ae367502-3f47-49f1-b3bf-2feed7f66efe"),
                    new Guid("b6d665bb-d839-4688-bcfd-939c9236182e"),
                    new Guid("c1e4e9fb-5066-4f16-9de9-59bdf6232e5f"),
                    new Guid("f19888bc-81c5-470c-a43c-e2bcdefe7f1d")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("184c5703-bafc-4d46-ac45-8c43abd8397e"),
                    new Guid("30dd3eb6-6ea4-4262-ba92-7992082a07e5"),
                    new Guid("c1a0a149-b5db-4b91-9c33-cdbad828da9e")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("34ffb774-e96e-4c25-b0cf-cf40a8b9f1f0"),
                    new Guid("63b756a3-279f-496c-91e0-1c1d19926160"),
                    new Guid("81cfd08b-3af9-4288-99ff-abd1d74ab28f"),
                    new Guid("d2e130e3-af54-4490-88f2-82e930e32673")
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StoreUserId",
                table: "Addresses",
                column: "StoreUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StoreUsers_StoreUserId",
                table: "Addresses",
                column: "StoreUserId",
                principalTable: "StoreUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreUsers_AspNetUsers_Id",
                table: "StoreUsers",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
