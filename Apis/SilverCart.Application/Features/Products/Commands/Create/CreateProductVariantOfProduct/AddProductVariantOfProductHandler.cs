using AutoMapper;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Create.CreateProductVariantOfProduct
{
    public sealed record CreateProductVariantOfProductCommand(Guid ProductId, CreateProductVariants ProductVariants) : IRequest<Guid>;
    public class AddProductVariantOfProductHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateProductVariantOfProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task<Guid> Handle(CreateProductVariantOfProductCommand request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductId,
                include: source => source.Include(x => x.Variants!)
            );

            var product = products.FirstOrDefault();
            if (product is null)
                throw new KeyNotFoundException($"Product with ID '{request.ProductId}' was not found.");

            var newVariant = _mapper.Map<ProductVariant>(request);
            newVariant.Id = Guid.NewGuid();
            newVariant.ProductId = request.ProductId;
            newVariant.Items = request.ProductVariants.ProductItems?.Select(item =>
            {
                var mappedItem = _mapper.Map<ProductItem>(item);
                mappedItem.Id = Guid.NewGuid();
                mappedItem.VariantId = newVariant.Id;
                return mappedItem;
            }).ToList() ?? new();

            product.Variants.Add(newVariant);

            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangeAsync();

            return newVariant.Id;
        }
    }
}
