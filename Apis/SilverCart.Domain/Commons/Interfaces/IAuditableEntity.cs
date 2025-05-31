namespace SilverCart.Domain.Common.Interfaces;

<<<<<<< HEAD:Apis/Domain/Commons/Entities/BaseFullEntity.cs
namespace Domain.Entities;

public abstract class BaseFullEntity : BaseEntity, IDateTracking, IUserTracking
=======
public interface IAuditableEntity
>>>>>>> main:Apis/SilverCart.Domain/Commons/Interfaces/IAuditableEntity.cs
{
    public DateTime? CreationDate { get; set; }

    public DateTime? ModificationDate { get; set; }

    public DateTime? DeletionDate { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? ModificationById { get; set; }
    public Guid? DeleteById { get; set; }
}