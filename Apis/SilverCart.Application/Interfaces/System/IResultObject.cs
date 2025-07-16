using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructures.Commons
{
    public interface IResultObject
    {
        bool IsSuccess { get; }
        HttpStatusCode StatusCode { get; }
        bool IsFailure { get; }
        string? Message { get; }
        IActionResult ToObjectResult();
    }
}