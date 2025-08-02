using Infrastructures.Features.Promotions.Command.Deactive;
using Infrastructures.Features.Promotions.Command.Delete.DeletePromotion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.DeactiveOrActive
{
    public sealed class ActivePromotionHandler(IUnitOfWork unitOfWork) : IRequestHandler<ActivePromotionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<bool> Handle(ActivePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(request.Id);
            if (promotion == null)
                throw new KeyNotFoundException("Promotion not found.");
            if (!promotion.IsActive)
                throw new InvalidOperationException("Promotion is already active");
            promotion.IsActive = true;
            _unitOfWork.PromotionRepository.Update(promotion);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
