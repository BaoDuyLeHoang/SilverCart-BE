using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Commons.Exceptions;

public class AppExceptions : Exception
{
    public ICollection<string> Errors { get; }
    public ICollection<FieldError> FieldErrors { get; }
    public int StatusCode { get; } = 400;

    public AppExceptions() : base()
    {
        Errors = new List<string>();
        FieldErrors = new List<FieldError>();
    }

    public AppExceptions(string message) : base(message)
    {
        Errors = new List<string> { message };
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppExceptions(ICollection<string> errors) : base("One or more errors occurred.")
    {
        Errors = errors ?? new List<string>();
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppExceptions(string message, int statusCode) : base(message)
    {
        Errors = new List<string> { message };
        FieldErrors = new List<FieldError>();
        StatusCode = statusCode;
    }

    public AppExceptions(string message, ICollection<string> errors) : base(message)
    {
        Errors = errors ?? new List<string>();
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppExceptions(string message, Exception innerException) : base(message, innerException)
    {
        Errors = new List<string> { message };
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppExceptions(string message, ICollection<string> errors, Exception innerException) : base(message, innerException)
    {
        Errors = errors ?? new List<string>();
        FieldErrors = new List<FieldError>();
        StatusCode = 400;
    }

    public AppExceptions(string message, List<FieldError> fieldErrors, int statusCode) : base(message)
    {
        Errors = new List<string>();
        FieldErrors = fieldErrors ?? new List<FieldError>();
        StatusCode = statusCode;
    }

    public AppExceptions(string message, List<FieldError> fieldErrors) : base(message)
    {
        Errors = new List<string>();
        FieldErrors = fieldErrors ?? new List<FieldError>();
    }

    public AppExceptions(string message, List<FieldError> fieldErrors, Exception innerException) : base(message,
        innerException)
    {
        Errors = new List<string>();
        FieldErrors = fieldErrors ?? new List<FieldError>();
        StatusCode = 400;
    }

    public static void ThrowIfNotFound(object value, string message)
    {
        if (value == null)
            throw new AppExceptions(message, 404);
    }

    public static void ThrowIfTrue(bool condition, string message, int statusCode = 400)
    {
        if (condition)
            throw new AppExceptions(message, statusCode);
    }
}