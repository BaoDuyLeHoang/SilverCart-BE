using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Create.CreateProductPromotion
{
    public sealed record AddProductToPromotionCommand(Guid PromotionId, List<Guid> ProductIds) : IRequest<AddProductToPromotionResponse>;
    public record AddProductToPromotionResponse(Guid PromotionId, List<Guid> ProductIds);

    public sealed class AddProductToPromotionHandler : IRequestHandler<AddProductToPromotionCommand, AddProductToPromotionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductToPromotionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddProductToPromotionResponse> Handle(AddProductToPromotionCommand request, CancellationToken cancellationToken)
        {
            // 1. Check if promotion exists
            var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(request.PromotionId);
            if (promotion == null)
                throw new KeyNotFoundException("Khuyến mãi này không tồn tại. Vui lòng thử lại");

            // 2. Get all existing ProductPromotion relations for this Promotion
            var existingProductPromotions = await _unitOfWork.ProductPromotionRepository
                .GetByPromotionIdAsync(request.PromotionId);

            var existingProductIds = existingProductPromotions.Select(pp => pp.ProductId).ToHashSet();

            // 3. Get valid product entities
            var validProducts = await _unitOfWork.ProductRepository
                .GetAllAsync(p => request.ProductIds.Contains(p.Id));
            var validProductIds = validProducts.Select(p => p.Id).ToHashSet();

            // 4. Filter out duplicates and non-existent IDs
            var newProductPromotions = request.ProductIds
                .Where(pid => validProductIds.Contains(pid) && !existingProductIds.Contains(pid))
                .Select(pid => new ProductPromotion
                {
                    ProductId = pid,
                    PromotionId = request.PromotionId
                }).ToList();


            foreach (var productPromotion in newProductPromotions)
            {
                // Check if the product already exists in the promotion
                if (existingProductIds.Contains(productPromotion.ProductId))
                    throw new AppExceptions($"Sản phẩm {productPromotion.ProductId} đã có trong khuyến mãi.");

                await _unitOfWork.ProductPromotionRepository.AddAsync(productPromotion);
                await _unitOfWork.SaveChangeAsync();
            }
            await _unitOfWork.SaveChangeAsync();

            return new AddProductToPromotionResponse(
                PromotionId: request.PromotionId,
                ProductIds: newProductPromotions.Select(pp => pp.ProductId).ToList()
                );
        }

    }
}
