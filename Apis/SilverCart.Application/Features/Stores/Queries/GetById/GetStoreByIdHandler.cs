using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Stores.Queries.GetById
{
    public class GetStoreByIdHandler : IRequestHandler<GetStoreByIdQuery, GetStoreByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetStoreByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetStoreByIdResponse> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            var storeQuery = await _unitOfWork.StoreRepository.GetAllAsync(
                predicate: s => s.Id == request.Id && !s.IsDeleted,
                include: source => source
                    .Include(s => s.StoreAddress)
                    .Include(s => s.StoreUsers)
            );

            var store = await storeQuery.FirstOrDefaultAsync(cancellationToken);
            if (store == null)
            {
                throw new AppExceptions("Store not found");
            }

            // Get users associated with this store
            var storeUsers = await _unitOfWork.StoreUserRepository.GetAllAsync(
                predicate: su => su.StoreId == store.Id && !su.IsDeleted);

            var storeUsersList = await storeUsers.ToListAsync(cancellationToken);

            // Get user details from UserRepository
            var userIds = storeUsersList.Select(su => su.Id).ToList();
            var usersQuery = await _unitOfWork.UserRepository.GetAllAsync(
                predicate: u => userIds.Contains(u.Id));
            var users = await usersQuery.ToListAsync(cancellationToken);

            return new GetStoreByIdResponse
            {
                Id = store.Id,
                StoreName = store.Name,
                Information = store.Infomation,
                AvatarPath = store.AvatarPath,
                AdditionalInfo = store.AdditionalInfo,
                IsActive = store.IsActive,
                IsGhnSynced = store.IsGhnSynced,
                GhnShopId = store.GhnShopId,
                CreatedDate = store.CreationDate,
                StoreAddress = store.StoreAddress != null ? new StoreAddressDetailResponse
                {
                    Id = store.StoreAddress.Id,
                    StreetAddress = store.StoreAddress.StreetAddress,
                    WardCode = store.StoreAddress.WardCode,
                    DistrictId = store.StoreAddress.DistrictId,
                    WardName = store.StoreAddress.WardName,
                    DistrictName = store.StoreAddress.DistrictName,
                    ProvinceName = store.StoreAddress.ProvinceName
                } : null,
                StoreUsers = storeUsersList
                    .Join(users,
                        su => su.Id,
                        user => user.Id,
                        (su, user) => new StoreUserResponse
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            FullName = user.FullName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber
                        })
                    .ToList()
            };
        }
    }
}