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
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "StoreAddresses",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "Other");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "Gender", "PasswordHash" },
                values: new object[] { "3a11c200-bcb4-49a2-86f6-2872a12bd3ac", new DateTime(2025, 7, 11, 17, 7, 16, 33, DateTimeKind.Utc).AddTicks(166), "Other", "AQAAAAIAAYagAAAAELnpiK3mQBKNyxLpFXvZaSaPJNw8Ka2byPrhxXDnVavWg7HSQchY+VDE/+6SEqCFcQ==" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ApprovedById", "ApprovedUserId", "CreatedById", "CreatedDate", "CreationDate", "DeleteById", "DeletionDate", "Description", "ModificationById", "ModificationDate", "Name", "ParentCategoryId", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1107), null, null, "Các thiết bị y tế hỗ trợ chăm sóc sức khỏe người cao tuổi", null, null, "Thiết bị y tế", null, "Active" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1113), null, null, "Thực phẩm bổ sung dinh dưỡng cho người cao tuổi", null, null, "Thực phẩm dinh dưỡng", null, "Active" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1115), null, null, "Các dụng cụ hỗ trợ sinh hoạt hàng ngày", null, null, "Dụng cụ hỗ trợ", null, "Active" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1118), null, null, "Các dịch vụ tư vấn chăm sóc sức khỏe", null, null, "Dịch vụ tư vấn", null, "Active" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "Description", "ModificationById", "ModificationDate", "Name", "ProductType", "VideoPath" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111121"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2735), null, null, "Máy đo huyết áp điện tử tự động, dễ sử dụng cho người cao tuổi", null, null, "Máy đo huyết áp Omron HEM-7130", "Physical", "/videos/products/omron-hem-7130.mp4" },
                    { new Guid("11111111-1111-1111-1111-111111111122"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2742), null, null, "Máy đo đường huyết chính xác, ít đau khi lấy máu", null, null, "Máy đo đường huyết Accu-Chek Guide", "Physical", "/videos/products/accu-chek-guide.mp4" },
                    { new Guid("11111111-1111-1111-1111-111111111123"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2746), null, null, "Máy xông mũi họng siêu âm, hiệu quả cao", null, null, "Máy xông mũi họng Omron NE-C28", "Physical", "/videos/products/omron-ne-c28.mp4" },
                    { new Guid("22222222-2222-2222-2222-222222222225"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2749), null, null, "Sữa dinh dưỡng bổ sung protein và vitamin cho người cao tuổi", null, null, "Sữa Ensure Gold", "Consumable", "/videos/products/ensure-gold.mp4" },
                    { new Guid("22222222-2222-2222-2222-222222222226"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2751), null, null, "Bổ sung vitamin D3 và K2 cho xương khớp", null, null, "Vitamin D3 + K2", "Consumable", "/videos/products/vitamin-d3-k2.mp4" },
                    { new Guid("33333333-3333-3333-3333-333333333336"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2754), null, null, "Gậy chống 4 chân chống trượt, an toàn cho người cao tuổi", null, null, "Gậy chống 4 chân", "Physical", "/videos/products/gay-chong-4-chan.mp4" },
                    { new Guid("33333333-3333-3333-3333-333333333337"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2756), null, null, "Xe lăn tay gấp gọn, nhẹ và dễ di chuyển", null, null, "Xe lăn tay gấp gọn", "Physical", "/videos/products/xe-lan-tay.mp4" },
                    { new Guid("44444444-4444-4444-4444-444444444445"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2758), null, null, "Dịch vụ tư vấn dinh dưỡng trực tuyến với chuyên gia", null, null, "Tư vấn dinh dưỡng online", "Service", "/videos/services/tu-van-dinh-duong.mp4" },
                    { new Guid("44444444-4444-4444-4444-444444444446"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2772), null, null, "Gói khám sức khỏe định kỳ cho người cao tuổi", null, null, "Khám sức khỏe định kỳ", "Service", "/videos/services/kham-suc-khoe.mp4" }
                });

            migrationBuilder.InsertData(
                table: "StoreAddresses",
                columns: new[] { "Id", "Address", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "DistrictId", "DistrictName", "ModificationById", "ModificationDate", "ProvinceName", "WardCode", "WardName" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "123 Đường Lê Lợi", null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2622), null, null, 7601, "Quận 1", null, null, "TP. Hồ Chí Minh", "7601001", "Bến Nghé" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ApprovedById", "ApprovedUserId", "CreatedById", "CreatedDate", "CreationDate", "DeleteById", "DeletionDate", "Description", "ModificationById", "ModificationDate", "Name", "ParentCategoryId", "Status" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111112"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1121), null, null, "Các loại máy đo huyết áp điện tử", null, null, "Máy đo huyết áp", new Guid("11111111-1111-1111-1111-111111111111"), "Active" },
                    { new Guid("11111111-1111-1111-1111-111111111113"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1124), null, null, "Thiết bị đo đường huyết tại nhà", null, null, "Máy đo đường huyết", new Guid("11111111-1111-1111-1111-111111111111"), "Active" },
                    { new Guid("11111111-1111-1111-1111-111111111114"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1134), null, null, "Thiết bị xông mũi họng tại nhà", null, null, "Máy xông mũi họng", new Guid("11111111-1111-1111-1111-111111111111"), "Active" },
                    { new Guid("22222222-2222-2222-2222-222222222223"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1137), null, null, "Các loại sữa bổ sung dinh dưỡng", null, null, "Sữa dinh dưỡng", new Guid("22222222-2222-2222-2222-222222222222"), "Active" },
                    { new Guid("22222222-2222-2222-2222-222222222224"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1139), null, null, "Thực phẩm chức năng bổ sung vitamin", null, null, "Vitamin và khoáng chất", new Guid("22222222-2222-2222-2222-222222222222"), "Active" },
                    { new Guid("33333333-3333-3333-3333-333333333334"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1142), null, null, "Các loại gậy hỗ trợ đi lại", null, null, "Gậy chống", new Guid("33333333-3333-3333-3333-333333333333"), "Active" },
                    { new Guid("33333333-3333-3333-3333-333333333335"), null, null, null, null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1144), null, null, "Xe lăn hỗ trợ di chuyển", null, null, "Xe lăn", new Guid("33333333-3333-3333-3333-333333333333"), "Active" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "CategoryId", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate", "ProductId" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444449"), new Guid("44444444-4444-4444-4444-444444444444"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(4036), null, null, null, null, new Guid("44444444-4444-4444-4444-444444444445") },
                    { new Guid("44444444-4444-4444-4444-444444444450"), new Guid("44444444-4444-4444-4444-444444444444"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(4038), null, null, null, null, new Guid("44444444-4444-4444-4444-444444444446") }
                });

            migrationBuilder.InsertData(
                table: "ProductVariants",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "IsActive", "ModificationById", "ModificationDate", "Price", "ProductId", "Stock", "VariantName" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111131"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2871), null, null, true, null, null, 850000m, new Guid("11111111-1111-1111-1111-111111111121"), 50, "Máy đo huyết áp Omron HEM-7130 - Màu trắng" },
                    { new Guid("11111111-1111-1111-1111-111111111132"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2875), null, null, true, null, null, 850000m, new Guid("11111111-1111-1111-1111-111111111121"), 30, "Máy đo huyết áp Omron HEM-7130 - Màu xanh" },
                    { new Guid("11111111-1111-1111-1111-111111111133"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2878), null, null, true, null, null, 1200000m, new Guid("11111111-1111-1111-1111-111111111122"), 25, "Máy đo đường huyết Accu-Chek Guide - Bộ cơ bản" },
                    { new Guid("11111111-1111-1111-1111-111111111134"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2880), null, null, true, null, null, 1500000m, new Guid("11111111-1111-1111-1111-111111111122"), 20, "Máy đo đường huyết Accu-Chek Guide - Bộ đầy đủ" },
                    { new Guid("22222222-2222-2222-2222-222222222227"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2883), null, null, true, null, null, 280000m, new Guid("22222222-2222-2222-2222-222222222225"), 100, "Sữa Ensure Gold - Hộp 400g" },
                    { new Guid("22222222-2222-2222-2222-222222222228"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2885), null, null, true, null, null, 520000m, new Guid("22222222-2222-2222-2222-222222222225"), 80, "Sữa Ensure Gold - Hộp 850g" },
                    { new Guid("22222222-2222-2222-2222-222222222229"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2889), null, null, true, null, null, 180000m, new Guid("22222222-2222-2222-2222-222222222226"), 150, "Vitamin D3+K2 - Lọ 60 viên" },
                    { new Guid("33333333-3333-3333-3333-333333333338"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2900), null, null, true, null, null, 450000m, new Guid("33333333-3333-3333-3333-333333333336"), 40, "Gậy chống 4 chân - Màu đen" },
                    { new Guid("33333333-3333-3333-3333-333333333339"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2907), null, null, true, null, null, 450000m, new Guid("33333333-3333-3333-3333-333333333336"), 35, "Gậy chống 4 chân - Màu xanh" },
                    { new Guid("33333333-3333-3333-3333-333333333340"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2909), null, null, true, null, null, 2800000m, new Guid("33333333-3333-3333-3333-333333333337"), 15, "Xe lăn tay gấp gọn - Màu xanh" },
                    { new Guid("44444444-4444-4444-4444-444444444447"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2912), null, null, true, null, null, 500000m, new Guid("44444444-4444-4444-4444-444444444445"), 999, "Tư vấn dinh dưỡng - 1 buổi" },
                    { new Guid("44444444-4444-4444-4444-444444444448"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(2915), null, null, true, null, null, 2000000m, new Guid("44444444-4444-4444-4444-444444444445"), 999, "Tư vấn dinh dưỡng - Gói 5 buổi" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "AdditionalInfo", "AvatarPath", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "GhnShopId", "Infomation", "IsActive", "IsBanned", "IsGhnSynced", "IsVerified", "ModificationById", "ModificationDate", "Name", "Phone", "StoreAddressId" },
                values: new object[] { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), null, "/images/stores/doc-lap.jpg", null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(1527), null, null, null, "Cửa hàng độc lập chuyên cung cấp thiết bị y tế và thuốc cho người cao tuổi", true, false, false, 1, null, null, "Nhà thuốc Độc Lập", "028-1234-5678", new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa") });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "Id", "CategoryId", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ModificationById", "ModificationDate", "ProductId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111161"), new Guid("11111111-1111-1111-1111-111111111112"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3968), null, null, null, null, new Guid("11111111-1111-1111-1111-111111111121") },
                    { new Guid("11111111-1111-1111-1111-111111111162"), new Guid("11111111-1111-1111-1111-111111111113"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3974), null, null, null, null, new Guid("11111111-1111-1111-1111-111111111122") },
                    { new Guid("11111111-1111-1111-1111-111111111163"), new Guid("11111111-1111-1111-1111-111111111114"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3977), null, null, null, null, new Guid("11111111-1111-1111-1111-111111111123") },
                    { new Guid("22222222-2222-2222-2222-222222222233"), new Guid("22222222-2222-2222-2222-222222222223"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3979), null, null, null, null, new Guid("22222222-2222-2222-2222-222222222225") },
                    { new Guid("22222222-2222-2222-2222-222222222234"), new Guid("22222222-2222-2222-2222-222222222224"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3981), null, null, null, null, new Guid("22222222-2222-2222-2222-222222222226") },
                    { new Guid("33333333-3333-3333-3333-333333333345"), new Guid("33333333-3333-3333-3333-333333333334"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3984), null, null, null, null, new Guid("33333333-3333-3333-3333-333333333336") },
                    { new Guid("33333333-3333-3333-3333-333333333346"), new Guid("33333333-3333-3333-3333-333333333335"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(4033), null, null, null, null, new Guid("33333333-3333-3333-3333-333333333337") }
                });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "DiscountedPrice", "Height", "IsActive", "Length", "ModificationById", "ModificationDate", "OriginalPrice", "SKU", "Stock", "StoreId", "VariantId", "Weight", "Width" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111141"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3063), null, null, 800000m, 10, true, 20, null, null, 850000m, "OMRON-HEM-7130-WHITE-DL", 25, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("11111111-1111-1111-1111-111111111131"), 500, 15 },
                    { new Guid("11111111-1111-1111-1111-111111111142"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3068), null, null, 1100000m, 5, true, 15, null, null, 1200000m, "ACCU-CHEK-GUIDE-BASIC-DL", 15, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("11111111-1111-1111-1111-111111111133"), 300, 10 },
                    { new Guid("22222222-2222-2222-2222-222222222230"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3072), null, null, 250000m, 6, true, 12, null, null, 280000m, "ENSURE-GOLD-400G-DL", 50, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("22222222-2222-2222-2222-222222222227"), 400, 8 },
                    { new Guid("22222222-2222-2222-2222-222222222231"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3076), null, null, 160000m, 3, true, 8, null, null, 180000m, "VITAMIN-D3-K2-60-DL", 75, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("22222222-2222-2222-2222-222222222229"), 100, 5 },
                    { new Guid("33333333-3333-3333-3333-333333333341"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3081), null, null, 420000m, 5, true, 120, null, null, 450000m, "GAY-CHONG-4-CHAN-BLACK-DL", 20, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("33333333-3333-3333-3333-333333333338"), 800, 5 },
                    { new Guid("33333333-3333-3333-3333-333333333342"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3085), null, null, 2600000m, 90, true, 100, null, null, 2800000m, "XE-LAN-TAY-XANH-DL", 8, new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), new Guid("33333333-3333-3333-3333-333333333340"), 15000, 60 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedById", "CreationDate", "DeleteById", "DeletionDate", "ImageName", "ImagePath", "ModificationById", "ModificationDate", "ProductId", "ProductItemId" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111151"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3212), null, null, "Máy đo huyết áp Omron HEM-7130 - Ảnh 1", "/images/products/omron-hem-7130-white-1.jpg", null, null, null, new Guid("11111111-1111-1111-1111-111111111141") },
                    { new Guid("11111111-1111-1111-1111-111111111152"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3214), null, null, "Máy đo huyết áp Omron HEM-7130 - Ảnh 2", "/images/products/omron-hem-7130-white-2.jpg", null, null, null, new Guid("11111111-1111-1111-1111-111111111141") },
                    { new Guid("22222222-2222-2222-2222-222222222232"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3217), null, null, "Sữa Ensure Gold 400g - Ảnh 1", "/images/products/ensure-gold-400g-1.jpg", null, null, null, new Guid("22222222-2222-2222-2222-222222222230") },
                    { new Guid("33333333-3333-3333-3333-333333333343"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3219), null, null, "Gậy chống 4 chân đen - Ảnh 1", "/images/products/gay-chong-4-chan-black-1.jpg", null, null, null, new Guid("33333333-3333-3333-3333-333333333341") },
                    { new Guid("33333333-3333-3333-3333-333333333344"), null, new DateTime(2025, 7, 11, 17, 7, 15, 989, DateTimeKind.Utc).AddTicks(3221), null, null, "Xe lăn tay xanh - Ảnh 1", "/images/products/xe-lan-tay-xanh-1.jpg", null, null, null, new Guid("33333333-3333-3333-3333-333333333342") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111161"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111162"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111163"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222233"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222234"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333345"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333346"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444449"));

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444450"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111151"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111152"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222232"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333343"));

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333344"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111142"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222231"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111132"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111134"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222228"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333339"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444447"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444448"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111114"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222223"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222224"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333334"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333335"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111141"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222230"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333341"));

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333342"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111133"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222229"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111123"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444445"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444446"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111131"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222227"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333338"));

            migrationBuilder.DeleteData(
                table: "ProductVariants",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333340"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111122"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222226"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111121"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222225"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333336"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333337"));

            migrationBuilder.DeleteData(
                table: "StoreAddresses",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "StoreAddresses",
                newName: "StreetAddress");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9878ee32-2ead-4165-9e44-e510ba1bae29"),
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash" },
                values: new object[] { "305193f4-ffdb-4335-bd41-8197e5a0b1c2", new DateTime(2025, 7, 10, 15, 50, 55, 509, DateTimeKind.Utc).AddTicks(7145), "AQAAAAIAAYagAAAAEBMIJ7DmIzhO/9HZUqMNGNJo7yigDjHNfcLRsT1Fh1I5iUiu0jV3dPwYEuLOFJowsQ==" });
        }
    }
}
