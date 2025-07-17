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
            var store = await _unitOfWork.StoreRepository.GetByIdAsync(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"), x => x.StoreAddress);
            if (store == null)
            {
                throw new AppExceptions("Không tìm thấy cửa hàng");
            }
            // Update store
            store.Name = request.StoreName;
            store.Description = request.Information;
            store.AdditionalInfo = request.AdditionalInfo;
            store.Phone = request.Phone;

            if (!string.IsNullOrEmpty(request.AvatarPath))
            {
                store.AvatarPath = request.AvatarPath;
            }

            _unitOfWork.StoreRepository.Update(store);

            // Update store address
            var storeAddress = store.StoreAddress;
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