using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Entities.Products;

namespace SilverCart.Domain.Entities.Categories
{
    public class ProductCategory : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }

        // Navigation properties
        public virtual Product Product { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}
