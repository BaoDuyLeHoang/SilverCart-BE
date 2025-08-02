using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Queries.GetById
{
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
        public sealed record GetPromotionByIdQuery(Guid? Id) : IRequest<GetPromotionByIdQueryResponse>;
        public record GetPromotionByIdQueryResponse(Guid? Id, string Name, string Description, DateTime StartDate, DateTime EndDate, decimal DiscountAmount, string DiscountType, bool IsActive, int MinimumQuantity, int MaximumQuanitity, decimal MinimumPrice, decimal MaximumPrice, List<ProductPromotion> Product);
        public class GetPromotionByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPromotionByUserIdQuery, GetPromotionByIdResponse>
        {
            private readonly IUnitOfWork _unitOfWork = unitOfWork;
            public async Task<GetPromotionByIdResponse> Handle(GetPromotionByUserIdQuery request, CancellationToken cancellationToken)
            {
                var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync((Guid)request.Id);
                if (promotion == null)
                {
                    throw new KeyNotFoundException($"Promotion with ID {request.Id} not found.");
                }
                var productPromotions = promotion.ProductPromotions?.Select(pp => new ProductPromotionResponse(
                   pp.ProductId,
                   pp.Product.Name
               )).ToList() ?? new();

                return new GetPromotionByIdResponse(
                    promotion.Id,
                    promotion.Name,
                    promotion.Description,
                    promotion.StartDate,
                    promotion.EndDate,
                    promotion.Discount,
                    promotion.DiscountType.ToString(),
                    promotion.IsActive,
                    promotion.MinimumQuantity,
                    promotion.MaximumQuantity,
                    promotion.MinimumPrice,
                    promotion.MaximumPrice,
                    productPromotions
                );
            }
        }
    }

}
