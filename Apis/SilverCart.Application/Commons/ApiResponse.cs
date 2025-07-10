using System.Text.Json.Serialization;

namespace SilverCart.Application.Commons;

public class ApiResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ApiResponseStatus
{
    Success,
    Error,
    Warning
}

public class ApiExceptionResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public string? Type { get; set; }
    public string? TraceId { get; set; }
    public object? Data { get; set; }
}
