using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Delete.DeleteProductImage
{
    public sealed record DeleteProductImageCommand(Guid ProductItemId, List<Guid> ImageIds) : IRequest<Guid>;
    public class DeleteProductImageHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductImageCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Guid> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var productItems = await _unitOfWork.ProductItemRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductItemId,
                include: source => source.Include(x => x.ProductImages)
            );

            var productItem = productItems.FirstOrDefault();

            if (productItem == null)
                throw new KeyNotFoundException($"Product with ID '{request.ProductItemId}' not found.");

            foreach (var imageId in request.ImageIds)
            {
                var productImage = productItem.ProductImages.FirstOrDefault(x => x.Id == imageId);

                if (productImage != null)
                {
                    productImage.IsDeleted = true;
                }
                else
                {
                    throw new KeyNotFoundException($"Image with ID '{imageId}' not found for Product with ID '{request.ProductItemId}'.");
                }
            }

            await _unitOfWork.SaveChangeAsync();
            return productItem.Id;
        }
    }
}
