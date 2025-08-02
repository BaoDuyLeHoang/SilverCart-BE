using AutoMapper;
using MediatR;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Enums;
using SilverCart.Application.Interfaces;
using Infrastructures.Services.System;
using Infrastructures.Commons.Exceptions;
using SilverCart.Domain.Entities.Categories;
using SilverCart.Domain.Entities.Products;
using SilverCart.Application.Interfaces;

namespace Infrastructures.Features.Products.Commands.Update.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid Id,
    string? Name,
    string? Description,
    string? VideoPath,
    ProductTypeEnum? ProductType,
    List<Guid>? CategoryIds) : IRequest<bool>;

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;
        private readonly ICurrentTime _currentTime;

        public UpdateProductHandler(IUnitOfWork unitOfWork, IClaimsService claimsService, ICurrentTime currentTime)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
            _currentTime = currentTime;
        }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
            throw new AppExceptions("Người dùng không được xác thực.");

        var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.Id, x => x.ProductCategories);
        if (product == null)
            throw new AppExceptions($"Không tìm thấy sản phẩm với ID {request.Id}.");

        // Update basic product information only if new values are provided
        if (!string.IsNullOrWhiteSpace(request.Name))
        {
            product.Name = request.Name;
        }

        if (request.Description != null) // Allow empty description but not null
        {
            product.Description = request.Description;
        }

        if (request.VideoPath != null) // Allow empty video path but not null
        {
            product.VideoPath = request.VideoPath;
        }

        if (request.ProductType.HasValue)
        {
            product.ProductType = request.ProductType.Value;
        }

        // Update audit fields
        product.ModificationDate = _currentTime.GetCurrentTime();
        product.ModificationById = currentUserId;

        // Update product categories only if new categories are provided
        if (request.CategoryIds != null && request.CategoryIds.Any())
        {
            var existingCategories = product.ProductCategories;
            // Remove categories that are not in the new list
            foreach (var existingCategory in existingCategories)
            {
                if (!request.CategoryIds.Contains(existingCategory.CategoryId))
                {
                    _unitOfWork.ProductCategoryRepository.SoftRemove(existingCategory);
                }
            }

            // Add new categories
            var existingCategoryIds = existingCategories.Select(pc => pc.CategoryId);
            var newCategoryIds = request.CategoryIds.Except(existingCategoryIds);

            foreach (var categoryId in newCategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = categoryId,
                    CreationDate = _currentTime.GetCurrentTime(),
                    ModificationDate = _currentTime.GetCurrentTime(),
                    CreatedById = currentUserId,
                    ModificationById = currentUserId
                };
                await _unitOfWork.ProductCategoryRepository.AddAsync(productCategory);
            }
        }

        _unitOfWork.ProductRepository.Update(product);
        var result = await _unitOfWork.SaveChangeAsync(cancellationToken) > 0;

        return result;
    }
}