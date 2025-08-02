using AutoMapper;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using Infrastructures.Interfaces.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Delete.DeleteProductImage
{
    public class DeleteProductImageHandler(IUnitOfWork unitOfWork, IFirebaseFileService firebaseFileService) : IRequestHandler<DeleteProductImageCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IFirebaseFileService _firebaseFileService = firebaseFileService;

        public async Task<bool> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            // Lấy ảnh cần xóa
            var images = await _unitOfWork.ProductImageRepository.GetAllAsync(
                predicate: x => x.Id == request.ImageId
            );
            var image = images.FirstOrDefault();

            if (image == null)
                throw new AppExceptions($"Không tìm thấy ảnh với ID '{request.ImageId}'");
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Xóa file trên Firebase Storage
                if (!string.IsNullOrEmpty(image.ImagePath))
                {
                    try
                    {
                        await _firebaseFileService.DeleteFileAsync(image.ImagePath);
                    }
                    catch
                    {
                        // Log lỗi nhưng vẫn tiếp tục xóa record trong DB
                        // TODO: Add logging
                    }
                }

                // Xóa record trong DB
                _unitOfWork.ProductImageRepository.HardRemove(image);
                await _unitOfWork.SaveChangeAsync();
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}