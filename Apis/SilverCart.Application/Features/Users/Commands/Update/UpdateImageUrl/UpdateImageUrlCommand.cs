using MediatR;
using Microsoft.AspNetCore.Http;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Users.Commands.Update.UpdateImageUrl;

public sealed record UpdateImageUrlCommand(IFormFile ImageFile) : IRequest<UpdateImageUrlResponse>;

public record UpdateImageUrlResponse(
    Guid Id,
    string FullName,
    string? ImageUrl,
    string Gender,
    DateTime CreationDate,
    DateTime ModificationDate
);