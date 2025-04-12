namespace Domain.Common.Interfaces;

public interface IUserTracking
{
    public Guid? CreatedById { get; set; }
    public Guid? ModificationById { get; set; }
    public Guid? DeleteById { get; set; }

}