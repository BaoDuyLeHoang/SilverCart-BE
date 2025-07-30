using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Common.Interfaces;

public abstract class AuditableEntity : IAuditableEntity
{
    public DateTime? CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? ModificationById { get; set; }
    public Guid? DeleteById { get; set; }
    public bool IsHardDelete { get; set; }
}