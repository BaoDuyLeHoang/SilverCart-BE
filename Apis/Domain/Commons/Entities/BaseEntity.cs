using Domain.Common.Interfaces;

namespace Domain.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}