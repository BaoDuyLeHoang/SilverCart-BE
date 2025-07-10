using Infrastructures.Commons.Exceptions;

using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public sealed record CreateDependentUserCommand(List<CreateDependentUser> DependentUsers) : IRequest<List<Guid>>;
public record CreateDependentUser(string Phone, string FullName, RegisterUserAddress Address);
public class CreateDependentUserHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager, ICurrentTime currentTime, IClaimsService claimsService) : IRequestHandler<CreateDependentUserCommand, List<Guid>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly UserManager<BaseUser> _userManager = userManager;
    private readonly ICurrentTime _currentTime = currentTime;
    private readonly IClaimsService _claimsService = claimsService;
    public async Task<List<Guid>> Handle(CreateDependentUserCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        var currentRole = _claimsService.CurrentRole;
        var guardian = await _unitOfWork.UserRepository.GetByIdAsync(currentUserId);
        if (guardian == null)
            throw new AppExceptions("Guardian not found");

        var guardianRole = await _userManager.GetRolesAsync(guardian);
        if (!guardianRole.Contains("Guardian"))
            throw new AppExceptions("This user is not a guardian");

        var createdUserIds = new List<Guid>();

        foreach (var dependentUser in request.DependentUsers)
        {
            var user = new BaseUser
            {
                UserName = Guid.NewGuid().ToString(),
                PhoneNumber = dependentUser.Phone,
                FullName = dependentUser.FullName,
                CreationDate = _currentTime.GetCurrentTime(),
                Email = null,
                Addresses = new List<Address>
                {
                    new Address
                    {
                        StreetAddress = dependentUser.Address.StreetAddress,
                        WardCode = dependentUser.Address.WardCode,
                        DistrictId = dependentUser.Address.DistrictId
                    }
                }
            };

            var tempPassword = "SilverCart2025@";

            var result = await _userManager.CreateAsync(user, tempPassword);
            if (!result.Succeeded)
                throw new AppExceptions(result.Errors.FirstOrDefault()?.Description ?? "Failed to create dependent user");

            await _userManager.AddToRoleAsync(user, "DependentUser");
            createdUserIds.Add(user.Id);

            var dependentUserEntity = new DependentUser
            {
                Id = user.Id,
                GuardianId = guardian.Id,
                CreationDate = _currentTime.GetCurrentTime()
            };
            await _unitOfWork.DependentUserRepository.AddAsync(dependentUserEntity);
        }
        await _unitOfWork.SaveChangeAsync();

        return createdUserIds;
    }
}
