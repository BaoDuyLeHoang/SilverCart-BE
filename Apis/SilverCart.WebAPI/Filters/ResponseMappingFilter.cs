
using SilverCart.Application.Commons;
using Infrastructures.Commons;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebAPI.Filters;

public class ResponseMappingFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        if (context.Result is not ObjectResult objectResult) return;

        var value = objectResult.Value;
        if (value == null) return;

        if (value is IResultObject resultObject)
        {
            context.Result = resultObject.ToObjectResult();
        }
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        // No action needed after result execution
    }

    // private static ApiResponse CreateApiResponseForPrimitive(object value, int? statusCode)
    // {
    //     var isString = value is string;
    //     return new ApiResponse
    //     {
    //         StatusCode = statusCode ?? 200,
    //         Message = isString ? (string)value : null,
    //         Data = isString ? null : value
    //     };
    // }

    // private static bool IsPrimitiveType(Type type)
    // {
    //     return type.IsPrimitive || type.IsValueType || type == typeof(string);
    // }
}