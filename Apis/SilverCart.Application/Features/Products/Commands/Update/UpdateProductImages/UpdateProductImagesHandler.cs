using AutoMapper;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProductImages
{
    public class UpdateProductImagesHandler(IUnitOfWork unitOfWork, IFirebaseFileService firebaseFileService) : IRequestHandler<UpdateProductImagesCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IFirebaseFileService _firebaseFileService = firebaseFileService;

        public async Task<bool> Handle(UpdateProductImagesCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Lấy ảnh cần cập nhật
                var images = await _unitOfWork.ProductImageRepository.GetAllAsync(
                    predicate: x => x.Id == request.ImageId,
                    include: source => source
                        .Include(x => x.Product)
                        .Include(x => x.ProductItem)
                );
                var image = images.FirstOrDefault();

                if (image == null)
                    throw new AppExceptions($"Không tìm thấy ảnh với ID '{request.ImageId}'");

                // Kiểm tra Product nếu có ProductId
                if (request.ProductId.HasValue)
                {
                    var products = await _unitOfWork.ProductRepository.GetAllAsync(
                        predicate: x => x.Id == request.ProductId.Value
                    );
                    if (!products.Any())
                        throw new AppExceptions($"Sản phẩm với ID '{request.ProductId}' không tồn tại.");
                }

                // Kiểm tra ProductItem nếu có ProductItemId
                if (request.ProductItemId.HasValue)
                {
                    var productItems = await _unitOfWork.ProductItemRepository.GetAllAsync(
                        predicate: x => x.Id == request.ProductItemId.Value
                    );
                    if (!productItems.Any())
                        throw new AppExceptions($"ProductItem với ID '{request.ProductItemId}' không tồn tại.");
                }

                // Cập nhật thông tin ảnh
                if (request.Image != null)
                {
                    // Upload ảnh mới và cập nhật đường dẫn
                    var imageUrl = await _firebaseFileService.UploadFIleAsync(request.Image, "products");
                    image.ImagePath = imageUrl;
                    image.ImageName = request.Image.FileName;
                }

                // Cập nhật các thông tin khác
                image.ProductId = request.ProductId;
                image.ProductItemId = request.ProductItemId;
                image.IsMain = request.IsMain;
                image.Order = request.Order;

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