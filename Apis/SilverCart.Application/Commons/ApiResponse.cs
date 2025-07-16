using System.Text.Json.Serialization;

namespace SilverCart.Application.Commons;

public interface IApiResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public dynamic? Data { get; set; }
}

public class ApiResponse : IApiResponse
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public dynamic? Data { get; set; }
}

public class ErrorResponse : IApiResponse
{
    public int StatusCode { get; set; } = 500;
    public string? Message { get; set; } = "Internal server error";
    public string? Type { get; set; } = "Exception";
    public string TraceId { get; set; } = string.Empty;
    public dynamic? Data { get; set; } = default;
}
