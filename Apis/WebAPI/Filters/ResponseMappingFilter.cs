using System.Net;
using Application.Commons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

public class ResponseMappingFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        ApiResponse response;

        if (context.Result is ObjectResult objectResult)
        {
            var statusCodeMessage = (HttpStatusCode?)objectResult.StatusCode;
            if (objectResult.Value is string s)
                objectResult.Value = new ApiResponse
                {
                    StatusCode = objectResult.StatusCode ?? 200,
                    Message = s
                };
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
}