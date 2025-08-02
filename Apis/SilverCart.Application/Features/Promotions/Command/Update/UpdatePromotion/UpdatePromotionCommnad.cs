using MediatR;
using SilverCart.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Update.UpdatePromotion
{
    public sealed record UpdatePromotionCommand(
        Guid Id,
        string Name,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        decimal Discount,
        PromotionDiscountTypeEnum DiscountType,
        bool IsActive,
        int MinimumQuantity,
        int MaximumQuantity,
        decimal MinimumPrice,
        decimal MaximumPrice,
        List<Guid> ProductPromotions
    ) : IRequest<UpdatePromotionResponse>;

}
