namespace Domain.Common.Interfaces;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public Guid? DeleteBy { get; set; }

}