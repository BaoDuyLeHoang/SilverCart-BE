using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public sealed record RegisterUserCommand(string Email, string Password, string Phone, string FullName, RegisterUserAddress Address, bool IsGuardian) : IRequest<Guid>;
public record RegisterUserAddress(string StreetAddress, string WardCode, int DistrictId, string ToDistrictName, string ToProvinceName) : IRequest<Guid>;
public class RegisterUserHandler(IUnitOfWork unitOfWork, UserManager<BaseUser> userManager, ICurrentTime currentTime) : IRequestHandler<RegisterUserCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly UserManager<BaseUser> _userManager = userManager;
    private readonly ICurrentTime _currentTime = currentTime;
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var checkMailExist = await _userManager.FindByEmailAsync(request.Email);
        if (checkMailExist != null)
        {
            throw new AppExceptions("Email already exists");
        }
        var checkPhoneExist = await _unitOfWork.UserRepository.GetAllAsync(predicate: x => x.PhoneNumber == request.Phone);
        if (checkPhoneExist.Any())
        {
            throw new AppExceptions("Phone number already exists");
        }
        var user = new BaseUser
        {
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.Phone,
            UserName = request.Email,
            CreationDate = _currentTime.GetCurrentTime()
        };

        var address = new Address
        {
            StreetAddress = request.Address.StreetAddress,
            WardCode = request.Address.WardCode ?? "",
            DistrictId = request.Address.DistrictId,
            ToDistrictName = request.Address.ToDistrictName ?? "",
            ToProvinceName = request.Address.ToProvinceName ?? ""
        };
        user.Addresses.Add(address);

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new AppExceptions(errors);
        }
        await _unitOfWork.SaveChangeAsync();
        if (request.IsGuardian)
        {
            var roleResult = await _userManager.AddToRoleAsync(user, "Guardian");
            if (!roleResult.Succeeded)
            {
                var errors = string.Join("; ", roleResult.Errors.Select(e => e.Description));
                throw new AppExceptions(errors);
            }
            var guardianUser = new GuardianUser
            {
                Id = user.Id,
                CreationDate = _currentTime.GetCurrentTime()
            };
            await _unitOfWork.GuardianUserRepository.AddAsync(guardianUser);
        }
        else
        {
            var roleResult = await _userManager.AddToRoleAsync(user, "Customer");
            if (!roleResult.Succeeded)
            {
                var errors = string.Join("; ", roleResult.Errors.Select(e => e.Description));
                throw new AppExceptions(errors);
            }
        }
        return user.Id;
    }
}
