using System.Net;
using Application.Commons;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

public class ResponseMappingFilter : IResultFilter
{
    private readonly ILogger<ResponseMappingFilter> _logger;
    private readonly IMapper _mapper;

    public ResponseMappingFilter(ILogger<ResponseMappingFilter> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    public void OnResultExecuting(ResultExecutingContext context)
    {

        if (context.Result is ObjectResult objectResult)
        {
            var statusCodeMessage = (HttpStatusCode?)objectResult.StatusCode;
            if (IsPrivitiveType(objectResult.Value.GetType()))
            {
                var value = objectResult.Value;
                string? stringValue = value is string str ? str : null;
                objectResult.Value = new ApiResponse
                {
                    StatusCode = objectResult.StatusCode ?? 200,
                    Message = stringValue,
                    Data = value is string ? null : value
                };
            }
            else if (objectResult.Value is Result result)
            {
                var apiResponse = new ApiResponse()
                {
                    StatusCode = (int)result.StatusCode,
                    Message = result.Message,
                    
                };
                if (result.GetType().IsGenericType && result.GetType().GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var valueProperty = result.GetType().GetProperty("Value");
                    apiResponse.Data = valueProperty?.GetValue(result);
                }
                objectResult.Value = apiResponse;
            }
            else if (objectResult.Value is HttpValidationProblemDetails err)
            {
                objectResult.Value = new ApiExceptionResponse()
                {
                    StatusCode = objectResult.StatusCode ?? 500,
                    Message = err.Title,
                    TraceId = err.Extensions["traceId"]?.ToString(),
                    Type = err.Type,
                    Data = err.Errors
                };
            }
            else
            {
                objectResult.Value = new ApiResponse
                {
                    StatusCode = objectResult.StatusCode ?? 200,
                    Message = statusCodeMessage.ToString(),
                    Data = objectResult.Value
                };
            }
        }
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        // do nothing
    }

    private bool IsPrivitiveType(Type type)
    {
        return type.IsPrimitive || type.IsValueType || type == typeof(string);
    }
}