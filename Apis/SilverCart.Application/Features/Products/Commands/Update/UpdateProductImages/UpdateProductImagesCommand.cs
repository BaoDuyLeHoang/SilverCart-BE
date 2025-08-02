using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProductImages
{
    public sealed record UpdateProductImagesCommand(
        Guid ImageId,
        Guid? ProductId,
        Guid? ProductItemId,
        IFormFile? Image,
        bool IsMain,
        int Order) : IRequest<bool>;
}