using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;
using SilverCart.Domain.Enums;

namespace Infrastructures;

public sealed record CreateDependentUserCommand(List<CreateDependentUser> DependentUsers) : IRequest<List<Guid>>;
public record CreateDependentUser(
    string Phone,
    string FullName,
    string Gender,
    RegisterUserAddress Address,
    DateTime? DateOfBirth = null,
    RelationshipEnum? Relationship = null,
    string? MedicalNotes = null,
    decimal? MonthlySpendingLimit = null,
    Guid? AddressId = null,
    string? ImageUrl = null,
    List<int>? SuggestedCategoryIds = null
);

public class CreateDependentUserHandler : IRequestHandler<CreateDependentUserCommand, List<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<BaseUser> _userManager;
    private readonly ICurrentTime _currentTime;
    private readonly IClaimsService _claimsService;

    public CreateDependentUserHandler(
        IUnitOfWork unitOfWork,
        UserManager<BaseUser> userManager,
        ICurrentTime currentTime,
        IClaimsService claimsService)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
        _currentTime = currentTime;
        _claimsService = claimsService;
    }

    public async Task<List<Guid>> Handle(CreateDependentUserCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        var createdUserIds = new List<Guid>();
        var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {


            foreach (var dependentUser in request.DependentUsers)
            {
                var user = new DependentUser
                {
                    PhoneNumber = dependentUser.Phone,
                    FullName = dependentUser.FullName,
                    Gender = dependentUser.Gender,
                    DateOfBirth = dependentUser.DateOfBirth,
                    Relationship = dependentUser.Relationship ?? RelationshipEnum.Other,
                    MedicalNotes = dependentUser.MedicalNotes,
                    MonthlySpendingLimit = dependentUser.MonthlySpendingLimit,
                    AddressId = dependentUser.AddressId,
                    ImageUrl = dependentUser.ImageUrl,
                    SuggestedCategoryIds = dependentUser.SuggestedCategoryIds,
                    CreationDate = _currentTime.GetCurrentTime(),
                    Email = null,
                    GuardianId = currentUserId
                };

                var tempPassword = "SilverCart2025@";

                var result = await _userManager.CreateAsync(user, tempPassword);
                if (!result.Succeeded)
                    throw new AppExceptions(result.Errors.FirstOrDefault()?.Description ?? "Lỗi khi tạo người dùng phụ thuộc");

                await _userManager.AddToRoleAsync(user, RoleEnum.DependentUser.ToString());
                createdUserIds.Add(user.Id);

                await _unitOfWork.DependentUserRepository.AddAsync(user);
                await _unitOfWork.SaveChangeAsync(cancellationToken);
            }
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

        return createdUserIds;
    }
}