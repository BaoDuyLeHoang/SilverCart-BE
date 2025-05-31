using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ChangeParentCategoryIdAllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("0273e460-78eb-446d-bccf-7cd4a1a8637f"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("0653cef4-cdca-4856-8223-ef6030972e56"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("895eb973-3221-4800-a32d-ea86b1b4c104"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae00d450-1361-4298-89d3-dbb177677e66"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("b9df5dcb-112d-4fe1-8763-d8a412772cf5"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("22deabd7-21bc-459d-9cbe-413b560ccb44"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8ddb841-a53e-4148-88f5-a1c6e8dc819f"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("305d3202-7773-4f05-a42b-b65a5019f745"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d7357f2-e865-4c7c-ac57-0f7df96138cb"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("833fff57-4049-40d6-83fc-787079a592c7"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("9517da7c-45eb-4f3a-acc4-8374e3594309"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0273e460-78eb-446d-bccf-7cd4a1a8637f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0653cef4-cdca-4856-8223-ef6030972e56"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22deabd7-21bc-459d-9cbe-413b560ccb44"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("305d3202-7773-4f05-a42b-b65a5019f745"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4d7357f2-e865-4c7c-ac57-0f7df96138cb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("833fff57-4049-40d6-83fc-787079a592c7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("895eb973-3221-4800-a32d-ea86b1b4c104"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9517da7c-45eb-4f3a-acc4-8374e3594309"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae00d450-1361-4298-89d3-dbb177677e66"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b9df5dcb-112d-4fe1-8763-d8a412772cf5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e8ddb841-a53e-4148-88f5-a1c6e8dc819f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentCategoryId",
                table: "Categories",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("45191481-ba62-49ed-907f-ec566cf3f342"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("4ae2f79a-de76-4a8f-af2f-615b8e8c2ddb"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("4cf83be2-842c-4173-a367-6e96667a1d5d"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("59f2f1c4-cd47-4435-8c27-41f08a460af2"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("662ae480-52e0-45e6-8e3e-c3939aa54cab"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("9b85ad4e-c192-4e64-9a53-fda030db6f94"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("9f50cd16-0761-43eb-af54-883429543816"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("a228ab14-af7e-4a25-ab15-5b7d477b644a"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("a8e6f146-fd5d-4bdc-90ec-6c47bb01a020"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("c3f1a94f-e11f-4bbf-8e49-c21747fc5988"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("f58b282f-d1a5-45ec-ba08-cf4da42bb33f"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" }
                });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("45191481-ba62-49ed-907f-ec566cf3f342"),
                    new Guid("59f2f1c4-cd47-4435-8c27-41f08a460af2"),
                    new Guid("662ae480-52e0-45e6-8e3e-c3939aa54cab"),
                    new Guid("a228ab14-af7e-4a25-ab15-5b7d477b644a"),
                    new Guid("a8e6f146-fd5d-4bdc-90ec-6c47bb01a020")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("9b85ad4e-c192-4e64-9a53-fda030db6f94"),
                    new Guid("9f50cd16-0761-43eb-af54-883429543816")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("4ae2f79a-de76-4a8f-af2f-615b8e8c2ddb"),
                    new Guid("4cf83be2-842c-4173-a367-6e96667a1d5d"),
                    new Guid("c3f1a94f-e11f-4bbf-8e49-c21747fc5988"),
                    new Guid("f58b282f-d1a5-45ec-ba08-cf4da42bb33f")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("45191481-ba62-49ed-907f-ec566cf3f342"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("59f2f1c4-cd47-4435-8c27-41f08a460af2"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("662ae480-52e0-45e6-8e3e-c3939aa54cab"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("a228ab14-af7e-4a25-ab15-5b7d477b644a"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("a8e6f146-fd5d-4bdc-90ec-6c47bb01a020"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b85ad4e-c192-4e64-9a53-fda030db6f94"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f50cd16-0761-43eb-af54-883429543816"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ae2f79a-de76-4a8f-af2f-615b8e8c2ddb"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("4cf83be2-842c-4173-a367-6e96667a1d5d"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3f1a94f-e11f-4bbf-8e49-c21747fc5988"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("f58b282f-d1a5-45ec-ba08-cf4da42bb33f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("45191481-ba62-49ed-907f-ec566cf3f342"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ae2f79a-de76-4a8f-af2f-615b8e8c2ddb"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4cf83be2-842c-4173-a367-6e96667a1d5d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("59f2f1c4-cd47-4435-8c27-41f08a460af2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("662ae480-52e0-45e6-8e3e-c3939aa54cab"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b85ad4e-c192-4e64-9a53-fda030db6f94"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f50cd16-0761-43eb-af54-883429543816"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a228ab14-af7e-4a25-ab15-5b7d477b644a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a8e6f146-fd5d-4bdc-90ec-6c47bb01a020"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3f1a94f-e11f-4bbf-8e49-c21747fc5988"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f58b282f-d1a5-45ec-ba08-cf4da42bb33f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentCategoryId",
                table: "Categories",
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
                    { new Guid("0273e460-78eb-446d-bccf-7cd4a1a8637f"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("0653cef4-cdca-4856-8223-ef6030972e56"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("22deabd7-21bc-459d-9cbe-413b560ccb44"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("305d3202-7773-4f05-a42b-b65a5019f745"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("4d7357f2-e865-4c7c-ac57-0f7df96138cb"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" },
                    { new Guid("833fff57-4049-40d6-83fc-787079a592c7"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("895eb973-3221-4800-a32d-ea86b1b4c104"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("9517da7c-45eb-4f3a-acc4-8374e3594309"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("ae00d450-1361-4298-89d3-dbb177677e66"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("b9df5dcb-112d-4fe1-8763-d8a412772cf5"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("e8ddb841-a53e-4148-88f5-a1c6e8dc819f"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0273e460-78eb-446d-bccf-7cd4a1a8637f"),
                    new Guid("0653cef4-cdca-4856-8223-ef6030972e56"),
                    new Guid("895eb973-3221-4800-a32d-ea86b1b4c104"),
                    new Guid("ae00d450-1361-4298-89d3-dbb177677e66"),
                    new Guid("b9df5dcb-112d-4fe1-8763-d8a412772cf5")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("22deabd7-21bc-459d-9cbe-413b560ccb44"),
                    new Guid("e8ddb841-a53e-4148-88f5-a1c6e8dc819f")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("305d3202-7773-4f05-a42b-b65a5019f745"),
                    new Guid("4d7357f2-e865-4c7c-ac57-0f7df96138cb"),
                    new Guid("833fff57-4049-40d6-83fc-787079a592c7"),
                    new Guid("9517da7c-45eb-4f3a-acc4-8374e3594309")
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
