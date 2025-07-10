using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructures.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultantUserIntoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a344170-fe93-4320-b1d3-0140a7d571a1"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d0f01df-3615-46a4-bedc-c4ba95df7235"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("767b762c-120b-468a-acb9-111a06845b75"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8354fca4-0dfd-4c9e-8e7b-220a9a53e2c1"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("e0117101-92d0-4dd3-afe4-a3326411c30c"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("0662e0a3-ae05-4d8f-b56c-c9528157e256"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("340e58a8-4605-4317-a18a-f2fc3e96940f"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("f23b2eb1-57ab-49be-9310-5321809d9339"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("21380e35-8549-4229-a714-99e2ea5ca9c4"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("6077bf32-6d29-41ce-af9d-abcd48266407"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cbc4362-00c7-4d29-9607-9523ac92d1de"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6f93435-b61f-4320-abf4-5551c1101e6f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0662e0a3-ae05-4d8f-b56c-c9528157e256"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1a344170-fe93-4320-b1d3-0140a7d571a1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("21380e35-8549-4229-a714-99e2ea5ca9c4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("340e58a8-4605-4317-a18a-f2fc3e96940f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d0f01df-3615-46a4-bedc-c4ba95df7235"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6077bf32-6d29-41ce-af9d-abcd48266407"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("767b762c-120b-468a-acb9-111a06845b75"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7cbc4362-00c7-4d29-9607-9523ac92d1de"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8354fca4-0dfd-4c9e-8e7b-220a9a53e2c1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6f93435-b61f-4320-abf4-5551c1101e6f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e0117101-92d0-4dd3-afe4-a3326411c30c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f23b2eb1-57ab-49be-9310-5321809d9339"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultantUserId",
                table: "Addresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConsultantRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConsultantId = table.Column<Guid>(type: "uuid", nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Specialization = table.Column<string>(type: "text", nullable: false),
                    Biography = table.Column<string>(type: "text", nullable: false),
                    AvatarPath = table.Column<string>(type: "text", nullable: false),
                    ExpertiseArea = table.Column<string>(type: "text", nullable: false),
                    StringeeAccessToken = table.Column<string>(type: "text", nullable: true),
                    OTP_Code = table.Column<string>(type: "text", nullable: true),
                    OTP_ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OTP_IsUsed = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultantUsers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantUsers_ConsultantRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ConsultantRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    ConsultationId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConsultantId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportContent = table.Column<string>(type: "text", nullable: false),
                    VideoRecordingUrl = table.Column<string>(type: "text", nullable: true),
                    ScheduledTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CompletedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.ConsultationId);
                    table.ForeignKey(
                        name: "FK_Consultations_ConsultantUsers_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "ConsultantUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultations_DependentUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "DependentUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("173fc708-aea2-4bcd-9861-8fb19eb612a3"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("203ad3a0-11b2-47c5-8b98-78ff0a16a01d"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" },
                    { new Guid("5a567d6b-1620-473f-b24a-6a5a3f5408a1"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("6a72b987-691f-49fc-a910-6aa44932ae4c"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" },
                    { new Guid("8f3ba28d-9ad7-4c94-88d2-f4b4e064cfb5"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("93d7f3b0-cc71-4c16-bbd1-5e358d164044"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("a6cbb423-6c15-4c76-9c20-63405639fbd1"), null, null, null, null, null, "", false, null, null, "StoreManager", "STOREMANAGER" },
                    { new Guid("ae0686e5-ce21-4e1e-948e-ac6f87f90223"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("cd0ecebd-943b-480c-a83a-b3c1c2d9d212"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("d3334862-46a7-4530-913a-ef9c09b9c9e0"), null, null, null, null, null, "", false, null, null, "StoreDelivery", "STOREDELIVERY" },
                    { new Guid("e11161bb-7a83-42ce-a3d5-e126f14d083b"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" },
                    { new Guid("f6e24425-af70-4185-b8d4-02276e34f898"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "2c50b19f-0dd3-41fc-baf1-23e02709360e", new DateTime(2025, 7, 6, 8, 1, 24, 447, DateTimeKind.Utc).AddTicks(5179), "AQAAAAIAAYagAAAAEJW4aE5g7BQFTpuxV7xm51ufIJG1F9aXCPG3fHkkSGVn4pnUB0WZ8P3HXijhgyruLQ==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("173fc708-aea2-4bcd-9861-8fb19eb612a3"),
                    new Guid("5a567d6b-1620-473f-b24a-6a5a3f5408a1"),
                    new Guid("8f3ba28d-9ad7-4c94-88d2-f4b4e064cfb5"),
                    new Guid("cd0ecebd-943b-480c-a83a-b3c1c2d9d212"),
                    new Guid("f6e24425-af70-4185-b8d4-02276e34f898")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("93d7f3b0-cc71-4c16-bbd1-5e358d164044"),
                    new Guid("ae0686e5-ce21-4e1e-948e-ac6f87f90223"),
                    new Guid("e11161bb-7a83-42ce-a3d5-e126f14d083b")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("203ad3a0-11b2-47c5-8b98-78ff0a16a01d"),
                    new Guid("6a72b987-691f-49fc-a910-6aa44932ae4c"),
                    new Guid("a6cbb423-6c15-4c76-9c20-63405639fbd1"),
                    new Guid("d3334862-46a7-4530-913a-ef9c09b9c9e0")
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ConsultantUserId",
                table: "Addresses",
                column: "ConsultantUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantUsers_RoleId",
                table: "ConsultantUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_ConsultantId",
                table: "Consultations",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_CustomerId",
                table: "Consultations",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_ConsultantUsers_ConsultantUserId",
                table: "Addresses",
                column: "ConsultantUserId",
                principalTable: "ConsultantUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_ConsultantUsers_ConsultantUserId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "ConsultantUsers");

            migrationBuilder.DropTable(
                name: "ConsultantRoles");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ConsultantUserId",
                table: "Addresses");

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("173fc708-aea2-4bcd-9861-8fb19eb612a3"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a567d6b-1620-473f-b24a-6a5a3f5408a1"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f3ba28d-9ad7-4c94-88d2-f4b4e064cfb5"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd0ecebd-943b-480c-a83a-b3c1c2d9d212"));

            migrationBuilder.DeleteData(
                table: "AdministratorRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6e24425-af70-4185-b8d4-02276e34f898"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("93d7f3b0-cc71-4c16-bbd1-5e358d164044"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae0686e5-ce21-4e1e-948e-ac6f87f90223"));

            migrationBuilder.DeleteData(
                table: "CustomerRoles",
                keyColumn: "Id",
                keyValue: new Guid("e11161bb-7a83-42ce-a3d5-e126f14d083b"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("203ad3a0-11b2-47c5-8b98-78ff0a16a01d"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("6a72b987-691f-49fc-a910-6aa44932ae4c"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6cbb423-6c15-4c76-9c20-63405639fbd1"));

            migrationBuilder.DeleteData(
                table: "StoreRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3334862-46a7-4530-913a-ef9c09b9c9e0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("173fc708-aea2-4bcd-9861-8fb19eb612a3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("203ad3a0-11b2-47c5-8b98-78ff0a16a01d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5a567d6b-1620-473f-b24a-6a5a3f5408a1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6a72b987-691f-49fc-a910-6aa44932ae4c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8f3ba28d-9ad7-4c94-88d2-f4b4e064cfb5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93d7f3b0-cc71-4c16-bbd1-5e358d164044"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a6cbb423-6c15-4c76-9c20-63405639fbd1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae0686e5-ce21-4e1e-948e-ac6f87f90223"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cd0ecebd-943b-480c-a83a-b3c1c2d9d212"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d3334862-46a7-4530-913a-ef9c09b9c9e0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e11161bb-7a83-42ce-a3d5-e126f14d083b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f6e24425-af70-4185-b8d4-02276e34f898"));

            migrationBuilder.DropColumn(
                name: "ConsultantUserId",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "IsDeleted", "ModificationById", "ModificationDate", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0662e0a3-ae05-4d8f-b56c-c9528157e256"), null, null, null, null, null, "", false, null, null, "Customer", "CUSTOMER" },
                    { new Guid("1a344170-fe93-4320-b1d3-0140a7d571a1"), null, null, null, null, null, "", false, null, null, "CustomerSupport", "CUSTOMERSUPPORT" },
                    { new Guid("21380e35-8549-4229-a714-99e2ea5ca9c4"), null, null, null, null, null, "", false, null, null, "StoreManager", "STOREMANAGER" },
                    { new Guid("340e58a8-4605-4317-a18a-f2fc3e96940f"), null, null, null, null, null, "", false, null, null, "Guardian", "GUARDIAN" },
                    { new Guid("3d0f01df-3615-46a4-bedc-c4ba95df7235"), null, null, null, null, null, "", false, null, null, "Moderator", "MODERATOR" },
                    { new Guid("6077bf32-6d29-41ce-af9d-abcd48266407"), null, null, null, null, null, "", false, null, null, "StoreSupport", "STORESUPPORT" },
                    { new Guid("767b762c-120b-468a-acb9-111a06845b75"), null, null, null, null, null, "", false, null, null, "SuperAdmin", "SUPERADMIN" },
                    { new Guid("7cbc4362-00c7-4d29-9607-9523ac92d1de"), null, null, null, null, null, "", false, null, null, "StoreDelivery", "STOREDELIVERY" },
                    { new Guid("8354fca4-0dfd-4c9e-8e7b-220a9a53e2c1"), null, null, null, null, null, "", false, null, null, "Staff", "STAFF" },
                    { new Guid("a6f93435-b61f-4320-abf4-5551c1101e6f"), null, null, null, null, null, "", false, null, null, "StoreOwner", "STOREOWNER" },
                    { new Guid("e0117101-92d0-4dd3-afe4-a3326411c30c"), null, null, null, null, null, "", false, null, null, "Admin", "ADMIN" },
                    { new Guid("f23b2eb1-57ab-49be-9310-5321809d9339"), null, null, null, null, null, "", false, null, null, "DependentUser", "DEPENDENTUSER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "e47288a8-97c2-49c4-841f-cc47ba2579d7", new DateTime(2025, 6, 7, 3, 12, 36, 257, DateTimeKind.Utc).AddTicks(2861), "AQAAAAIAAYagAAAAEHVIvA+Yep+a4JTQ9OlUyw6R5LORE+3S691mZIIn2JHrDZ4yPR/oLdq9qNu5A7usRA==" });

            migrationBuilder.InsertData(
                table: "AdministratorRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("1a344170-fe93-4320-b1d3-0140a7d571a1"),
                    new Guid("3d0f01df-3615-46a4-bedc-c4ba95df7235"),
                    new Guid("767b762c-120b-468a-acb9-111a06845b75"),
                    new Guid("8354fca4-0dfd-4c9e-8e7b-220a9a53e2c1"),
                    new Guid("e0117101-92d0-4dd3-afe4-a3326411c30c")
                });

            migrationBuilder.InsertData(
                table: "CustomerRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("0662e0a3-ae05-4d8f-b56c-c9528157e256"),
                    new Guid("340e58a8-4605-4317-a18a-f2fc3e96940f"),
                    new Guid("f23b2eb1-57ab-49be-9310-5321809d9339")
                });

            migrationBuilder.InsertData(
                table: "StoreRoles",
                column: "Id",
                values: new object[]
                {
                    new Guid("21380e35-8549-4229-a714-99e2ea5ca9c4"),
                    new Guid("6077bf32-6d29-41ce-af9d-abcd48266407"),
                    new Guid("7cbc4362-00c7-4d29-9607-9523ac92d1de"),
                    new Guid("a6f93435-b61f-4320-abf4-5551c1101e6f")
                });
        }
    }
}
