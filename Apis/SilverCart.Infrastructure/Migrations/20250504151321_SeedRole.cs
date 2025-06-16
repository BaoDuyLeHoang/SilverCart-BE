using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministratorUserRoles_AspNetRoles_Id",
                table: "AdministratorUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdministratorUsers_AdministratorUserRoles_RoleId",
                table: "AdministratorUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreUserRoles",
                table: "StoreUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdministratorUserRoles",
                table: "AdministratorUserRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StoreUserRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StoreUserRoles");

            migrationBuilder.RenameTable(
                name: "AdministratorUserRoles",
                newName: "AdministratorRoles");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserReports",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPromotions",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 97);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModificationById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 98);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 99);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeleteById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 95);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 96);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Stores",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StockHistories",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScheduledTasks",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Reports",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Promotions",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductVariants",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductReports",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductPromotions",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductItems",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductImages",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PaymentMethods",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PaymentMethodHistories",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderStatuses",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Orders",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderReviews",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderItems",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerRoleId",
                table: "CustomerUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CustomerRanks",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CustomerAddresses",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Categories",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CartItem",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Cart",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Addresses",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreUserRoles",
                table: "StoreUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdministratorRoles",
                table: "AdministratorRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomerRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerRoles_AspNetRoles_Id",
                        column: x => x.Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUsers_CustomerRoleId",
                table: "CustomerUsers",
                column: "CustomerRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorRoles_AspNetRoles_Id",
                table: "AdministratorRoles",
                column: "Id",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorUsers_AdministratorRoles_RoleId",
                table: "AdministratorUsers",
                column: "RoleId",
                principalTable: "AdministratorRoles",
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
                name: "FK_AdministratorRoles_AspNetRoles_Id",
                table: "AdministratorRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AdministratorUsers_AdministratorRoles_RoleId",
                table: "AdministratorUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUsers_CustomerRoles_CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.DropTable(
                name: "CustomerRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreUserRoles",
                table: "StoreUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_CustomerUsers_CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdministratorRoles",
                table: "AdministratorRoles");

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
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22deabd7-21bc-459d-9cbe-413b560ccb44"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
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

            migrationBuilder.DropColumn(
                name: "CustomerRoleId",
                table: "CustomerUsers");

            migrationBuilder.RenameTable(
                name: "AdministratorRoles",
                newName: "AdministratorUserRoles");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserReports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserPromotions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 97);

            migrationBuilder.AlterColumn<Guid>(
                name: "ModificationById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 98);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletionDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 99);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeleteById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "StoreUserRoles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 95);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 96);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StoreUserRoles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"))
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StoreUserRoles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Stores",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StockHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ScheduledTasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Reports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Promotions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductVariants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductReports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductPromotions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductImages",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PaymentMethods",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PaymentMethodHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderStatuses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderReviews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OrderItems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CustomerRanks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CustomerPaymentMethods",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CustomerAddresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "CartItem",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Cart",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Addresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("6257c3dc-b67d-45c5-84fb-cf10a3513734"),
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreUserRoles",
                table: "StoreUserRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdministratorUserRoles",
                table: "AdministratorUserRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorUserRoles_AspNetRoles_Id",
                table: "AdministratorUserRoles",
                column: "Id",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorUsers_AdministratorUserRoles_RoleId",
                table: "AdministratorUsers",
                column: "RoleId",
                principalTable: "AdministratorUserRoles",
                principalColumn: "Id");
        }
    }
}
