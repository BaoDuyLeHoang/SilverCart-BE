using AutoFixture;
using Bogus;
using Infrastructures;
using Infrastructures.FluentAPIs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Entities.Products;
using SilverCart.Domain.Entities.Stores;
using SilverCart.Domain.Entities.Stocks;
using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Entities.Orders;
using SilverCart.Domain.Entities.Carts;
using SilverCart.Domain.Entities.Payments;
using SilverCart.Domain.Enums;
using SilverCart.Infrastructure.Commons;
using Infrastructures.Commons.Exceptions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAPI.Extensions
{
    public static class SeedDataExtension
    {
        private static readonly Fixture _fixture = new Fixture();
        private static readonly string[] _productAdjectives = new[]
        {
            "Cao cấp", "Thông minh", "Tiện lợi", "Đa năng", "An toàn",
            "Chất lượng", "Bền bỉ", "Dễ sử dụng", "Tiên tiến", "Thoải mái"
        };

        private static readonly string[] _productCategories = new[]
        {
            "Thiết bị y tế", "Dụng cụ hỗ trợ", "Thực phẩm chức năng",
            "Dụng cụ tập luyện", "Thiết bị theo dõi", "Đồ dùng sinh hoạt",
            "Thuốc bổ", "Vitamin", "Dụng cụ massage", "Thiết bị điện tử"
        };

        private static readonly string[] _relationshipTypes = new[]
        {
            "Con trai", "Con gái", "Cháu trai", "Cháu gái", "Anh trai",
            "Em trai", "Chị gái", "Em gái", "Bạn bè", "Khác"
        };

        private static readonly string[] _imagePaths = new[]
        {
            "/images/products/product1.jpg",
            "/images/products/product2.jpg",
            "/images/products/product3.jpg",
            "/images/products/product4.jpg",
            "/images/products/product5.jpg"
        };

        public static async Task SeedDatabaseAsync(this IApplicationBuilder applicationBuilder,
            AppConfiguration configuration)
        {
            using var scope = applicationBuilder.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<AppDbContext>();
            await dbContext.Database.MigrateAsync();

            var _userManager = services.GetRequiredService<UserManager<BaseUser>>();
            await AddSuperAdmin(configuration, _userManager);
            await AddUsers(_userManager, dbContext);
            await AddGuardiansAndDependents(_userManager, dbContext);
            await AddStoreAndProducts(dbContext);
            await AddOrders(dbContext);
        }

        private static async Task AddSuperAdmin(AppConfiguration configuration, UserManager<BaseUser> _userManager)
        {
            if (await _userManager.FindByEmailAsync(configuration.SuperAdmin.Email) == null)
            {
                var superAdmin = new AdministratorUser()
                {
                    UserName = configuration.SuperAdmin.Email,
                    Email = configuration.SuperAdmin.Email,
                    FullName = "Siêu Admin",
                    Gender = "Other",
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(superAdmin, configuration.SuperAdmin.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create super admin user: " +
                                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                await _userManager.AddToRoleAsync(superAdmin, RoleEnum.SuperAdmin.ToString());
            }
        }

        private static async Task AddGuardiansAndDependents(UserManager<BaseUser> _userManager, AppDbContext dbContext)
        {
            const string defaultPassword = "12345678@Yy";

            if (await _userManager.Users.AnyAsync(u => u.Email != null && u.Email.Contains("guardian")))
            {
                return;
            }

            // Get store for staff users
            var store = await dbContext.Stores.FirstOrDefaultAsync();
            AppExceptions.ThrowIfNotFound(store, "Không tìm thấy của hàng");

            // Create 5 Guardians (now inherit from CustomerUser)
            for (int i = 1; i <= 5; i++)
            {
                var guardian = new GuardianUser
                {
                    UserName = $"guardian{i}@example.com",
                    Email = $"guardian{i}@example.com",
                    FullName = $"Người giám hộ {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"0987654{i}21",
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var guardianResult = await _userManager.CreateAsync(guardian, defaultPassword);
                if (guardianResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(guardian, RoleEnum.Guardian.ToString());

                    // Create Wallet for Guardian after user is created
                    guardian.Wallet = new Wallet
                    {
                        UserId = guardian.Id,
                        Balance = 0,
                        Points = 0,
                        TotalSpent = 0,
                        TotalReceived = 0,
                        TotalRefunded = 0
                    };

                    // Create Cart for Guardian (inherited from CustomerUser)
                    var guardianCart = new Cart
                    {
                        UserId = guardian.Id,
                        TotalPrice = 0,
                        IsConsultantUserRecommend = false
                    };
                    dbContext.Carts.Add(guardianCart);
                    await dbContext.SaveChangesAsync();

                    // Create 3-5 Dependents for this Guardian (now inherit from CustomerUser)
                    var dependentCount = Random.Shared.Next(3, 6);
                    for (int j = 1; j <= dependentCount; j++)
                    {
                        var dependent = new DependentUser
                        {
                            UserName = $"dependent{i}_{j}@example.com",
                            Email = $"dependent{i}_{j}@example.com",
                            FullName = $"Người phụ thuộc {j} của {guardian.FullName}",
                            Gender = "Other",
                            EmailConfirmed = true,
                            PhoneNumber = $"0987654{i}{j}2",
                            SecurityStamp = Guid.NewGuid().ToString(),
                            GuardianId = guardian.Id,
                            Guardian = guardian,
                            // New fields for DependentUser (string instead of enum)
                            DateOfBirth = DateTime.UtcNow.AddYears(-Random.Shared.Next(60, 85)),
                            Relationship = _relationshipTypes[Random.Shared.Next(_relationshipTypes.Length)],
                            MedicalNotes = Random.Shared.Next(0, 2) == 1 ? "Cần theo dõi huyết áp thường xuyên" : null,
                            MonthlySpendingLimit = Random.Shared.Next(0, 2) == 1 ? Random.Shared.Next(1000000, 5000000) : null
                        };

                        var dependentResult = await _userManager.CreateAsync(dependent, defaultPassword);
                        if (dependentResult.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(dependent, RoleEnum.DependentUser.ToString());

                            // Create Wallet for Dependent after user is created
                            dependent.Wallet = new Wallet
                            {
                                UserId = dependent.Id,
                                Balance = 0,
                                Points = 0,
                                TotalSpent = 0,
                                TotalReceived = 0,
                                TotalRefunded = 0
                            };

                            // Create Cart for Dependent (inherited from CustomerUser)
                            var dependentCart = new Cart
                            {
                                UserId = dependent.Id,
                                TotalPrice = 0,
                                IsConsultantUserRecommend = false
                            };
                            dbContext.Carts.Add(dependentCart);
                        }
                    }
                }
            }

            // Create 5 Staff Users for the store
            for (int i = 1; i <= 5; i++)
            {
                var staffUser = new StoreUser
                {
                    UserName = $"staff{i}@example.com",
                    Email = $"staff{i}@example.com",
                    FullName = $"Nhân viên cửa hàng {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"0987654{i}30",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Store = store,
                    StoreUserRoles = new HashSet<StoreUserRole>()
                };

                var staffResult = await _userManager.CreateAsync(staffUser, defaultPassword);
                if (staffResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(staffUser, RoleEnum.Staff.ToString());
                }
            }

            await dbContext.SaveChangesAsync();
        }

        private static async Task AddUsers(UserManager<BaseUser> _userManager, AppDbContext dbContext)
        {
            const string defaultPassword = "12345678@Yy";

            // Check if users already exist
            if (await _userManager.Users.AnyAsync(u => u.Email != null && u.Email.Contains("test")))
            {
                await AddRoleToUnknownUser(_userManager);
                return; // Skip if test users already exist
            }

            var store = await dbContext.Stores.FirstOrDefaultAsync();
            AppExceptions.ThrowIfNotFound(store, "Store not found");

            // Create 5 Administrators
            for (int i = 1; i <= 5; i++)
            {
                var admin = new AdministratorUser
                {
                    UserName = $"testadmin{i}@example.com",
                    Email = $"testadmin{i}@example.com",
                    FullName = $"Test Admin {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"01234567{i}0",
                };
                var result = await _userManager.CreateAsync(admin, defaultPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, RoleEnum.Admin.ToString());
                }
            }

            // Create 5 Store Owners
            for (int i = 1; i <= 5; i++)
            {
                var storeOwner = new StoreUser
                {
                    UserName = $"teststoreowner{i}@example.com",
                    Email = $"teststoreowner{i}@example.com",
                    FullName = $"Test Store Owner {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"01234567{i}1",
                    Store = store,
                    StoreUserRoles = new HashSet<StoreUserRole>()
                };
                var result = await _userManager.CreateAsync(storeOwner, defaultPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(storeOwner, RoleEnum.ShopOwner.ToString());
                }
            }

            // Create 10 Staff Users
            for (int i = 1; i <= 10; i++)
            {
                var staffUser = new StoreUser
                {
                    UserName = $"teststaff{i}@example.com",
                    Email = $"teststaff{i}@example.com",
                    FullName = $"Test Staff {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"01234567{i}2",
                    Store = store,
                    StoreUserRoles = new HashSet<StoreUserRole>()
                };
                var result = await _userManager.CreateAsync(staffUser, defaultPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(staffUser, RoleEnum.Staff.ToString());
                }
            }

            // Create 5 Consultants (removed ConsultantRole references)
            for (int i = 1; i <= 5; i++)
            {
                var consultant = new ConsultantUser
                {
                    UserName = $"testconsultant{i}@example.com",
                    Email = $"testconsultant{i}@example.com",
                    FullName = $"Test Consultant {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"01234567{i}2",
                    Specialization = "Sức khỏe người cao tuổi",
                    Biography = $"Chuyên gia tư vấn sức khỏe cho người cao tuổi {i}",
                    AvatarPath = "/images/avatars/default.jpg",
                    ExpertiseArea = "Chăm sóc sức khỏe",
                };
                var result = await _userManager.CreateAsync(consultant, defaultPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(consultant, RoleEnum.Consultant.ToString());
                }
            }

            // Create 5 Guardians with their Dependents (now inherit from CustomerUser)
            for (int i = 1; i <= 5; i++)
            {
                var guardian = new GuardianUser
                {
                    UserName = $"testguardian{i}@example.com",
                    Email = $"testguardian{i}@example.com",
                    FullName = $"Test Guardian {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"01234567{i}3"
                };
                var guardianResult = await _userManager.CreateAsync(guardian, defaultPassword);
                if (guardianResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(guardian, RoleEnum.Guardian.ToString());

                    // Create Wallet for Guardian after user is created
                    guardian.Wallet = new Wallet
                    {
                        UserId = guardian.Id,
                        Balance = 0,
                        Points = 0,
                        TotalSpent = 0,
                        TotalReceived = 0,
                        TotalRefunded = 0
                    };

                    // Create Cart for Guardian (inherited from CustomerUser)
                    var guardianCart = new Cart
                    {
                        UserId = guardian.Id,
                        TotalPrice = 0,
                        IsConsultantUserRecommend = false
                    };
                    dbContext.Carts.Add(guardianCart);
                }

                // Create Dependent for each Guardian (now inherit from CustomerUser)
                var dependent = new DependentUser
                {
                    UserName = $"testdependent{i}@example.com",
                    Email = $"testdependent{i}@example.com",
                    FullName = $"Test Dependent {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"01234567{i}4",
                    Guardian = guardian,
                    // New fields for DependentUser (string instead of enum)
                    DateOfBirth = DateTime.UtcNow.AddYears(-Random.Shared.Next(60, 85)),
                    Relationship = _relationshipTypes[Random.Shared.Next(_relationshipTypes.Length)],
                    MedicalNotes = Random.Shared.Next(0, 2) == 1 ? "Cần theo dõi đường huyết thường xuyên" : null,
                    MonthlySpendingLimit = Random.Shared.Next(0, 2) == 1 ? Random.Shared.Next(1000000, 3000000) : null
                };
                var dependentResult = await _userManager.CreateAsync(dependent, defaultPassword);
                if (dependentResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(dependent, RoleEnum.DependentUser.ToString());

                    // Create Wallet for Dependent after user is created
                    dependent.Wallet = new Wallet
                    {
                        UserId = dependent.Id,
                        Balance = 0,
                        Points = 0,
                        TotalSpent = 0,
                        TotalReceived = 0,
                        TotalRefunded = 0
                    };

                    // Create Cart for Dependent (inherited from CustomerUser)
                    var dependentCart = new Cart
                    {
                        UserId = dependent.Id,
                        TotalPrice = 0,
                        IsConsultantUserRecommend = false
                    };
                    dbContext.Carts.Add(dependentCart);
                }
            }

            // Create 5 Customers (now using DependentUser which inherits from CustomerUser)
            for (int i = 1; i <= 5; i++)
            {
                var customer = new DependentUser
                {
                    UserName = $"testcustomer{i}@example.com",
                    Email = $"testcustomer{i}@example.com",
                    FullName = $"Test Customer {i}",
                    Gender = "Other",
                    EmailConfirmed = true,
                    PhoneNumber = $"01234567{i}5",
                    // New fields for DependentUser (string instead of enum)
                    DateOfBirth = DateTime.UtcNow.AddYears(-Random.Shared.Next(60, 85)),
                    Relationship = _relationshipTypes[Random.Shared.Next(_relationshipTypes.Length)],
                    MedicalNotes = Random.Shared.Next(0, 2) == 1 ? "Cần theo dõi sức khỏe thường xuyên" : null,
                    MonthlySpendingLimit = Random.Shared.Next(0, 2) == 1 ? Random.Shared.Next(1000000, 4000000) : null
                };
                var result = await _userManager.CreateAsync(customer, defaultPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(customer, RoleEnum.DependentUser.ToString());

                    // Create Wallet for Customer after user is created
                    customer.Wallet = new Wallet
                    {
                        UserId = customer.Id,
                        Balance = 0,
                        Points = 0,
                        TotalSpent = 0,
                        TotalReceived = 0,
                        TotalRefunded = 0
                    };

                    // Create Cart for Customer (inherited from CustomerUser)
                    var customerCart = new Cart
                    {
                        UserId = customer.Id,
                        TotalPrice = 0,
                        IsConsultantUserRecommend = false
                    };
                    dbContext.Carts.Add(customerCart);
                }
            }

            await dbContext.SaveChangesAsync();
        }

        private static async Task AddStoreAndProducts(AppDbContext dbContext)
        {
            if (await dbContext.Products.AnyAsync())
            {
                return;
            }

            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                // Create store faker
                var store = await dbContext.Stores.FirstOrDefaultAsync();
                AppExceptions.ThrowIfNotFound(store, "Store not found");

                // Create categories
                var categories = _productCategories.Select(name => new Category
                {
                    Name = name,
                    Description = $"Danh mục {name} dành cho người cao tuổi",
                    Status = CategoryStatusEnum.Active,
                    ImageUrl = _imagePaths[Random.Shared.Next(_imagePaths.Length)]
                }).ToList();
                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();

                // Create customers for reviews (now using DependentUser which inherits from CustomerUser)
                var customerFaker = new Faker<DependentUser>("vi")
                    .RuleFor(c => c.Id, f => Guid.NewGuid())
                    .RuleFor(c => c.UserName, f => f.Internet.UserName())
                    .RuleFor(c => c.Email, f => f.Internet.Email())
                    .RuleFor(c => c.FullName, f => f.Name.FullName())
                    .RuleFor(c => c.Gender, f => f.PickRandom(new[] { "Nam", "Nữ", "Khác" }))
                    .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber("0#########"))
                    .RuleFor(c => c.EmailConfirmed, f => true)
                    .RuleFor(c => c.DateOfBirth, f => f.Date.Past(85, DateTime.UtcNow.AddYears(-60)))
                    .RuleFor(c => c.Relationship, f => f.PickRandom(_relationshipTypes))
                    .RuleFor(c => c.MedicalNotes, f => f.Random.Bool() ? f.Lorem.Sentence() : null)
                    .RuleFor(c => c.MonthlySpendingLimit, f => f.Random.Bool() ? f.Random.Decimal(1000000, 5000000) : null);

                var customers = customerFaker.Generate(10);
                dbContext.DependentUsers.AddRange(customers);
                await dbContext.SaveChangesAsync();

                // Create wallets for customers after they are saved
                foreach (var customer in customers)
                {
                    customer.Wallet = new Wallet
                    {
                        UserId = customer.Id, // Set the correct UserId
                        Balance = 0,
                        Points = 0,
                        TotalSpent = 0,
                        TotalReceived = 0,
                        TotalRefunded = 0
                    };
                }
                await dbContext.SaveChangesAsync();

                // Create real products
                var realProducts = new[]
                {
                    new {
                        Name = "Máy đo huyết áp Omron HEM-7120",
                        Desc = "Máy đo huyết áp tự động, dễ sử dụng, độ chính xác cao",
                        Type = ProductTypeEnum.Physical,
                        Reviews = new[] {
                            "Sản phẩm rất dễ sử dụng, phù hợp với người cao tuổi",
                            "Đo chính xác, màn hình hiển thị rõ ràng",
                            "Giá cả hợp lý, chất lượng tốt",
                            "Rất hài lòng với sản phẩm này",
                            "Đóng gói cẩn thận, hướng dẫn sử dụng chi tiết"
                        }
                    },
                    new {
                        Name = "Máy đo đường huyết Accu-Chek",
                        Desc = "Máy đo đường huyết cầm tay, kết quả nhanh trong 5 giây",
                        Type = ProductTypeEnum.Physical,
                        Reviews = new[] {
                            "Đo nhanh và chính xác",
                            "Thiết kế nhỏ gọn, dễ mang theo",
                            "Que thử dễ sử dụng",
                            "Rất tiện lợi cho việc theo dõi đường huyết",
                            "Màn hình hiển thị rõ ràng, dễ đọc"
                        }
                    },
                    new {
                        Name = "Gậy chống thông minh",
                        Desc = "Gậy chống có đèn LED, chống trượt, có chuông báo động",
                        Type = ProductTypeEnum.Physical,
                        Reviews = new[] {
                            "Đèn LED rất hữu ích khi đi trong bóng tối",
                            "Chuông báo động giúp gọi người nhà khi cần",
                            "Chống trượt tốt, an toàn khi sử dụng",
                            "Tay cầm êm ái, dễ chịu",
                            "Thiết kế thông minh, nhiều tính năng hữu ích"
                        }
                    },
                    new {
                        Name = "Ghế massage toàn thân",
                        Desc = "Ghế massage đa năng với nhiều chế độ massage khác nhau",
                        Type = ProductTypeEnum.Physical,
                        Reviews = new[] {
                            "Massage rất êm dịu, phù hợp với người cao tuổi",
                            "Nhiều chế độ massage để lựa chọn",
                            "Chất lượng tốt, đáng giá tiền",
                            "Giảm đau nhức hiệu quả",
                            "Điều khiển dễ dàng, không phức tạp"
                        }
                    },
                    new {
                        Name = "Thực phẩm bổ sung Calcium",
                        Desc = "Viên uống bổ sung canxi, vitamin D3 cho người cao tuổi",
                        Type = ProductTypeEnum.Consumable,
                        Reviews = new[] {
                            "Viên uống dễ nuốt",
                            "Không có tác dụng phụ",
                            "Cảm thấy xương khớp khỏe hơn",
                            "Giá cả phải chăng",
                            "Đóng gói kỹ càng, bảo quản tốt"
                        }
                    }
                };

                // Create product faker for elderly care items
                var productItemFaker = new Faker<ProductItem>("vi")
                    .RuleFor(pi => pi.ProductName, (f, pi) => f.Random.Replace("Product-####-####"))
                    .RuleFor(pi => pi.OriginalPrice, f => f.Random.Decimal(100000, 10000000))
                    .RuleFor(pi => pi.Weight, f => f.Random.Int(100, 5000))
                    .RuleFor(pi => pi.Length, f => f.Random.Int(10, 100))
                    .RuleFor(pi => pi.Width, f => f.Random.Int(10, 100))
                    .RuleFor(pi => pi.Height, f => f.Random.Int(10, 100))
                    .RuleFor(pi => pi.IsActive, f => true)
                    .RuleFor(pi => pi.Stock, f => new Stock
                    {
                        Quantity = f.Random.Int(10, 50),
                        ReservedQuantity = 0,
                        AvailableQuantity = f.Random.Int(10, 50),
                        SoldQuantity = 0,
                        ReturnedQuantity = 0,
                        DamagedQuantity = 0
                    });

                // Add real products with variants
                foreach (var productInfo in realProducts)
                {
                    var product = new Product
                    {
                        Name = productInfo.Name,
                        Description = productInfo.Desc,
                        VideoPath = "",
                        ProductType = productInfo.Type,
                        StoreId = store.Id,
                        IsActive = true
                    };

                    // Add product to random categories (1-2 categories)
                    var categoryCount = Random.Shared.Next(1, 3);
                    var selectedCategories = categories
                        .OrderBy(x => Random.Shared.Next())
                        .Take(categoryCount);

                    foreach (var category in selectedCategories)
                    {
                        product.ProductCategories.Add(new ProductCategory
                        {
                            CategoryId = category.Id,
                            ProductId = product.Id
                        });
                    }

                    // Add 2-4 product images
                    var imageCount = Random.Shared.Next(2, 5);
                    for (int i = 0; i < imageCount; i++)
                    {
                        var imagePath = _imagePaths[Random.Shared.Next(_imagePaths.Length)];
                        product.ProductImages.Add(new ProductImage
                        {
                            ImagePath = imagePath,
                            ImageName = $"Product_{product.Name}_{i + 1}",
                            IsMain = i == 0,
                            Order = i
                        });
                    }

                    // Add 2-3 items
                    var itemCount = Random.Shared.Next(2, 4);
                    for (int v = 0; v < itemCount; v++)
                    {
                        // Create item
                        var item = productItemFaker.Generate();
                        var priceMultiplier = 1 + (v * 0.2m); // Tăng giá 20% cho mỗi cấp độ
                        item.OriginalPrice *= priceMultiplier;
                        item.DiscountedPrice = item.OriginalPrice * 0.9m;
                        item.ProductId = product.Id;

                        // Add 1-3 images for each item
                        var itemImageCount = Random.Shared.Next(1, 4);
                        for (int i = 0; i < itemImageCount; i++)
                        {
                            var imagePath = _imagePaths[Random.Shared.Next(_imagePaths.Length)];
                            var productImage = new ProductImage
                            {
                                ImagePath = imagePath,
                                ImageName = $"Item_{i + 1}",
                                IsMain = i == 0,
                                Order = i,
                                ProductItemId = item.Id
                            };
                            item.ProductImages.Add(productImage);
                        }

                        // Create stock history
                        var stockHistoryCount = Random.Shared.Next(1, 4);
                        var currentStock = item.Stock.Quantity;
                        for (int h = 0; h < stockHistoryCount; h++)
                        {
                            var quantityChange = Random.Shared.Next(-10, 20);
                            currentStock += quantityChange;
                            item.StockHistories.Add(new StockHistory
                            {
                                ProductItemId = item.Id,
                                Date = DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 30)),
                                QuantityChange = quantityChange,
                                StockAfterChange = currentStock,
                                Reason = quantityChange > 0 ? "Nhập hàng" : "Xuất hàng"
                            });
                        }

                        product.ProductItems.Add(item);
                    }

                    // Add reviews for real products
                    var reviewCustomers = customers.OrderBy(x => Random.Shared.Next()).Take(5).ToList();
                    for (int r = 0; r < 5; r++)
                    {
                        product.ProductReviews.Add(new ProductReview
                        {
                            ReviewText = productInfo.Reviews[r],
                            Rating = Random.Shared.Next(4, 6), // 4-5 sao cho sản phẩm thật
                            ProductId = product.Id,
                            CustomerId = reviewCustomers[r].Id
                        });
                    }

                    dbContext.Products.Add(product);
                }

                // Create fake products
                var productFaker = new Faker<Product>("vi")
                    .RuleFor(p => p.Name, f => $"{f.Commerce.ProductName()} {f.PickRandom(_productAdjectives)}")
                    .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                    .RuleFor(p => p.VideoPath, f => "")
                    .RuleFor(p => p.ProductType, f => f.PickRandom<ProductTypeEnum>())
                    .RuleFor(p => p.StoreId, f => store.Id)
                    .RuleFor(p => p.IsActive, f => true);

                // Generate 25 fake products
                var fakeProducts = productFaker.Generate(25);
                foreach (var product in fakeProducts)
                {
                    // Add product to random categories (1-2 categories)
                    var categoryCount = Random.Shared.Next(1, 3);
                    var selectedCategories = categories
                        .OrderBy(x => Random.Shared.Next())
                        .Take(categoryCount);

                    foreach (var category in selectedCategories)
                    {
                        product.ProductCategories.Add(new ProductCategory
                        {
                            CategoryId = category.Id,
                            ProductId = product.Id
                        });
                    }

                    // Add 2-4 product images
                    var imageCount = Random.Shared.Next(2, 5);
                    for (int i = 0; i < imageCount; i++)
                    {
                        var imagePath = _imagePaths[Random.Shared.Next(_imagePaths.Length)];
                        product.ProductImages.Add(new ProductImage
                        {
                            ImagePath = imagePath,
                            ImageName = $"Product_{product.Name}_{i + 1}",
                            IsMain = i == 0,
                            Order = i
                        });
                    }

                    // Add 2-3 items
                    var itemCount = Random.Shared.Next(2, 4);
                    for (int v = 0; v < itemCount; v++)
                    {
                        // Create item
                        var item = productItemFaker.Generate();
                        var priceMultiplier = 1 + (v * 0.2m);
                        item.OriginalPrice *= priceMultiplier;
                        item.DiscountedPrice = item.OriginalPrice * 0.95m;
                        item.ProductId = product.Id;

                        // Add 1-3 images for each item
                        var itemImageCount = Random.Shared.Next(1, 4);
                        for (int i = 0; i < itemImageCount; i++)
                        {
                            var imagePath = _imagePaths[Random.Shared.Next(_imagePaths.Length)];
                            var productImage = new ProductImage
                            {
                                ImagePath = imagePath,
                                ImageName = $"Item_{i + 1}",
                                IsMain = i == 0,
                                Order = i,
                                ProductItemId = item.Id
                            };
                            item.ProductImages.Add(productImage);
                        }

                        // Create stock history
                        var stockHistoryCount = Random.Shared.Next(1, 4);
                        var currentStock = item.Stock.Quantity;
                        for (int h = 0; h < stockHistoryCount; h++)
                        {
                            var quantityChange = Random.Shared.Next(-10, 20);
                            currentStock += quantityChange;
                            item.StockHistories.Add(new StockHistory
                            {
                                ProductItemId = item.Id,
                                Date = DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 30)),
                                QuantityChange = quantityChange,
                                StockAfterChange = currentStock,
                                Reason = quantityChange > 0 ? "Nhập hàng" : "Xuất hàng"
                            });
                        }

                        product.ProductItems.Add(item);
                    }

                    // Add random reviews (0-3 reviews)
                    var reviewCount = Random.Shared.Next(0, 4);
                    if (reviewCount > 0)
                    {
                        var reviewCustomers = customers.OrderBy(x => Random.Shared.Next()).Take(reviewCount).ToList();
                        for (int r = 0; r < reviewCount; r++)
                        {
                            product.ProductReviews.Add(new ProductReview
                            {
                                ReviewText = new Faker("vi").Lorem.Sentence(),
                                Rating = Random.Shared.Next(3, 6), // 3-5 sao cho sản phẩm mẫu
                                ProductId = product.Id,
                                CustomerId = reviewCustomers[r].Id
                            });
                        }
                    }

                    dbContext.Products.Add(product);
                }

                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static async Task AddOrders(AppDbContext dbContext)
        {
            if (await dbContext.Orders.AnyAsync())
            {
                return;
            }

            using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                // Get all users that inherit from CustomerUser (DependentUser, GuardianUser)
                var dependents = await dbContext.DependentUsers.ToListAsync();
                var guardians = await dbContext.GuardianUsers.ToListAsync();
                var allCustomerUsers = dependents.Concat<CustomerUser>(guardians).ToList();

                var products = await dbContext.Products
                    .Include(p => p.ProductItems)
                    .ToListAsync();

                var realProducts = products.Take(5).ToList(); // 5 sản phẩm thật đầu tiên
                var fakeProducts = products.Skip(5).ToList(); // Các sản phẩm còn lại

                // Tạo 5 đơn hàng thật
                var realOrders = new List<Order>();
                foreach (var customer in allCustomerUsers.Take(5))
                {
                    var order = new Order
                    {
                        OrderedUserId = customer.Id,
                        OrderedUser = customer,
                        OrderStatus = OrderStatusEnum.Completed,
                        FromAddress = "123 Đường Lê Lợi, Phường Bến Nghé, Quận 1, TP.HCM",
                        ToAddress = "123 Đường Lê Văn Việt, Phường 1, Quận 1, TP.HCM",
                        OrderNote = "Đơn hàng thật",
                        EarnedPoints = 100,
                        UsedPoints = 0,
                        ConfirmedAt = DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 30)),
                        PaymentStatus = new OrderPaymentStatus
                        {
                            PaymentMethod = PaymentMethodEnum.BankTransfer,
                            PaymentStatus = PaymentStatusEnum.Paid,
                            PaymentDate = DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 30))
                        },
                        ShippingStatus = new OrderShippingStatus
                        {
                            Status = ShippingStatusEnum.Completed,
                            TrackingCode = $"GHN{Random.Shared.Next(100000, 999999)}",
                            ShipSource = "GHN",
                            TrackingTime = DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 30))
                        }
                    };

                    // Thêm 2-3 sản phẩm vào đơn hàng
                    var orderProducts = realProducts.OrderBy(x => Random.Shared.Next()).Take(Random.Shared.Next(2, 4)).ToList();
                    decimal totalPrice = 0;

                    foreach (var product in orderProducts)
                    {
                        var item = product.ProductItems.First();
                        var quantity = Random.Shared.Next(1, 4);
                        var price = item.DiscountedPrice;
                        totalPrice += price * quantity;

                        var orderDetail = new OrderDetails
                        {
                            OrderId = order.Id,
                            Order = order,
                            ProductItemId = item.Id,
                            ProductItem = item,
                            OrderItemStatus = OrderItemStatusEnums.Delivered,
                            Quantity = quantity,
                            Price = price,
                            Weight = item.Weight,
                            Length = item.Length,
                            Width = item.Width,
                            Height = item.Height,
                            Notes = "Đã giao thành công"
                        };

                        order.OrderDetails.Add(orderDetail);
                    }

                    order.TotalPrice = totalPrice;
                    order.FinalPrice = totalPrice * 0.95m; // Giảm giá 5%
                    realOrders.Add(order);
                }

                dbContext.Orders.AddRange(realOrders);
                await dbContext.SaveChangesAsync();

                // Tạo 100 đơn hàng mẫu
                var fakeOrders = new List<Order>();
                var orderStatuses = new[]
                {
                    OrderStatusEnum.Pending,
                    OrderStatusEnum.GuardianConfirmed,
                    OrderStatusEnum.StoreConfirmed,
                    OrderStatusEnum.Processing,
                    OrderStatusEnum.Shipping,
                    OrderStatusEnum.Completed,
                    OrderStatusEnum.Cancelled
                };

                for (int i = 0; i < 100; i++)
                {
                    var customer = allCustomerUsers[Random.Shared.Next(allCustomerUsers.Count)];
                    var orderStatus = orderStatuses[Random.Shared.Next(orderStatuses.Length)];

                    var order = new Order
                    {
                        OrderedUserId = customer.Id,
                        OrderedUser = customer,
                        OrderStatus = orderStatus,
                        FromAddress = $"{Random.Shared.Next(1, 999)} Đường {new Faker().Address.StreetName()}, {new Faker().Address.City()}",
                        ToAddress = $"{Random.Shared.Next(1, 999)} Đường {new Faker().Address.StreetName()}, {new Faker().Address.City()}",
                        OrderNote = new Faker("vi").Lorem.Sentence(),
                        EarnedPoints = Random.Shared.Next(10, 200),
                        UsedPoints = Random.Shared.Next(0, 100),
                        ConfirmedAt = orderStatus != OrderStatusEnum.Pending ? DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 60)) : null,
                        CancelledAt = orderStatus == OrderStatusEnum.Cancelled ? DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 60)) : null,
                        PaymentStatus = new OrderPaymentStatus
                        {
                            PaymentMethod = (PaymentMethodEnum)Random.Shared.Next(0, 3),
                            PaymentStatus = orderStatus == OrderStatusEnum.Cancelled ? PaymentStatusEnum.Cancelled :
                                          orderStatus == OrderStatusEnum.Completed ? PaymentStatusEnum.Paid :
                                          PaymentStatusEnum.Pending,
                            PaymentDate = orderStatus == OrderStatusEnum.Completed ? DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 60)) : DateTime.UtcNow
                        },
                        ShippingStatus = new OrderShippingStatus
                        {
                            Status = orderStatus == OrderStatusEnum.Cancelled ? ShippingStatusEnum.Cancelled :
                                    orderStatus == OrderStatusEnum.Completed ? ShippingStatusEnum.Completed :
                                    orderStatus == OrderStatusEnum.Shipping ? ShippingStatusEnum.Shipping :
                                    ShippingStatusEnum.Pending,
                            TrackingCode = orderStatus >= OrderStatusEnum.Shipping ? $"GHN{Random.Shared.Next(100000, 999999)}" : null,
                            ShipSource = "GHN",
                            TrackingTime = orderStatus >= OrderStatusEnum.Shipping ? DateTime.UtcNow.AddDays(-Random.Shared.Next(1, 60)) : null
                        }
                    };

                    // Thêm 1-5 sản phẩm vào đơn hàng
                    var orderProducts = fakeProducts.OrderBy(x => Random.Shared.Next()).Take(Random.Shared.Next(1, 6)).ToList();
                    decimal totalPrice = 0;

                    foreach (var product in orderProducts)
                    {
                        var item = product.ProductItems.OrderBy(x => Random.Shared.Next()).First();
                        var quantity = Random.Shared.Next(1, 6);
                        var price = item.DiscountedPrice;
                        totalPrice += price * quantity;

                        var orderDetail = new OrderDetails
                        {
                            OrderId = order.Id,
                            Order = order,
                            ProductItemId = item.Id,
                            ProductItem = item,
                            OrderItemStatus = orderStatus == OrderStatusEnum.Cancelled ? OrderItemStatusEnums.Cancelled :
                                            orderStatus == OrderStatusEnum.Completed ? OrderItemStatusEnums.Delivered :
                                            orderStatus == OrderStatusEnum.Shipping ? OrderItemStatusEnums.Shipping :
                                            OrderItemStatusEnums.Pending,
                            Quantity = quantity,
                            Price = price,
                            Weight = item.Weight,
                            Length = item.Length,
                            Width = item.Width,
                            Height = item.Height,
                            Notes = orderStatus == OrderStatusEnum.Cancelled ? "Đã hủy" :
                                   orderStatus == OrderStatusEnum.Completed ? "Đã giao thành công" :
                                   orderStatus == OrderStatusEnum.Shipping ? "Đang giao hàng" :
                                   "Đang xử lý"
                        };

                        order.OrderDetails.Add(orderDetail);
                    }

                    order.TotalPrice = totalPrice;
                    // Áp dụng giảm giá ngẫu nhiên 0-10%
                    var discount = Random.Shared.Next(0, 11) / 100m;
                    order.FinalPrice = totalPrice * (1 - discount);
                    fakeOrders.Add(order);
                }

                dbContext.Orders.AddRange(fakeOrders);
                await dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private static async Task AddRoleToUnknownUser(UserManager<BaseUser> _userManager)
        {
            var users = await _userManager.Users
                .Where(u => u.SecurityStamp != null)
                .ToListAsync();

            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Count == 0)
                    {
                        // Set security stamp if not set
                        if (string.IsNullOrEmpty(user.SecurityStamp))
                        {
                            user.SecurityStamp = Guid.NewGuid().ToString();
                            await _userManager.UpdateAsync(user);
                        }

                        await _userManager.AddToRoleAsync(user, RoleEnum.DependentUser.ToString());
                    }
                }
            }
        }
    }
}