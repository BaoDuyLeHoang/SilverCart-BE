global using SilverCart.Domain.Entities.Stocks;
global using SilverCart.Domain.Entities.Stores;
using System.ComponentModel.DataAnnotations.Schema;

namespace SilverCart.Domain.Entities.Products;

public class ProductItem : BaseEntity
{
    public string SKU { get; set; } = string.Empty;
    public decimal OriginalPrice { get; set; }
    public decimal DiscountedPrice { get; set; }
    public int Weight { get; set; } = 0;
    public int Length { get; set; } = 0;
    public int Width { get; set; } = 0;
    public int Height { get; set; } = 0;
    public bool IsActive { get; set; } = true;

    // Foreign keys
    public Guid VariantId { get; set; }
    public virtual ProductVariant Variant { get; set; } = null!;

    [NotMapped]
    public Guid? StoreId => Variant.Product.StoreId;
    [NotMapped]
    public virtual Store? Store => Variant.Product.Store;

    public Guid StockId { get; set; }
    public virtual Stock Stock { get; set; } = null!;
    // Navigation properties
    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    public virtual ICollection<StockHistory> StockHistories { get; set; } = new List<StockHistory>();
}