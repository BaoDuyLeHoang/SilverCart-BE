namespace SilverCart.Domain.Entities.Cart;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public decimal TotalPrice { get; set; } = 0;

    public bool IsConsultantUserRecommend { get; set; } = false;

    // Navigation properties
    public Guid? StoreUserId { get; set; }
    public virtual StoreUser? StoreUser { get; set; }
}