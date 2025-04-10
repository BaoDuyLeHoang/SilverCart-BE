namespace Domain.Common.Interfaces;

public interface IUserTracking
{
    public Guid? CreatedBy { get; set; }
    public Guid? ModificationBy { get; set; }

}