using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Stores.Commands.Update.UpdateStore
{
    public class UpdateStoreHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateStoreCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Guid> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            var store = await _unitOfWork.StoreRepository.GetByIdAsync(Guid.Parse("c4f31cea-14f3-45cd-98ad-39d68e78e0e7"));
            if (store == null)
            {
                throw new AppExceptions("Store not found");
            }
            // Update store
            store.Name = request.StoreName;
            store.Infomation = request.Information;
            store.AdditionalInfo = request.AdditionalInfo;
            store.Phone = request.Phone;

            if (!string.IsNullOrEmpty(request.AvatarPath))
            {
                store.AvatarPath = request.AvatarPath;
            }

            _unitOfWork.StoreRepository.Update(store);

            // Update store address
            var storeAddress = await _unitOfWork.StoreAddressRepository.GetByIdAsync(store.StoreAddressId);
            if (storeAddress != null)
            {
                storeAddress.Address = request.StreetAddress;
                storeAddress.WardCode = request.WardCode;
                storeAddress.DistrictId = request.DistrictId;
                storeAddress.WardName = request.WardName;
                storeAddress.DistrictName = request.DistrictName;
                storeAddress.ProvinceName = request.ProvinceName;

                _unitOfWork.StoreAddressRepository.Update(storeAddress);
            }

            await _unitOfWork.SaveChangeAsync();
            return store.Id;
        }
    }
}