namespace Domain.Entities;

public class Cart : BaseFullEntity
{
    public int UserId { get; set; }
    
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    
    public decimal TotalPrice { get; set; } = 0;
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
    
    // Navigation properties
    public virtual StoreUser StoreUser { get; set; } = null!;
}