using MediatR;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Create.CreatePromotion
{
    public record CreatePromotionResponse(Guid Id, string Name, string Description, DateTime StartDate, DateTime EndDate, decimal Discount, string DiscountType, bool IsActive, int MinimumQuantity, int MaximumQuantity, decimal MinimumPrice, decimal MaximumPrice);
    public sealed class CreatePromotionHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreatePromotionCommand, CreatePromotionResponse>
    {
        public readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<CreatePromotionResponse> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = new Promotion
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Discount = request.Discount,
                DiscountType = request.DiscountType,
                IsActive = request.IsActive,
                MinimumQuantity = request.MinimumQuantity,
                MaximumQuantity = request.MaximumQuantity,
                MinimumPrice = request.MinimumPrice,
                MaximumPrice = request.MaximumPrice
            };

            foreach (var productId in request.ProductIds)
            {
                promotion.ProductPromotions.Add(new ProductPromotion
                {
                    ProductId = productId,
                    Promotion = promotion
                });
            }

            await unitOfWork.PromotionRepository.AddAsync(promotion);
            await unitOfWork.UserPromotionRepository.AddAsync(new UserPromotion
            {
                Promotion = promotion,
                UserId = request.UserId
            });

            await _unitOfWork.SaveChangeAsync();

            return new CreatePromotionResponse(
                Id: promotion.Id,
                Name: promotion.Name,
                Description: promotion.Description,
                StartDate: promotion.StartDate,
                EndDate: promotion.EndDate,
                Discount: promotion.Discount,
                DiscountType: promotion.DiscountType.ToString(),
                IsActive: promotion.IsActive,
                MinimumQuantity: promotion.MinimumQuantity,
                MaximumQuantity: promotion.MaximumQuantity,
                MinimumPrice: promotion.MinimumPrice,
                MaximumPrice: promotion.MaximumPrice
                );
        }
    }

}
