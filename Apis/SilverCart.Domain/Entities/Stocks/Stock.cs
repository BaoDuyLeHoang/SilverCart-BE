using SilverCart.Domain.Entities.Products;

namespace SilverCart.Domain.Entities.Stocks;

public class Stock : BaseEntity
{

    public int Quantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int AvailableQuantity { get; set; }
    public int SoldQuantity { get; set; }
    public int ReturnedQuantity { get; set; }
    public int DamagedQuantity { get; set; }
    //Navigation properties
    public Guid ProductItemId { get; set; }
    public ProductItem ProductItem { get; set; } = null!;
}