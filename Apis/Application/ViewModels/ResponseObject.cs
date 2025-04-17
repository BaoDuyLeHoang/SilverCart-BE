namespace Application.ViewModels;

public record ResponseObject<T>(int StatusCode, string Message, T? Data);