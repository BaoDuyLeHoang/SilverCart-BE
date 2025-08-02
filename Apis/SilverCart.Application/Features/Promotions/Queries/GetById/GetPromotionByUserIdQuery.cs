using Infrastructures.Commons.Exceptions;
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
<<<<<<< HEAD
    public sealed record GetPromotionByUserIdQuery(Guid? Id) : IRequest<GetPromotionByIdResponse>;
    public record GetPromotionByIdResponse(Guid? Id, string Name, string Description, DateTime StartDate, DateTime EndDate, decimal DiscountAmount, string DiscountType, bool IsActive, int MinimumQuantity, int MaximumQuanitity, decimal MinimumPrice, decimal MaximumPrice, List<ProductPromotion> Product);
=======
    public sealed record GetPromotionByUserIdQuery(Guid Id) : IRequest<GetPromotionByIdResponse>;
    public record GetPromotionByIdResponse(Guid? Id, string Name, string Description, DateTime StartDate, DateTime EndDate, decimal DiscountAmount, string DiscountType, bool IsActive, int MiximumQuantity, int MaximumQuanitity, decimal MinimumPrice, decimal MaximumPrice, List<ProductPromotionResponse> ProductPromotions);
    public record ProductPromotionResponse(); 
>>>>>>> fc9d1f9ab862665cf993f6c886d7e3a55bbdfbb8
    public class GetPromotionByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPromotionByUserIdQuery, GetPromotionByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<GetPromotionByIdResponse> Handle(GetPromotionByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userPromotion = await _unitOfWork.UserPromotionRepository.GetByIdAsync(request.Id);
            if (userPromotion == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy khuyến mãi với ID {request.Id}.");
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
