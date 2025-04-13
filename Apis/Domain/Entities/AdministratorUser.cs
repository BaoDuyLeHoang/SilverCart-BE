namespace Domain.Entities;

public class AdministratorUser : BaseUser
{
    
    
    // Navigation Properties
    public int RoleId { get; set; }
    public virtual AdministratorUserRole Role { get; set; } = null!;
    public ICollection<Report> Reports { get; set; } = new List<Report>();
    
}