using MediatR;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Queries.GetById
{
    public sealed record GetPromotionByUserIdQuery(Guid? Id) : IRequest<GetPromotionByIdResponse>;
    public record GetPromotionByIdResponse(Guid? Id, string Name, string Description, DateTime StartDate, DateTime EndDate, decimal DiscountAmount, string DiscountType, bool IsActive, int MinimumQuantity, int MaximumQuanitity, decimal MinimumPrice, decimal MaximumPrice, List<ProductPromotion> Product);
    public class GetPromotionByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPromotionByUserIdQuery, GetPromotionByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<GetPromotionByIdResponse> Handle(GetPromotionByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userPromotion = await _unitOfWork.UserPromotionRepository.GetByIdAsync((Guid)request.Id);
            if (userPromotion == null)
            {
                throw new KeyNotFoundException($"Promotion with ID {request.Id} not found.");
            }
            return new GetPromotionByIdResponse(
                userPromotion.Id,
                userPromotion.Promotion.Name,
                userPromotion.Promotion.Description,
                userPromotion.Promotion.StartDate,
                userPromotion.Promotion.EndDate,
                userPromotion.Promotion.Discount,
                userPromotion.Promotion.DiscountType.ToString(),
                userPromotion.Promotion.IsActive,
                userPromotion.Promotion.MinimumQuantity,
                userPromotion.Promotion.MaximumQuantity,
                userPromotion.Promotion.MinimumPrice,
                userPromotion.Promotion.MaximumPrice,
                userPromotion.Promotion.ProductPromotions.ToList()
            );
        }
    }
}
