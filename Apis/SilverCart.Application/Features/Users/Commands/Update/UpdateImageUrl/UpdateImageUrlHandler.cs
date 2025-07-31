using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;

namespace Infrastructures.Features.Users.Commands.Update.UpdateImageUrl;

public class UpdateImageUrlHandler : IRequestHandler<UpdateImageUrlCommand, UpdateImageUrlResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimsService _claimsService;
    private readonly IFirebaseFileService _firebaseFileService;

    public UpdateImageUrlHandler(
        IUnitOfWork unitOfWork,
        IClaimsService claimsService,
        IFirebaseFileService firebaseFileService)
    {
        _unitOfWork = unitOfWork;
        _claimsService = claimsService;
        _firebaseFileService = firebaseFileService;
    }

    public async Task<UpdateImageUrlResponse> Handle(UpdateImageUrlCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;

        // Tìm user hiện tại
        var user = await _unitOfWork.UserRepository.GetByIdAsync(currentUserId);
        if (user == null)
            throw new AppExceptions("Không tìm thấy user.");

        // Bắt đầu transaction
        var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
        try
        {
            // Upload ảnh lên Firebase
            var imageUrl = await _firebaseFileService.UploadFIleAsync(request.ImageFile, "user-avatars");

            // Cập nhật ImageUrl cho user
            user.ImageUrl = imageUrl;
            _unitOfWork.UserRepository.Update(user);

            // Lưu thay đổi
            await _unitOfWork.SaveChangeAsync(cancellationToken);

            // Commit transaction
            await transaction.CommitAsync(cancellationToken);

            return new UpdateImageUrlResponse(
                user.Id,
                user.FullName,
                user.ImageUrl,
                user.Gender,
                user.CreationDate ?? DateTime.UtcNow,
                user.ModificationDate ?? DateTime.UtcNow
            );
        }
        catch (Exception)
        {
            // Rollback transaction nếu có lỗi
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}