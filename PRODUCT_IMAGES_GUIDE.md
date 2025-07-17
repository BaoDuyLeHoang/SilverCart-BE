# Hướng Dẫn Quản Lý Hình Ảnh Sản Phẩm

## Tổng Quan
Hệ thống đã được cập nhật để hỗ trợ nhiều hình ảnh cho mỗi sản phẩm. Mỗi ProductItem có thể có nhiều hình ảnh với các mục đích khác nhau.

## Cấu Trúc Dữ Liệu

### ProductImage Entity
```csharp
public class ProductImage
{
    public Guid Id { get; set; }
    public string ImagePath { get; set; }        // Đường dẫn đến file hình ảnh
    public string ImageName { get; set; }        // Tên mô tả hình ảnh
    public Guid ProductItemId { get; set; }      // Liên kết với ProductItem
    public DateTime CreationDate { get; set; }
    public bool IsDeleted { get; set; }
}
```

## Các Loại Hình Ảnh Được Hỗ Trợ

### 1. Hình Ảnh Chính (Main Image)
- **Mục đích**: Hình ảnh đại diện chính của sản phẩm
- **Ví dụ**: `"Máy đo huyết áp Omron HEM-7130 - Ảnh chính"`

### 2. Hình Ảnh Chi Tiết (Detail Images)
- **Mục đích**: Hiển thị các chi tiết quan trọng của sản phẩm
- **Ví dụ**: 
  - `"Máy đo huyết áp Omron HEM-7130 - Ảnh chi tiết màn hình"`
  - `"Gậy chống 4 chân đen - Ảnh chi tiết chân"`

### 3. Hình Ảnh Bao Bì (Package Images)
- **Mục đích**: Hiển thị bao bì, hộp đựng sản phẩm
- **Ví dụ**: `"Sữa Ensure Gold 400g - Ảnh bao bì"`

### 4. Hình Ảnh Sử Dụng (Usage Images)
- **Mục đích**: Minh họa cách sử dụng sản phẩm
- **Ví dụ**: 
  - `"Máy đo huyết áp Omron HEM-7130 - Ảnh sử dụng"`
  - `"Gậy chống 4 chân đen - Ảnh sử dụng"`

### 5. Hình Ảnh Phụ Kiện (Accessory Images)
- **Mục đích**: Hiển thị các phụ kiện đi kèm
- **Ví dụ**: 
  - `"Máy đo huyết áp Omron HEM-7130 - Ảnh phụ kiện"`
  - `"Máy xông mũi họng Omron NE-C28 - Ảnh mặt nạ"`

### 6. Hình Ảnh Thành Phần (Ingredient Images)
- **Mục đích**: Hiển thị thông tin thành phần (cho thực phẩm)
- **Ví dụ**: `"Sữa Ensure Gold 400g - Ảnh thành phần"`

### 7. Hình Ảnh Hướng Dẫn (Instruction Images)
- **Mục đích**: Hiển thị hướng dẫn sử dụng
- **Ví dụ**: `"Sữa Ensure Gold 400g - Ảnh hướng dẫn sử dụng"`

## Sản Phẩm Mẫu với Nhiều Hình Ảnh

### 1. Máy Đo Huyết Áp Omron HEM-7130
- **Số lượng hình ảnh**: 5 hình
- **Các loại**: Chính, chi tiết màn hình, bao bì, sử dụng, phụ kiện

### 2. Máy Đo Đường Huyết Accu-Chek Guide
- **Số lượng hình ảnh**: 4 hình
- **Các loại**: Chính, chi tiết, màn hình, que thử

### 3. Sữa Ensure Gold 400g
- **Số lượng hình ảnh**: 4 hình
- **Các loại**: Chính, thành phần, hướng dẫn sử dụng, bao bì

### 4. Gậy Chống 4 Chân
- **Số lượng hình ảnh**: 5 hình
- **Các loại**: Chính, chi tiết chân, tay cầm, sử dụng, gấp gọn

### 5. Xe Lăn Tay
- **Số lượng hình ảnh**: 5 hình
- **Các loại**: Chính, bánh xe, tay đẩy, gấp gọn, sử dụng

## Cách Sử Dụng Trong API

### Lấy Tất Cả Hình Ảnh Của Một Sản Phẩm
```csharp
var productImages = await _context.ProductImages
    .Where(pi => pi.ProductItemId == productItemId && !pi.IsDeleted)
    .OrderBy(pi => pi.ImageName)
    .ToListAsync();
```

### Lấy Hình Ảnh Chính
```csharp
var mainImage = await _context.ProductImages
    .FirstOrDefaultAsync(pi => 
        pi.ProductItemId == productItemId && 
        !pi.IsDeleted && 
        pi.ImageName.Contains("Ảnh chính"));
```

### Lấy Hình Ảnh Theo Loại
```csharp
var detailImages = await _context.ProductImages
    .Where(pi => 
        pi.ProductItemId == productItemId && 
        !pi.IsDeleted && 
        pi.ImageName.Contains("chi tiết"))
    .ToListAsync();
```

## Quy Ước Đặt Tên

### Đường Dẫn Hình Ảnh
```
/images/products/{product-name}-{variant}-{image-number}.jpg
```

### Tên Hình Ảnh
```
{Tên sản phẩm} - {Mô tả loại hình ảnh}
```

## Lưu Ý Khi Phát Triển

1. **Tối ưu hóa hình ảnh**: Nên nén hình ảnh để giảm dung lượng
2. **Kích thước chuẩn**: Đề xuất sử dụng kích thước chuẩn cho từng loại hình ảnh
3. **Alt text**: Cần thêm alt text cho accessibility
4. **Lazy loading**: Nên implement lazy loading cho gallery hình ảnh
5. **Thumbnail**: Tạo thumbnail cho hình ảnh để tăng tốc độ tải

## Migration

Khi cập nhật database, chạy lệnh:
```bash
dotnet ef database update
```

Điều này sẽ thêm tất cả hình ảnh mới vào database. 