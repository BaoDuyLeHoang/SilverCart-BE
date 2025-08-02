using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SilverCart.Application.Interfaces;

namespace Infrastructures;

public sealed record UpdateUserProfileCommand(string? FullName, string? Phone, string? Email, UpdateUserProfileAddress? Address) : IRequest<Guid>;
public record UpdateUserProfileAddress(string? StreetAddress, string? WardCode, int? DistrictId);
public class UpdateUserProfileHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<UpdateUserProfileCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClaimsService _claimsService = claimsService;
    public async Task<Guid> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        var user = await _unitOfWork.UserRepository.GetByIdAsync(currentUserId);

        if (user == null)
            throw new AppExceptions("User not found");

        if (!request.FullName.IsNullOrEmpty())
            user.FullName = request.FullName;

        if (!request.Phone.IsNullOrEmpty())
            user.PhoneNumber = request.Phone;

        if (!request.Email.IsNullOrEmpty())
            user.Email = request.Email;

        if (request.Address != null)
        {
            var address = user.Addresses.FirstOrDefault();
            if (address != null)
            {
                if (!request.Address.StreetAddress.IsNullOrEmpty())
                    address.StreetAddress = request.Address.StreetAddress;

                if (!request.Address.WardCode.IsNullOrEmpty())
                    address.WardCode = request.Address.WardCode;

                if (request.Address.DistrictId.HasValue)
                    address.DistrictId = request.Address.DistrictId.Value;
            }
            else
            {
                user.Addresses.Add(new()
                {
                    StreetAddress = request.Address.StreetAddress,
                    WardCode = request.Address.WardCode,
                    DistrictId = request.Address.DistrictId ?? 0
                });
            }
        }

        await _unitOfWork.SaveChangeAsync();
        return currentUserId;
    }
}
