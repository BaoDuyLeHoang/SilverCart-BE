using SilverCart.Domain.Common.Interfaces;

namespace SilverCart.Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity, IAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; } = false;
        public bool IsHardDelete { get; set; } = false;
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? ModificationById { get; set; }
        public Guid? DeleteById { get; set; }
    }
}