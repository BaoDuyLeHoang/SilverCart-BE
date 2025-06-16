using AutoMapper;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Add.AddProductImages
{
    public sealed record AddProductImagesCommand(Guid ProductItemId, List<CreateProductItemImages> ProductImages) : IRequest<Guid>;
    public record CreateProductItemImages(string ImagePath, string ImageName);
    public class AddProductImageHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddProductImagesCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task<Guid> Handle(AddProductImagesCommand request, CancellationToken cancellationToken)
        {
            var productItems = await _unitOfWork.ProductItemRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductItemId,
                include: source => source.Include(x => x.ProductImages)
            );

            var productItem = productItems.FirstOrDefault();
            if (productItem == null)
                throw new AppExceptions($"Product with ID '{request.ProductItemId}' not found.");

            var newImages = _mapper.Map<List<ProductImage>>(request);
            foreach (var newImage in newImages)
            {
                newImage.Id = Guid.NewGuid();
                productItem.ProductImages.Add(newImage);
            }

            await _unitOfWork.SaveChangeAsync();
            return productItem.Id;
        }
    }
}
