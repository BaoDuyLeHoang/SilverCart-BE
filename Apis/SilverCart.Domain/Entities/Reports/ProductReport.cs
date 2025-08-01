using SilverCart.Domain.Entities.Products;

namespace SilverCart.Domain.Entities;

public class ProductReport : Report
{
    public Guid ProductItemId { get; set; }
    public virtual ProductItem ProductItem { get; set; } = null!;
}