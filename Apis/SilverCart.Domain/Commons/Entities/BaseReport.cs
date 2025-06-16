using SilverCart.Domain.Enums;

namespace SilverCart.Domain.Entities;

public class BaseReport : BaseEntity
{
    public string? ReportName { get; set; }
    public string? ReportDescription { get; set; }
    public string? ReportType { get; set; }
    public ReportStatusEnum? ReportStatus { get; set; }
}