using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class ChangeParentCategoryIdAndApprovedIdAllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("23718b51-d3ab-4561-a505-822f31991a6d"), null, null, null, null, null, "", false, null, null, "Service", "SERVICE" },
                    { new Guid("458d3575-ba86-4a1f-a959-0410c5ebec19"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("6674cd67-fb1b-4dc5-883d-4c6e279343c9"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("758a67a8-c377-4a35-be02-9df80002e5ba"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("817b06dc-8244-4de9-be16-1ebb143299e1"), null, null, null, null, null, "", false, null, null, "Manager", "MANAGER" },
                    { new Guid("86aa1485-6cb5-46eb-bc49-b268b5399920"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("9b23e19f-ead0-436b-9bc1-3e3a7018dff4"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("d3f7f997-b685-4d1e-9caa-f7569c73f780"), null, null, null, null, null, "", false, null, null, "StoreStaff", "STORESTAFF" },
                    { new Guid("e3c861b4-ea2a-4c8e-80d8-29d52e31ef56"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("e5a4209b-774c-4e7f-82f5-bd16c9e09a72"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("ef917eb2-08df-4c7d-bded-b4605bdcabae"), null, null, null, null, null, "", false, null, null, "Shipper", "SHIPPER" }
                });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("6674cd67-fb1b-4dc5-883d-4c6e279343c9"),
                    new Guid("86aa1485-6cb5-46eb-bc49-b268b5399920"),
                    new Guid("9b23e19f-ead0-436b-9bc1-3e3a7018dff4"),
                    new Guid("e3c861b4-ea2a-4c8e-80d8-29d52e31ef56"),
                    new Guid("e5a4209b-774c-4e7f-82f5-bd16c9e09a72")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("458d3575-ba86-4a1f-a959-0410c5ebec19"),
                    new Guid("758a67a8-c377-4a35-be02-9df80002e5ba")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("23718b51-d3ab-4561-a505-822f31991a6d"),
                    new Guid("817b06dc-8244-4de9-be16-1ebb143299e1"),
                    new Guid("d3f7f997-b685-4d1e-9caa-f7569c73f780"),
                    new Guid("ef917eb2-08df-4c7d-bded-b4605bdcabae")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("6674cd67-fb1b-4dc5-883d-4c6e279343c9"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("86aa1485-6cb5-46eb-bc49-b268b5399920"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b23e19f-ead0-436b-9bc1-3e3a7018dff4"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e3c861b4-ea2a-4c8e-80d8-29d52e31ef56"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5a4209b-774c-4e7f-82f5-bd16c9e09a72"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("458d3575-ba86-4a1f-a959-0410c5ebec19"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("758a67a8-c377-4a35-be02-9df80002e5ba"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("23718b51-d3ab-4561-a505-822f31991a6d"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("817b06dc-8244-4de9-be16-1ebb143299e1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3f7f997-b685-4d1e-9caa-f7569c73f780"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef917eb2-08df-4c7d-bded-b4605bdcabae"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("23718b51-d3ab-4561-a505-822f31991a6d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("458d3575-ba86-4a1f-a959-0410c5ebec19"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6674cd67-fb1b-4dc5-883d-4c6e279343c9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("758a67a8-c377-4a35-be02-9df80002e5ba"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("817b06dc-8244-4de9-be16-1ebb143299e1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("86aa1485-6cb5-46eb-bc49-b268b5399920"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b23e19f-ead0-436b-9bc1-3e3a7018dff4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3f7f997-b685-4d1e-9caa-f7569c73f780"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e3c861b4-ea2a-4c8e-80d8-29d52e31ef56"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5a4209b-774c-4e7f-82f5-bd16c9e09a72"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ef917eb2-08df-4c7d-bded-b4605bdcabae"));

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
        }
    }
}
