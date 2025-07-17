using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructures.Commons
{

    public class ResultObject<T> : IResultObject
    {
        public bool IsSuccess { get; }
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.OK;
        public bool IsFailure => !IsSuccess;
        public string? Message { get; }
        private readonly T? _value;

        protected ResultObject(string? message, T? value = default, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            IsSuccess = (int)statusCode >= 200 && (int)statusCode < 300;
            Message = message;
            StatusCode = statusCode;
            _value = value;
        }

        public static IResultObject Success(T value, HttpStatusCode statusCode = HttpStatusCode.OK, string? message = null) => new ResultObject<T>(message, value, statusCode);

        public static IResultObject Failure(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest, T? value = default) => new ResultObject<T>(message, value, statusCode);

        public IActionResult ToObjectResult()
        {
            return new ObjectResult(this)
            {
                StatusCode = (int)StatusCode,
                Value = this

            };
        }

        public T? Value => _value;
    }
}