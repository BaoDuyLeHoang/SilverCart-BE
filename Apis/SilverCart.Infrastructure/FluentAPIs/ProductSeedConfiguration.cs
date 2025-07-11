using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;

namespace Infrastructures.FluentAPIs
{
    public class ProductSeedConfiguration : IEntityTypeConfiguration<Category>, 
        IEntityTypeConfiguration<Store>, 
        IEntityTypeConfiguration<StoreAddress>,
        IEntityTypeConfiguration<Product>,
        IEntityTypeConfiguration<ProductVariant>,
        IEntityTypeConfiguration<ProductItem>,
        IEntityTypeConfiguration<ProductImage>,
        IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                // Main Categories for Elderly Care
                new Category
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    Name = "Thiết bị y tế",
                    Description = "Các thiết bị y tế hỗ trợ chăm sóc sức khỏe người cao tuổi",
                    Status = CategoryStatusEnum.Active,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    Name = "Thực phẩm dinh dưỡng",
                    Description = "Thực phẩm bổ sung dinh dưỡng cho người cao tuổi",
                    Status = CategoryStatusEnum.Active,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    Name = "Dụng cụ hỗ trợ",
                    Description = "Các dụng cụ hỗ trợ sinh hoạt hàng ngày",
                    Status = CategoryStatusEnum.Active,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    Name = "Dịch vụ tư vấn",
                    Description = "Các dịch vụ tư vấn chăm sóc sức khỏe",
                    Status = CategoryStatusEnum.Active,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Sub-categories for Medical Devices
                new Category
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                    Name = "Máy đo huyết áp",
                    Description = "Các loại máy đo huyết áp điện tử",
                    Status = CategoryStatusEnum.Active,
                    ParentCategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                    Name = "Máy đo đường huyết",
                    Description = "Thiết bị đo đường huyết tại nhà",
                    Status = CategoryStatusEnum.Active,
                    ParentCategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                    Name = "Máy xông mũi họng",
                    Description = "Thiết bị xông mũi họng tại nhà",
                    Status = CategoryStatusEnum.Active,
                    ParentCategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Sub-categories for Nutrition
                new Category
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222223"),
                    Name = "Sữa dinh dưỡng",
                    Description = "Các loại sữa bổ sung dinh dưỡng",
                    Status = CategoryStatusEnum.Active,
                    ParentCategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222224"),
                    Name = "Vitamin và khoáng chất",
                    Description = "Thực phẩm chức năng bổ sung vitamin",
                    Status = CategoryStatusEnum.Active,
                    ParentCategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Sub-categories for Support Tools
                new Category
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333334"),
                    Name = "Gậy chống",
                    Description = "Các loại gậy hỗ trợ đi lại",
                    Status = CategoryStatusEnum.Active,
                    ParentCategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333335"),
                    Name = "Xe lăn",
                    Description = "Xe lăn hỗ trợ di chuyển",
                    Status = CategoryStatusEnum.Active,
                    ParentCategoryId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        public void Configure(EntityTypeBuilder<StoreAddress> builder)
        {
            builder.HasData(
                new StoreAddress
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Address = "123 Đường Lê Lợi",
                    WardCode = "7601001",
                    DistrictId = 7601,
                    WardName = "Bến Nghé",
                    DistrictName = "Quận 1",
                    ProvinceName = "TP. Hồ Chí Minh",
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(
                new Store
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                    Name = "Nhà thuốc Độc Lập",
                    Infomation = "Cửa hàng độc lập chuyên cung cấp thiết bị y tế và thuốc cho người cao tuổi",
                    AvatarPath = "/images/stores/doc-lap.jpg",
                    Phone = "028-1234-5678",
                    IsBanned = false,
                    IsActive = true,
                    IsVerified = 1,
                    StoreAddressId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                // Medical Devices
                new Product
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                    Name = "Máy đo huyết áp Omron HEM-7130",
                    Description = "Máy đo huyết áp điện tử tự động, dễ sử dụng cho người cao tuổi",
                    VideoPath = "/videos/products/omron-hem-7130.mp4",
                    ProductType = ProductTypeEnum.Physical,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Product
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                    Name = "Máy đo đường huyết Accu-Chek Guide",
                    Description = "Máy đo đường huyết chính xác, ít đau khi lấy máu",
                    VideoPath = "/videos/products/accu-chek-guide.mp4",
                    ProductType = ProductTypeEnum.Physical,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Product
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                    Name = "Máy xông mũi họng Omron NE-C28",
                    Description = "Máy xông mũi họng siêu âm, hiệu quả cao",
                    VideoPath = "/videos/products/omron-ne-c28.mp4",
                    ProductType = ProductTypeEnum.Physical,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Nutrition Products
                new Product
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222225"),
                    Name = "Sữa Ensure Gold",
                    Description = "Sữa dinh dưỡng bổ sung protein và vitamin cho người cao tuổi",
                    VideoPath = "/videos/products/ensure-gold.mp4",
                    ProductType = ProductTypeEnum.Consumable,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Product
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222226"),
                    Name = "Vitamin D3 + K2",
                    Description = "Bổ sung vitamin D3 và K2 cho xương khớp",
                    VideoPath = "/videos/products/vitamin-d3-k2.mp4",
                    ProductType = ProductTypeEnum.Consumable,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Support Tools
                new Product
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333336"),
                    Name = "Gậy chống 4 chân",
                    Description = "Gậy chống 4 chân chống trượt, an toàn cho người cao tuổi",
                    VideoPath = "/videos/products/gay-chong-4-chan.mp4",
                    ProductType = ProductTypeEnum.Physical,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Product
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333337"),
                    Name = "Xe lăn tay gấp gọn",
                    Description = "Xe lăn tay gấp gọn, nhẹ và dễ di chuyển",
                    VideoPath = "/videos/products/xe-lan-tay.mp4",
                    ProductType = ProductTypeEnum.Physical,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Services
                new Product
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444445"),
                    Name = "Tư vấn dinh dưỡng online",
                    Description = "Dịch vụ tư vấn dinh dưỡng trực tuyến với chuyên gia",
                    VideoPath = "/videos/services/tu-van-dinh-duong.mp4",
                    ProductType = ProductTypeEnum.Service,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new Product
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444446"),
                    Name = "Khám sức khỏe định kỳ",
                    Description = "Gói khám sức khỏe định kỳ cho người cao tuổi",
                    VideoPath = "/videos/services/kham-suc-khoe.mp4",
                    ProductType = ProductTypeEnum.Service,
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasData(
                // Omron HEM-7130 variants
                new ProductVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111131"),
                    VariantName = "Máy đo huyết áp Omron HEM-7130 - Màu trắng",
                    Price = 850000,
                    Stock = 50,
                    IsActive = true,
                    ProductId = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111132"),
                    VariantName = "Máy đo huyết áp Omron HEM-7130 - Màu xanh",
                    Price = 850000,
                    Stock = 30,
                    IsActive = true,
                    ProductId = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Accu-Chek Guide variants
                new ProductVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111133"),
                    VariantName = "Máy đo đường huyết Accu-Chek Guide - Bộ cơ bản",
                    Price = 1200000,
                    Stock = 25,
                    IsActive = true,
                    ProductId = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductVariant
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111134"),
                    VariantName = "Máy đo đường huyết Accu-Chek Guide - Bộ đầy đủ",
                    Price = 1500000,
                    Stock = 20,
                    IsActive = true,
                    ProductId = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Ensure Gold variants
                new ProductVariant
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222227"),
                    VariantName = "Sữa Ensure Gold - Hộp 400g",
                    Price = 280000,
                    Stock = 100,
                    IsActive = true,
                    ProductId = Guid.Parse("22222222-2222-2222-2222-222222222225"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductVariant
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222228"),
                    VariantName = "Sữa Ensure Gold - Hộp 850g",
                    Price = 520000,
                    Stock = 80,
                    IsActive = true,
                    ProductId = Guid.Parse("22222222-2222-2222-2222-222222222225"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Vitamin D3+K2 variants
                new ProductVariant
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222229"),
                    VariantName = "Vitamin D3+K2 - Lọ 60 viên",
                    Price = 180000,
                    Stock = 150,
                    IsActive = true,
                    ProductId = Guid.Parse("22222222-2222-2222-2222-222222222226"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Gậy chống variants
                new ProductVariant
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333338"),
                    VariantName = "Gậy chống 4 chân - Màu đen",
                    Price = 450000,
                    Stock = 40,
                    IsActive = true,
                    ProductId = Guid.Parse("33333333-3333-3333-3333-333333333336"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductVariant
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333339"),
                    VariantName = "Gậy chống 4 chân - Màu xanh",
                    Price = 450000,
                    Stock = 35,
                    IsActive = true,
                    ProductId = Guid.Parse("33333333-3333-3333-3333-333333333336"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Xe lăn variants
                new ProductVariant
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333340"),
                    VariantName = "Xe lăn tay gấp gọn - Màu xanh",
                    Price = 2800000,
                    Stock = 15,
                    IsActive = true,
                    ProductId = Guid.Parse("33333333-3333-3333-3333-333333333337"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Service variants
                new ProductVariant
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444447"),
                    VariantName = "Tư vấn dinh dưỡng - 1 buổi",
                    Price = 500000,
                    Stock = 999,
                    IsActive = true,
                    ProductId = Guid.Parse("44444444-4444-4444-4444-444444444445"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductVariant
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444448"),
                    VariantName = "Tư vấn dinh dưỡng - Gói 5 buổi",
                    Price = 2000000,
                    Stock = 999,
                    IsActive = true,
                    ProductId = Guid.Parse("44444444-4444-4444-4444-444444444445"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.HasData(
                // Tất cả sản phẩm từ Nhà thuốc Độc Lập
                new ProductItem
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111141"),
                    SKU = "OMRON-HEM-7130-WHITE-DL",
                    OriginalPrice = 850000,
                    DiscountedPrice = 800000,
                    Weight = 500,
                    Length = 20,
                    Width = 15,
                    Height = 10,
                    Stock = 25,
                    IsActive = true,
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111131"),
                    StoreId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductItem
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111142"),
                    SKU = "ACCU-CHEK-GUIDE-BASIC-DL",
                    OriginalPrice = 1200000,
                    DiscountedPrice = 1100000,
                    Weight = 300,
                    Length = 15,
                    Width = 10,
                    Height = 5,
                    Stock = 15,
                    IsActive = true,
                    VariantId = Guid.Parse("11111111-1111-1111-1111-111111111133"),
                    StoreId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductItem
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222230"),
                    SKU = "ENSURE-GOLD-400G-DL",
                    OriginalPrice = 280000,
                    DiscountedPrice = 250000,
                    Weight = 400,
                    Length = 12,
                    Width = 8,
                    Height = 6,
                    Stock = 50,
                    IsActive = true,
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222227"),
                    StoreId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductItem
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222231"),
                    SKU = "VITAMIN-D3-K2-60-DL",
                    OriginalPrice = 180000,
                    DiscountedPrice = 160000,
                    Weight = 100,
                    Length = 8,
                    Width = 5,
                    Height = 3,
                    Stock = 75,
                    IsActive = true,
                    VariantId = Guid.Parse("22222222-2222-2222-2222-222222222229"),
                    StoreId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductItem
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333341"),
                    SKU = "GAY-CHONG-4-CHAN-BLACK-DL",
                    OriginalPrice = 450000,
                    DiscountedPrice = 420000,
                    Weight = 800,
                    Length = 120,
                    Width = 5,
                    Height = 5,
                    Stock = 20,
                    IsActive = true,
                    VariantId = Guid.Parse("33333333-3333-3333-3333-333333333338"),
                    StoreId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductItem
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333342"),
                    SKU = "XE-LAN-TAY-XANH-DL",
                    OriginalPrice = 2800000,
                    DiscountedPrice = 2600000,
                    Weight = 15000,
                    Length = 100,
                    Width = 60,
                    Height = 90,
                    Stock = 8,
                    IsActive = true,
                    VariantId = Guid.Parse("33333333-3333-3333-3333-333333333340"),
                    StoreId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.HasData(
                // Product Images
                new ProductImage
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111151"),
                    ImagePath = "/images/products/omron-hem-7130-white-1.jpg",
                    ImageName = "Máy đo huyết áp Omron HEM-7130 - Ảnh 1",
                    ProductItemId = Guid.Parse("11111111-1111-1111-1111-111111111141"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductImage
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111152"),
                    ImagePath = "/images/products/omron-hem-7130-white-2.jpg",
                    ImageName = "Máy đo huyết áp Omron HEM-7130 - Ảnh 2",
                    ProductItemId = Guid.Parse("11111111-1111-1111-1111-111111111141"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductImage
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222232"),
                    ImagePath = "/images/products/ensure-gold-400g-1.jpg",
                    ImageName = "Sữa Ensure Gold 400g - Ảnh 1",
                    ProductItemId = Guid.Parse("22222222-2222-2222-2222-222222222230"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductImage
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333343"),
                    ImagePath = "/images/products/gay-chong-4-chan-black-1.jpg",
                    ImageName = "Gậy chống 4 chân đen - Ảnh 1",
                    ProductItemId = Guid.Parse("33333333-3333-3333-3333-333333333341"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductImage
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333344"),
                    ImagePath = "/images/products/xe-lan-tay-xanh-1.jpg",
                    ImageName = "Xe lăn tay xanh - Ảnh 1",
                    ProductItemId = Guid.Parse("33333333-3333-3333-3333-333333333342"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasData(
                // Medical Devices
                new ProductCategory
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111161"),
                    ProductId = Guid.Parse("11111111-1111-1111-1111-111111111121"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductCategory
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111162"),
                    ProductId = Guid.Parse("11111111-1111-1111-1111-111111111122"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111113"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductCategory
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111163"),
                    ProductId = Guid.Parse("11111111-1111-1111-1111-111111111123"),
                    CategoryId = Guid.Parse("11111111-1111-1111-1111-111111111114"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Nutrition Products
                new ProductCategory
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222233"),
                    ProductId = Guid.Parse("22222222-2222-2222-2222-222222222225"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222223"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductCategory
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222234"),
                    ProductId = Guid.Parse("22222222-2222-2222-2222-222222222226"),
                    CategoryId = Guid.Parse("22222222-2222-2222-2222-222222222224"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Support Tools
                new ProductCategory
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333345"),
                    ProductId = Guid.Parse("33333333-3333-3333-3333-333333333336"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333334"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductCategory
                {
                    Id = Guid.Parse("33333333-3333-3333-3333-333333333346"),
                    ProductId = Guid.Parse("33333333-3333-3333-3333-333333333337"),
                    CategoryId = Guid.Parse("33333333-3333-3333-3333-333333333335"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                // Services
                new ProductCategory
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444449"),
                    ProductId = Guid.Parse("44444444-4444-4444-4444-444444444445"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                },
                new ProductCategory
                {
                    Id = Guid.Parse("44444444-4444-4444-4444-444444444450"),
                    ProductId = Guid.Parse("44444444-4444-4444-4444-444444444446"),
                    CategoryId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    CreationDate = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }
    }
} 