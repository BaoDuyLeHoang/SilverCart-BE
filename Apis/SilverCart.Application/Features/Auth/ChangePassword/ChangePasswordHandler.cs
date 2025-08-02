using Infrastructures.Commons.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures;

public sealed record ChangePasswordCommand(string OldPassword, string NewPassword) : IRequest<Guid>;
public class ChangePasswordHandler(IUnitOfWork unitOfWork, IClaimsService claimsService, UserManager<BaseUser> userManager) : IRequestHandler<ChangePasswordCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClaimsService _claimsService = claimsService;
    private readonly UserManager<BaseUser> _userManager = userManager;
    public async Task<Guid> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        var user = await _unitOfWork.UserRepository.GetByIdAsync(currentUserId);
        if (user == null)
        {
            throw new AppExceptions("User not found");
        }
        var userCurrentPassword = await _userManager.CheckPasswordAsync(user, request.OldPassword);
        if (!userCurrentPassword)
        {
            throw new AppExceptions("Old password is incorrect");
        }
        var result = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);
        if (!result.Succeeded)
        {
            throw new AppExceptions(result.Errors.First().Description);
        }
        await _unitOfWork.SaveChangeAsync();
        return currentUserId;
    }
}