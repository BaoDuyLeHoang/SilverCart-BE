namespace Domain.Entities;

public class OrderReview : BaseFullEntity
{
    public string ReviewText { get; set; } = string.Empty;
    public int Rating { get; set; }

    // Navigation properties
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public Guid CustomerId { get; set; }
    public CustomerUser Customer { get; set; } = null!;
}