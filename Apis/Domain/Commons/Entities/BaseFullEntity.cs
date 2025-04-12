using Domain.Common.Interfaces;

namespace Domain.Entities;

public class BaseFullEntity : BaseEntity,IDateTracking,IUserTracking
{
    public DateTime CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? ModificationById { get; set; }
    public Guid? DeleteById { get; set; }
}