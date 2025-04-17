namespace Domain.Common.Interfaces;

public interface IDateTracking
{
    public DateTime? CreationDate { get; set; }

    public DateTime? ModificationDate { get; set; }

    public DateTime? DeletionDate { get; set; }
}