using Domain.Enums;

namespace Domain.Entities;

public class BaseReport : BaseFullEntity
{
    public string? ReportName { get; set; }
    public string? ReportDescription { get; set; }
    public string? ReportType { get; set; }
    public ReportStatusEnum? ReportStatus { get; set; }
}