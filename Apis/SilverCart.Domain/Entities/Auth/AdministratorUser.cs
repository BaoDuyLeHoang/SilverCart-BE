namespace SilverCart.Domain.Entities.Auth;

public class AdministratorUser : BaseUser
{
    // Navigation Properties
    public Guid? RoleId { get; set; }
    public virtual AdministratorRole? Role { get; set; } = null!;
    public ICollection<Report> Reports { get; set; } = new List<Report>();
    public ICollection<Store> Stores { get; set; } = new List<Store>();
}