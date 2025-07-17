using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Delete.DeleteProductItems
{
    public sealed record DeleteProductItemCommand(Guid ProductId, Guid VariantId, Guid ItemId) : IRequest<Guid>;
    public class DeleteProductItemHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductItemCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Guid> Handle(DeleteProductItemCommand request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductId,
                include: source => source
                    .Include(p => p.Variants)
                        .ThenInclude(v => v.ProductItems)
            );

            var product = products.FirstOrDefault();
            if (product == null)
                throw new AppExceptions($"Product with ID '{request.ProductId}' not found.");

            var variant = product.Variants.FirstOrDefault(v => v.Id == request.VariantId);
            if (variant == null)
                throw new AppExceptions($"Variant with ID '{request.VariantId}' not found in product '{request.ProductId}'.");

            var item = variant.ProductItems.FirstOrDefault(i => i.Id == request.ItemId);
            if (item == null)
                throw new AppExceptions($"Item with ID '{request.ItemId}' not found in variant '{request.VariantId}'.");

            item.IsDeleted = true;
            await _unitOfWork.SaveChangeAsync();
            return product.Id;
        }
    }
}
