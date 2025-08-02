using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Auth;

namespace Infrastructures;

public sealed record CreateDependentUserCommand(CreateDependentUser DependentUser) : IRequest<Guid>;
public record CreateDependentUser(
    string Phone,
    string FullName,
    string Gender,
    DateTime? DateOfBirth = null,
    string? Relationship = null,
    string? MedicalNotes = null,
    decimal? MonthlySpendingLimit = null,
    string? ImageUrl = null
);

public class CreateDependentUserHandler : IRequestHandler<CreateDependentUserCommand, Guid>
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

    public async Task<Guid> Handle(CreateDependentUserCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            var dependentUser = request.DependentUser;
            var user = new DependentUser
            {
                PhoneNumber = dependentUser.Phone,
                FullName = dependentUser.FullName,
                Gender = dependentUser.Gender,
                UserName = dependentUser.Phone,
                DateOfBirth = dependentUser.DateOfBirth,
                Relationship = dependentUser.Relationship ?? "Other",
                MedicalNotes = dependentUser.MedicalNotes,
                MonthlySpendingLimit = dependentUser.MonthlySpendingLimit,
                ImageUrl = dependentUser.ImageUrl,
                Email = null,
                GuardianId = currentUserId,
                // Set audit fields manually to ensure UTC DateTime
                CreationDate = _currentTime.GetCurrentTime(),
                ModificationDate = _currentTime.GetCurrentTime(),
                CreatedById = currentUserId,
                ModificationById = currentUserId,
                IsDeleted = false
            };

            var tempPassword = "SilverCart2025@";

            var result = await _userManager.CreateAsync(user, tempPassword);
            if (!result.Succeeded)
                throw new AppExceptions(result.Errors.FirstOrDefault()?.Description ?? "Lỗi khi tạo người dùng phụ thuộc");

            await _userManager.AddToRoleAsync(user, "DependentUser");
            
            await transaction.CommitAsync(cancellationToken);
            return user.Id;
        }
        catch (System.Exception)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}