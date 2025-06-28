using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Add.AddStockToStoreProductItems
{
    public sealed record AddStockToStoreProductItemsCommand(Guid storeProductItemId, int stock) : IRequest<bool>;
    public class AddStockToStoreProductItemsHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<AddStockToStoreProductItemsCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<bool> Handle(AddStockToStoreProductItemsCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
                throw new AppExceptions("User not authenticated.");

            var storeUser = (await _unitOfWork.StoreUserRepository
                .GetAllAsync(x => x.Id == currentUserId))
                .FirstOrDefault();
            if (storeUser == null)
                throw new AppExceptions("StoreUser not found for the current user.");

            var storeId = storeUser.StoreId;

            var storeProductItem = (await _unitOfWork.StoreProductItemRepository
                .GetAllAsync(x => x.Id == request.storeProductItemId && x.StoreId == storeId))
                .FirstOrDefault();

            if (storeProductItem == null)
                throw new AppExceptions($"StoreProductItem not found or access denied.");

            storeProductItem.Stock += request.stock;

            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
