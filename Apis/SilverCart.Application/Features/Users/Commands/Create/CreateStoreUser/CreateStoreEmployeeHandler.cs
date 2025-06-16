using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Commons.Enums;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Users.Commands.Create.CreateStoreUser
{
    public sealed record CreateStoreEmployeeCommand(List<CreateStoreEmployee> StoreEmployees) : IRequest<List<Guid>>;
    public record CreateStoreEmployee(string Email, string Password, string Phone, string FullName, RoleInStore RoleInStore);
    public class CreateStoreEmployeeHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager, ICurrentTime currentTime, IClaimsService claimsService) : IRequestHandler<CreateStoreEmployeeCommand, List<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly UserManager<BaseUser> _userManager = userManager;
        private readonly IClaimsService _claimsService = claimsService;
        private readonly ICurrentTime _currentTime = currentTime;
        public async Task<List<Guid>> Handle(CreateStoreEmployeeCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == null)
                throw new AppExceptions("User not found");
            var storeOwner = await _unitOfWork.StoreUserRepository.GetByIdAsync(currentUserId);
            if (storeOwner == null)
                throw new AppExceptions("Store owner not found");

            var createdUserIds = new List<Guid>();
            foreach (var storeEmployee in request.StoreEmployees)
            {
                var user = new BaseUser
                {
                    Email = storeEmployee.Email,
                    UserName = storeEmployee.Email,
                    PhoneNumber = storeEmployee.Phone,
                    FullName = storeEmployee.FullName,
                    CreationDate = _currentTime.GetCurrentTime(),
                    ModificationDate = _currentTime.GetCurrentTime(),
                    IsDeleted = false,
                    CreatedById = currentUserId,
                    ModificationById = currentUserId,
                };
                await _userManager.CreateAsync(user, storeEmployee.Password);
                await _userManager.AddToRoleAsync(user, storeEmployee.RoleInStore.ToString());
                createdUserIds.Add(user.Id);

                var storeUser = new StoreUser
                {
                    StoreId = storeOwner.StoreId,
                    Id = user.Id,
                };
                await _unitOfWork.StoreUserRepository.AddAsync(storeUser);
            }

            await _unitOfWork.SaveChangeAsync();
            return createdUserIds;
        }
    }
}