using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Infrastructures.Features.Products.Commands.Add.AddProductImages
{
    public sealed record AddProductImagesCommand(
        Guid? ProductId,
        Guid? ProductItemId,
        IFormFileCollection Images,
        bool IsMain,
        int Order) : IRequest<bool>;
}