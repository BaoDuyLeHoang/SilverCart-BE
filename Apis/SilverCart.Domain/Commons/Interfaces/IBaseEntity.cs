namespace SilverCart.Domain.Common.Interfaces;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}