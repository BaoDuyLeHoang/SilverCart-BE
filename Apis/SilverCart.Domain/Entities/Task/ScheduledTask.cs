namespace SilverCart.Domain.Entities;

public class ScheduledTask : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? TaskPath { get; set; } = string.Empty;
    public DateTime ScheduledTime { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CompletedAt { get; set; }
    public DateTime? Deadline { get; set; }
    // Navigation properties
    public virtual StoreUser StoreUser { get; set; } = null!;
}