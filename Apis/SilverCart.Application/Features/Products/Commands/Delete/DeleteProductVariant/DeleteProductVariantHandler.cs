using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Delete.DeleteProductVariant
{
    public sealed record class DeleteProductVariantCommand(Guid ProductId, Guid VariantId) : IRequest<Guid>;
    public class DeleteProductVariantHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductVariantCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Guid> Handle(DeleteProductVariantCommand request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductId,
                include: source => source.Include(x => x.Variants)
            );

            var product = products.FirstOrDefault();
            if (product == null)
                throw new AppExceptions($"Product with ID '{request.ProductId}' not found.");

            var variant = product.Variants.FirstOrDefault(v => v.Id == request.VariantId);
            if (variant == null)
                throw new AppExceptions($"Variant with ID '{request.VariantId}' not found in product '{request.ProductId}'.");

            variant.IsDeleted = true;
            await _unitOfWork.SaveChangeAsync();

            return product.Id;
        }
    }
}
