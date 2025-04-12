namespace Domain.Entities;

public class ProductImage : BaseFullEntity
{
    public string ImagePath { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;

    // Navigation Properties
    public int? ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public int? ProductItemId { get; set; }
    public virtual ProductItem? ProductItem { get; set; }
}