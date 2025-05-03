using System.Net;
using Application.Commons;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

public class Result
{
    public bool IsSuccess { get; }
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;
    public bool IsFailure => !IsSuccess;
    public string? Message { get; }

    protected Result(bool isSuccess, string? message, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        if (isSuccess && message != null)
            throw new InvalidOperationException();
        if (!isSuccess && message == null)
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Message = message;
        StatusCode = statusCode;
    }

    public static Result Success(HttpStatusCode statusCode = HttpStatusCode.OK) =>
        new(true, null, statusCode);

    public static Result Failure(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
        new(false, message, statusCode);

    public IActionResult ToObjectResult()
    {
        return new ObjectResult(this)
        {
            StatusCode = (int)this.StatusCode,
            Value = this
        };
    }
}

public sealed class Result<T> : Result
{
    private readonly T? _value;

    public T Value
    {
        get { return _value!; }
    }

    protected internal Result(T value, HttpStatusCode statusCode = HttpStatusCode.OK)
        : base(true, null, statusCode) => _value = value;

    protected internal Result(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : base(false, message, statusCode) => _value = default;

    public static Result<T> Success(T value, HttpStatusCode statusCode = HttpStatusCode.OK) =>
        new Result<T>(value, statusCode);

    public static Result<T> Failure(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) =>
        new(message, statusCode);
}