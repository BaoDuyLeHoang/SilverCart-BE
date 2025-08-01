using SilverCart.Domain.Entities.Products;

namespace SilverCart.Domain.Entities;



public sealed class ProductPromotion : AuditableEntity
{
    public Guid ProductId { get; set; }
    public Guid PromotionId { get; set; }
    public Product Product { get; set; } = null!;
    public Promotion Promotion { get; set; } = null!;
}