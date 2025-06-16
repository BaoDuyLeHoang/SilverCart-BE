namespace SilverCart.Domain.Entities;

public class ProductImage : BaseEntity
{
    public string ImagePath { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;

    public Guid? ProductItemId { get; set; }
    public virtual ProductItem? ProductItem { get; set; }
}