using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using SilverCart.Domain.Common.Interfaces;

namespace SilverCart.Domain.Commons.Entities;

public abstract class BaseRole : IdentityRole<Guid>, IBaseEntity, IAuditableEntity
{
    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;
    public bool IsHardDelete { get; set; } = false;
    public bool IsDeleted { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? ModificationById { get; set; }
    public Guid? DeleteById { get; set; }
}