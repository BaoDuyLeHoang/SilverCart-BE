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

namespace Infrastructures.Features.Products.Commands.Add.AddProductImages
{
    public class AddProductImageHandler(IUnitOfWork unitOfWork, IFirebaseFileService firebaseFileService) : IRequestHandler<AddProductImagesCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IFirebaseFileService _firebaseFileService = firebaseFileService;

        public async Task<bool> Handle(AddProductImagesCommand request, CancellationToken cancellationToken)
        {
            // Kiểm tra ProductId hoặc ProductItemId phải có ít nhất một cái
            if (!request.ProductId.HasValue && !request.ProductItemId.HasValue)
                throw new AppExceptions("Phải chỉ định ProductId hoặc ProductItemId");

            await _unitOfWork.BeginTransactionAsync();
            try
            {
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

                foreach (var image in request.Images)
                {
                    var imageUrl = await _firebaseFileService.UploadFIleAsync(image, "products");
                    var newImage = new ProductImage
                    {
                        Id = Guid.NewGuid(),
                        ImagePath = imageUrl,
                        ImageName = image.FileName,
                        ProductId = request.ProductId,
                        ProductItemId = request.ProductItemId,
                        IsMain = request.IsMain,
                        Order = request.Order
                    };

                    await _unitOfWork.ProductImageRepository.AddAsync(newImage);
                }

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