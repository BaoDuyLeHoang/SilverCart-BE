using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Promotions.Command.Delete.DeletePromotion
{
    public sealed class DeletePromotionHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePromotionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<bool> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(request.Id);
            if (promotion == null)
                throw new KeyNotFoundException("Promotion not found.");
            if (!promotion.IsActive)
                throw new InvalidOperationException("Promotion is already inactive and cannot be deleted.");
            promotion.IsActive = false;
            _unitOfWork.PromotionRepository.Update(promotion);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
