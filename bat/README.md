# EF Core Batch Scripts - Hướng Dẫn Sử Dụng

Các script .bat này giúp bạn quản lý Entity Framework Core migrations một cách dễ dàng với hỗ trợ tham số từ command line.

## 📋 Danh Sách Scripts

### 1. `add-migration.bat` - Tạo Migration Mới

**Cách sử dụng:**
```bash
# Cách 1: Nhập tên migration khi được hỏi
add-migration.bat

# Cách 2: Truyền tên migration trực tiếp
add-migration.bat "AddProductImages"
add-migration.bat AddProductImages
```

**Ví dụ:**
```bash
add-migration.bat "AddMultipleProductImages"
```

### 2. `update-db.bat` - Cập Nhật Database

**Cách sử dụng:**
```bash
# Cách 1: Cập nhật đến migration mới nhất
update-db.bat

# Cách 2: Cập nhật đến migration cụ thể
update-db.bat "20241201000000_AddProductImages"
```

**Ví dụ:**
```bash
# Cập nhật đến migration mới nhất
update-db.bat

# Cập nhật đến migration cụ thể
update-db.bat "20241201000000_Initial"
```

### 3. `reset-db.bat` - Reset Database

**Cách sử dụng:**
```bash
# Cách 1: Reset với xác nhận
reset-db.bat

# Cách 2: Reset không cần xác nhận (force)
reset-db.bat /force
```

**Ví dụ:**
```bash
# Reset với xác nhận
reset-db.bat

# Reset force (không hỏi xác nhận)
reset-db.bat /force
```

### 4. `script-migrations.bat` - Tạo SQL Script

**Cách sử dụng:**
```bash
# Cách 1: Tạo script cho tất cả migrations
script-migrations.bat

# Cách 2: Tạo script với tên file tùy chỉnh
script-migrations.bat "my-migration.sql"

# Cách 3: Tạo script từ migration A đến migration B
script-migrations.bat "output.sql" "20241201000000_Initial" "20241202000000_AddProducts"
```

**Ví dụ:**
```bash
# Tạo script mặc định
script-migrations.bat

# Tạo script với tên file tùy chỉnh
script-migrations.bat "deployment-script.sql"

# Tạo script từ migration cụ thể
script-migrations.bat "partial-update.sql" "20241201000000_Initial" "20241202000000_AddProducts"
```

### 5. `remove-last-migration.bat` - Xóa Migration

**Cách sử dụng:**
```bash
# Cách 1: Xóa migration cuối cùng
remove-last-migration.bat

# Cách 2: Xóa nhiều migration cuối cùng
remove-last-migration.bat 3
```

**Ví dụ:**
```bash
# Xóa 1 migration cuối cùng
remove-last-migration.bat

# Xóa 3 migration cuối cùng
remove-last-migration.bat 3
```

### 6. `list-migrations.bat` - Liệt Kê Migrations

**Cách sử dụng:**
```bash
# Cách 1: Liệt kê migrations cơ bản
list-migrations.bat

# Cách 2: Liệt kê với thông tin chi tiết
list-migrations.bat /v
```

**Ví dụ:**
```bash
# Xem danh sách migrations
list-migrations.bat

# Xem chi tiết migrations
list-migrations.bat /v
```

### 7. `db-status.bat` - Kiểm Tra Trạng Thái Database

**Cách sử dụng:**
```bash
# Cách 1: Kiểm tra trạng thái cơ bản
db-status.bat

# Cách 2: Kiểm tra trạng thái chi tiết
db-status.bat /d
```

**Ví dụ:**
```bash
# Kiểm tra trạng thái database
db-status.bat

# Kiểm tra chi tiết và pending migrations
db-status.bat /d
```

## 🚀 Workflow Thường Dùng

### 1. Tạo Migration Mới
```bash
add-migration.bat "AddProductImages"
```

### 2. Kiểm Tra Migration
```bash
# Xem danh sách migrations
dotnet ef migrations list --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI
```

### 3. Cập Nhật Database
```bash
update-db.bat
```

### 4. Nếu Cần Rollback
```bash
# Xóa migration cuối cùng
remove-last-migration.bat

# Hoặc xóa nhiều migration
remove-last-migration.bat 2
```

### 5. Reset Hoàn Toàn (Cẩn Thận!)
```bash
reset-db.bat /force
```

## ⚠️ Lưu Ý Quan Trọng

### 1. **Backup Database**
- Luôn backup database trước khi thực hiện các thao tác migration
- Đặc biệt cẩn thận với `reset-db.bat`

### 2. **Kiểm Tra Migration**
- Luôn kiểm tra migration được tạo ra trước khi apply
- Sử dụng `script-migrations.bat` để xem SQL sẽ được thực thi

### 3. **Môi Trường**
- Chỉ chạy migrations trên môi trường development
- Sử dụng deployment scripts cho production

### 4. **Error Handling**
- Các script đã được cải thiện với error handling
- Kiểm tra exit code để biết thành công hay thất bại

## 🔧 Troubleshooting

### Migration Name Có Khoảng Trắng
```bash
# Sử dụng dấu ngoặc kép
add-migration.bat "Add Product Images"
```

### Database Connection Error
```bash
# Kiểm tra connection string trong appsettings.json
# Đảm bảo database server đang chạy
```

### Migration Conflict
```bash
# Xóa migration cuối cùng
remove-last-migration.bat

# Tạo lại migration
add-migration.bat "NewMigrationName"
```

## 📝 Ví Dụ Thực Tế

### Scenario 1: Thêm Tính Năng Mới
```bash
# 1. Tạo migration
add-migration.bat "AddUserProfile"

# 2. Kiểm tra migration
dotnet ef migrations list --project ./Apis/SilverCart.Infrastructure --startup-project ./Apis/SilverCart.WebAPI

# 3. Tạo script để review
script-migrations.bat "review-script.sql"

# 4. Apply migration
update-db.bat
```

### Scenario 2: Fix Migration Lỗi
```bash
# 1. Xóa migration lỗi
remove-last-migration.bat

# 2. Tạo lại migration
add-migration.bat "AddUserProfileFixed"

# 3. Apply migration
update-db.bat
```

### Scenario 3: Deploy to Production
```bash
# 1. Tạo deployment script
script-migrations.bat "production-deploy.sql" "20241201000000_Current" "20241202000000_NewFeature"

# 2. Review script trước khi deploy
# 3. Chạy script trên production database
```

## 🎯 Tips & Best Practices

1. **Đặt tên migration rõ ràng**: `AddProductImages`, `UpdateUserTable`, `FixOrderStatus`
2. **Commit migration files**: Luôn commit migration files vào source control
3. **Test migrations**: Test migrations trên database test trước khi apply production
4. **Backup thường xuyên**: Backup database trước mỗi migration
5. **Review SQL**: Sử dụng `script-migrations.bat` để review SQL trước khi apply 