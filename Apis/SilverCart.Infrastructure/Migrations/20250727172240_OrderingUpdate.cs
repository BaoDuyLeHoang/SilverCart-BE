using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class OrderingUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AdministratorUsers_AdministratorUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_ConsultantUsers_ConsultantUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CustomerUsers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_DependentUsers_DependentUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_GuardianUsers_GuardianUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_StoreUsers_StoreUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Stores_StoreAddressId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AdministratorUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ConsultantUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DependentUserId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_GuardianUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "OrderGhnCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AdministratorUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ConsultantUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DependentUserId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "GuardianUserId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Orders",
                newName: "ToAddress");

            migrationBuilder.RenameColumn(
                name: "ToProvinceName",
                table: "Addresses",
                newName: "WardName");

            migrationBuilder.RenameColumn(
                name: "ToDistrictName",
                table: "Addresses",
                newName: "ProvinceName");

            migrationBuilder.RenameColumn(
                name: "StoreUserId",
                table: "Addresses",
                newName: "BaseUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StoreUserId",
                table: "Addresses",
                newName: "IX_Addresses_BaseUserId");

            migrationBuilder.AlterColumn<string>(
                name: "WardCode",
                table: "StoreAddresses",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "StoreAddresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "StoreAddresses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                table: "StoreAddresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductItemId",
                table: "ProductReports",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ProductItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProductItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ConfirmUserId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromAddress",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderedUserId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecieveUserId",
                table: "Orders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "Addresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "DistrictId", "DistrictName", "ProvinceId", "ProvinceName", "StoreId", "StreetAddress", "WardCode", "WardName" },
                values: new object[] { 1451, "Quận 9", 202, "Hồ Chí Minh", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), "123 Lê Văn Việt", "20901", "Phường Hiệp Phú" });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                columns: new[] { "AvatarPath", "GhnShopId", "Phone" },
                values: new object[] { "/images/stores/store.jpg", 197185, "02812345678" });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreAddressId",
                table: "Stores",
                column: "StoreAddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductReports_ProductItemId",
                table: "ProductReports",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ConfirmUserId",
                table: "Orders",
                column: "ConfirmUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderedUserId",
                table: "Orders",
                column: "OrderedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RecieveUserId",
                table: "Orders",
                column: "RecieveUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AspNetUsers_BaseUserId",
                table: "Addresses",
                column: "BaseUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_OrderedUserId",
                table: "Orders",
                column: "OrderedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_RecieveUserId",
                table: "Orders",
                column: "RecieveUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_GuardianUsers_ConfirmUserId",
                table: "Orders",
                column: "ConfirmUserId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReports_ProductItems_ProductItemId",
                table: "ProductReports",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AspNetUsers_BaseUserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_OrderedUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_RecieveUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_GuardianUsers_ConfirmUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReports_ProductItems_ProductItemId",
                table: "ProductReports");

            migrationBuilder.DropIndex(
                name: "IX_Stores_StoreAddressId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_ProductReports_ProductItemId",
                table: "ProductReports");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ConfirmUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderedUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RecieveUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                table: "StoreAddresses");

            migrationBuilder.DropColumn(
                name: "ProductItemId",
                table: "ProductReports");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ConfirmUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderedUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RecieveUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "ToAddress",
                table: "Orders",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "WardName",
                table: "Addresses",
                newName: "ToProvinceName");

            migrationBuilder.RenameColumn(
                name: "ProvinceName",
                table: "Addresses",
                newName: "ToDistrictName");

            migrationBuilder.RenameColumn(
                name: "BaseUserId",
                table: "Addresses",
                newName: "StoreUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_BaseUserId",
                table: "Addresses",
                newName: "IX_Addresses_StoreUserId");

            migrationBuilder.AlterColumn<string>(
                name: "WardCode",
                table: "StoreAddresses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "StoreAddresses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrderGhnCode",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultantUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DependentUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GuardianUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                columns: new[] { "Address", "DistrictId", "DistrictName", "ProvinceName", "WardCode", "WardName" },
                values: new object[] { "123 Đường Độc Lập", 1, "Quận 1", "TP.HCM", "00001", "Phường 1" });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                columns: new[] { "AvatarPath", "GhnShopId", "Phone" },
                values: new object[] { "/images/stores/doc-lap.jpg", null, "028-1234-5678" });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_StoreAddressId",
                table: "Stores",
                column: "StoreAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AdministratorUserId",
                table: "Addresses",
                column: "AdministratorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ConsultantUserId",
                table: "Addresses",
                column: "ConsultantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DependentUserId",
                table: "Addresses",
                column: "DependentUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_GuardianUserId",
                table: "Addresses",
                column: "GuardianUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AdministratorUsers_AdministratorUserId",
                table: "Addresses",
                column: "AdministratorUserId",
                principalTable: "AdministratorUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_ConsultantUsers_ConsultantUserId",
                table: "Addresses",
                column: "ConsultantUserId",
                principalTable: "ConsultantUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CustomerUsers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "CustomerUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_DependentUsers_DependentUserId",
                table: "Addresses",
                column: "DependentUserId",
                principalTable: "DependentUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_GuardianUsers_GuardianUserId",
                table: "Addresses",
                column: "GuardianUserId",
                principalTable: "GuardianUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_StoreUsers_StoreUserId",
                table: "Addresses",
                column: "StoreUserId",
                principalTable: "StoreUsers",
                principalColumn: "Id");
        }
    }
}
