using System.Net;
using Infrastructures.Commons.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebAPI;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (AppExceptions ex)
        {
            await HandleAppExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleAppExceptionAsync(HttpContext context, AppExceptions exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var settings = new JsonSerializerSettings
        {
            ContractResolver = new LowercaseFirstLetterContractResolver()
        };
        var result = JsonConvert.SerializeObject(new
        {
            message = exception.Message,
            statusCode = 400,
            errors = exception.FieldErrors // Include the detailed errors here
        }, settings);

        return context.Response.WriteAsync(result);
    }

    public class LowercaseFirstLetterContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || char.IsLower(propertyName[0]))
                return propertyName;

            return char.ToLower(propertyName[0]) + propertyName.Substring(1);
        }
    }
}
