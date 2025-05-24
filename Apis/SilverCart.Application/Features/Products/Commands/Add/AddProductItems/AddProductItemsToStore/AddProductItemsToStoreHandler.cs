using AutoMapper;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Add.AddProductItems.AddProductItemsToStore
{
    public sealed record AddProductItemsToStoreCommand(List<AddProductItemsToStore> AddProductItemsToStores) : IRequest<bool>;
    public record AddProductItemsToStore(Guid ProductItemId, int Stock);
    public class AddProductItemsToStoreHandler(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService) : IRequestHandler<AddProductItemsToStoreCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<bool> Handle(AddProductItemsToStoreCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
                throw new UnauthorizedAccessException("User not authenticated.");

            var storeUser = (await _unitOfWork.StoreUserRepository
                .GetAllAsync(x => x.Id == currentUserId))
                .FirstOrDefault();

            if (storeUser == null)
                throw new Exception("StoreUser not found for the current user.");

            var storeId = storeUser.StoreId;

            var productItemIds = request.AddProductItemsToStores.Select(x => x.ProductItemId).ToList();

            var existingProductItems = await _unitOfWork.ProductItemRepository
                .GetAllAsync(pi => productItemIds.Contains(pi.Id));

            var existingIds = existingProductItems.Select(pi => pi.Id).ToHashSet();

            var existingStoreProductItems = await _unitOfWork.StoreProductItemRepository
                .GetAllAsync(spi => spi.StoreId == storeId && productItemIds.Contains(spi.ProductItemId));

            var existingStoreProductItemsDict = existingStoreProductItems.ToDictionary(spi => spi.ProductItemId);

            foreach (var item in request.AddProductItemsToStores)
            {
                if (!existingIds.Contains(item.ProductItemId))
                    continue;

                if (existingStoreProductItemsDict.TryGetValue(item.ProductItemId, out var existingStoreItem))
                {
                    existingStoreItem.Stock += item.Stock;
                }
                else
                {
                    var newStoreItem = new StoreProductItem
                    {
                        Id = Guid.NewGuid(),
                        StoreId = storeId,
                        ProductItemId = item.ProductItemId,
                        Stock = item.Stock
                    };
                    await _unitOfWork.StoreProductItemRepository.AddAsync(newStoreItem);
                }
            }
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}
