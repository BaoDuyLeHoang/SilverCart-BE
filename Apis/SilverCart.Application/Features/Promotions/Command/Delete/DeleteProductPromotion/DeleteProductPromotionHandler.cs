using Infrastructures.Features.Promotions.Command.Delete.Infrastructures.Features.Promotions.Command.Delete.DeleteProductPromotions;
using MediatR;
using SilverCart.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Delete.DeleteProductPromotions
{
    public record DeleteProductPromotionResponse (string Message);
    public class DeleteProductPromotionsHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductPromotionsCommand, DeleteProductPromotionResponse>
    {
        public async Task<DeleteProductPromotionResponse> Handle(DeleteProductPromotionsCommand request, CancellationToken cancellationToken)
        {
            var productPromotions = await unitOfWork.ProductPromotionRepository
                .GetByPromotionIdAsync(request.PromotionId);

            if (productPromotions == null || !productPromotions.Any())
                return new DeleteProductPromotionResponse(Message: "Danh sách sản phẩm áp dụng chương trình khuyến mãi này đang trống");
            foreach (var productPromotion in productPromotions)
            {
                    
                foreach (var productId in request.ProductIds)
                {
                    if (productPromotion.ProductId != productId)
                        throw new KeyNotFoundException($"ProductPromotion with ID {productPromotion.PromotionId} not found.");

                    unitOfWork.ProductPromotionRepository.DeleteAsync(productPromotion);
                }
            }

            await unitOfWork.SaveChangeAsync();
            return new DeleteProductPromotionResponse(Message: "Xóa thành công!");
        }
    }
}
