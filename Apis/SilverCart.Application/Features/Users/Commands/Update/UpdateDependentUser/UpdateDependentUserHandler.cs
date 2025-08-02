using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace Infrastructures.Features.Users.Commands.Update.UpdateDependentUser;

public class UpdateDependentUserHandler : IRequestHandler<UpdateDependentUserCommand, UpdateDependentUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;

    public UpdateDependentUserHandler(IUnitOfWork unitOfWork, IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _claimsService = claimsService;
    }

    public async Task<UpdateDependentUserResponse> Handle(UpdateDependentUserCommand request, CancellationToken cancellationToken)
    {
        var currentGuardianId = _claimsService.CurrentUserId;

        // Tìm DependentUser theo Id và đảm bảo thuộc về Guardian hiện tại
        var dependentUser = await _unitOfWork.DependentUserRepository.GetByIdAsync(request.Id);
        if (dependentUser == null)
            throw new AppExceptions($"Không tìm thấy DependentUser với ID {request.Id}.");

        if (dependentUser.GuardianId != currentGuardianId)
            throw new AppExceptions("Bạn không có quyền cập nhật DependentUser này.");

        // Cập nhật các field từ request (chỉ cập nhật nếu có giá trị)
        if (!string.IsNullOrEmpty(request.FullName))
            dependentUser.FullName = request.FullName;

        if (request.DateOfBirth.HasValue)
            dependentUser.DateOfBirth = request.DateOfBirth;

        if (!string.IsNullOrEmpty(request.Relationship))
            dependentUser.Relationship = request.Relationship;

        if (!string.IsNullOrEmpty(request.PhoneNumber))
            dependentUser.PhoneNumber = request.PhoneNumber;

        if (request.MedicalNotes != null)
            dependentUser.MedicalNotes = request.MedicalNotes;

        if (request.MonthlySpendingLimit.HasValue)
            dependentUser.MonthlySpendingLimit = request.MonthlySpendingLimit;

        if (request.AddressId.HasValue)
            dependentUser.AddressId = request.AddressId;

        if (request.ImageUrl != null)
            dependentUser.ImageUrl = request.ImageUrl;

        // Lưu thay đổi
        _unitOfWork.DependentUserRepository.Update(dependentUser);
        await _unitOfWork.SaveChangeAsync(cancellationToken);

        // Trả về response
        return new UpdateDependentUserResponse(
            dependentUser.Id,
            dependentUser.FullName,
            dependentUser.DateOfBirth,
            dependentUser.Relationship,
            dependentUser.PhoneNumber,
            dependentUser.MedicalNotes,
            dependentUser.MonthlySpendingLimit,
            dependentUser.AddressId,
            dependentUser.ImageUrl
        );
    }
}