using Domain.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public abstract class BaseRole : IdentityRole<Guid>,IBaseEntity,IDateTracking,IUserTracking
{
    public string Name { get; set; } = string.Empty;
    public string NormalizedName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? ModificationById { get; set; }
    public Guid? DeleteById { get; set; }
}