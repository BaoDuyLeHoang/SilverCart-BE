using SilverCart.Domain.Entities.Products;

namespace SilverCart.Domain.Entities;

public class ProductImage : BaseEntity
{
    public string ImagePath { get; set; } = string.Empty;
    public string ImageName { get; set; } = string.Empty;
    public bool IsMain { get; set; } = false;
    public int Order { get; set; } = 0;
    public Guid? ProductItemId { get; set; }
    public virtual ProductItem? ProductItem { get; set; }
}