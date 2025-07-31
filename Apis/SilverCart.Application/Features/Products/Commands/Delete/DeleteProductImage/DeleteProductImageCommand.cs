using MediatR;
using System;

namespace Infrastructures.Features.Products.Commands.Delete.DeleteProductImage
{
    public sealed record DeleteProductImageCommand(Guid ImageId) : IRequest<bool>;
}