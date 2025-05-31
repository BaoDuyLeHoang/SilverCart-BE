using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Stores.Commands.Update.UpdateStore
{
    public class UpdateStoreHandler : IRequestHandler<UpdateStoreCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        public UpdateStoreHandler(
            IUnitOfWork unitOfWork,
            IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }

        public async Task<Guid> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var userId = _claimsService.CurrentUserId;
            var storeUserQuery = await _unitOfWork.StoreUserRepository
                .GetAllAsync(x => x.Id == userId && x.StoreId == request.Id);

            var storeUser = await storeUserQuery.FirstOrDefaultAsync(cancellationToken);

            if (storeUser == null)
            {
                throw new Exception("You don't have permission to update this store");
            }

            var store = await _unitOfWork.StoreRepository.GetByIdAsync(request.Id);
            if (store == null)
            {
                throw new Exception("Store not found");
            }

            // Check if name is already taken by another store
            if (store.Name != request.StoreName)
            {
                var existedStoreQuery = await _unitOfWork.StoreRepository
                    .GetAllAsync(x => x.Name == request.StoreName && x.Id != request.Id);

                if (await existedStoreQuery.AnyAsync(cancellationToken))
                {
                    throw new Exception("Store name already exists");
                }
            }

            // Update store
            store.Name = request.StoreName;
            store.Infomation = request.Information;
            store.AdditionalInfo = request.AdditionalInfo;
            store.IsActive = request.IsActive;

            if (!string.IsNullOrEmpty(request.AvatarPath))
            {
                store.AvatarPath = request.AvatarPath;
            }

            _unitOfWork.StoreRepository.Update(store);

            // Update store address
            var storeAddress = await _unitOfWork.StoreAddressRepository.GetByIdAsync(store.StoreAddressId);
            if (storeAddress != null)
            {
                storeAddress.StreetAddress = request.StreetAddress;
                storeAddress.WardCode = request.WardCode;
                storeAddress.DistrictId = request.DistrictId;
                storeAddress.FromDistrictName = request.DistrictName;
                storeAddress.FromProvinceName = request.ProvinceName;

                _unitOfWork.StoreAddressRepository.Update(storeAddress);
            }

            await _unitOfWork.SaveChangeAsync();
            return store.Id;
        }
    }
}