using AutoMapper;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Commons.Enums;
using SilverCart.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Stores.Commands.Create.CreateStore
{
    public class CreateStoreHandler(IUnitOfWork unitOfWork, IClaimsService claimsService, ICurrentTime currentTime, UserManager<BaseUser> userManager, IGhnService ghnService) : IRequestHandler<CreateStoreCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        private readonly ICurrentTime _currentTime = currentTime;
        private readonly UserManager<BaseUser> _userManager = userManager;
        private readonly IGhnService _ghnService = ghnService;
        public async Task<Guid> Handle(CreateStoreCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            var currentUser = await _unitOfWork.UserRepository.GetByIdAsync(currentUserId);
            if (currentUser == null)
                throw new AppExceptions("User not found");

            // Check if user already has a store
            if (currentUser.StoreId != null)
                throw new AppExceptions("User already owns a store");

            // Register store with GHN
            var shopId = await _ghnService.RegisterStoreAsync(new CreateStoreGhnRequest
            {
                DistrictId = request.DistrictId,
                WardCode = request.WardCode,
                ShopName = request.StoreName,
                ShopPhone = currentUser.PhoneNumber ?? throw new AppExceptions("User does not have a phone number"),
                ShopAddress = request.StreetAddress
            });

            // Create store entity
            var store = new Store
            {
                Id = Guid.NewGuid(),
                Name = request.StoreName,
                Infomation = request.Information,
                AdditionalInfo = request.AdditionalInfo,
                AvatarPath = request.AvatarPath ?? string.Empty,
                Phone = currentUser.PhoneNumber,
                GhnShopId = shopId,
                CreationDate = _currentTime.GetCurrentTime()
            };

            // Create address
            var address = new StoreAddress
            {
                StreetAddress = request.StreetAddress,
                WardCode = request.WardCode,
                DistrictId = request.DistrictId,
                WardName = request.WardName,
                DistrictName = request.DistrictName,
                ProvinceName = request.ProvinceName
            };
            store.StoreAddress = address;

            // Assign store to current user
            currentUser.StoreId = store.Id;
            _unitOfWork.UserRepository.Update(currentUser);

            // Save all
            await _unitOfWork.StoreRepository.AddAsync(store);
            await _unitOfWork.StoreAddressRepository.AddAsync(address);
            await _unitOfWork.SaveChangeAsync();

            // Add StoreOwner role if not assigned
            var hasRole = await _userManager.IsInRoleAsync(currentUser, "StoreOwner");
            if (!hasRole)
            {
                var addRoleResult = await _userManager.AddToRoleAsync(currentUser, "StoreOwner");
                if (!addRoleResult.Succeeded)
                    throw new AppExceptions("Failed to assign StoreOwner role to user");
            }

            return store.Id;
        }
    }
}