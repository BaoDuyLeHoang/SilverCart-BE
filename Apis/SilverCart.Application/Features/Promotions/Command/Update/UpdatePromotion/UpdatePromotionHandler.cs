using MediatR;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Update.UpdatePromotion
{
    public record UpdatePromotionResponse(Guid Id, string Name, string Description, DateTime StartDate, DateTime EndDate, decimal Discount, string DiscountType, bool IsActive, int MinimumQuantity, int MaximumQuantity, decimal MinimumPrice, decimal MaximumPrice, List<Guid> ProductPromotions);
    //public record ProductPromotionsResposne (Guid ProductId);
    public sealed class UpdatePromotionHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePromotionCommand, UpdatePromotionResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<UpdatePromotionResponse> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(request.Id);
            if (promotion == null)
                throw new KeyNotFoundException("Promotion not found.");

            promotion.Name = request.Name;
            promotion.Description = request.Description;
            promotion.StartDate = request.StartDate;
            promotion.EndDate = request.EndDate;
            promotion.Discount = request.Discount;
            promotion.DiscountType = request.DiscountType;
            promotion.IsActive = request.IsActive;
            promotion.MinimumQuantity = request.MinimumQuantity;
            promotion.MaximumQuantity = request.MaximumQuantity;
            promotion.MinimumPrice = request.MinimumPrice;
            promotion.MaximumPrice = request.MaximumPrice;

            // Remove old ProductPromotions
            promotion.ProductPromotions.Clear();

            foreach (var productId in request.ProductPromotions)
            {
                await _unitOfWork.ProductPromotionRepository.AddAsync(new ProductPromotion
                {
                    ProductId = productId,
                    Promotion = promotion
                });
                await _unitOfWork.SaveChangeAsync();
            }
            _unitOfWork.PromotionRepository.Update(promotion);
            await _unitOfWork.SaveChangeAsync();

            return new UpdatePromotionResponse(
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
                MaximumPrice: promotion.MaximumPrice,
                ProductPromotions: promotion.ProductPromotions.Select(pp => pp.ProductId).ToList()
            );
        }
    }

}
