using Domain.Common.Interfaces;

namespace Domain.Entities;

public class BaseFullEntity : BaseEntity,IDateTracking,IUserTracking,ISoftDelete
{
    public DateTime CreationDate { get; set; }
    public DateTime? ModificationDate { get; set; }
    public DateTime? DeletionDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? ModificationBy { get; set; }
    public bool IsDeleted { get; set; }
    public Guid? DeleteBy { get; set; }
}