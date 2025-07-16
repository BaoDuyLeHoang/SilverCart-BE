using AutoMapper;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;

namespace Infrastructures.Features.Products.Commands.AddProductItems
{
    public sealed record AddProductItemsToVariantCommand(Guid ProductId, Guid VariantId, CreateProductItemsRequest ProductItems) : IRequest<Guid>;
    public class AddProductItemsToVariantHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddProductItemsToVariantCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task<Guid> Handle(AddProductItemsToVariantCommand request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductId,
                include: source => source.Include(x => x.Variants!)
                                          .ThenInclude(v => v.ProductItems!)
            );

            var product = products.FirstOrDefault();
            if (product is null)
                throw new KeyNotFoundException($"Product with ID '{request.ProductId}' was not found.");

            var variant = product.Variants.FirstOrDefault(v => v.Id == request.VariantId);
            if (variant is null)
                throw new KeyNotFoundException($"Variant with ID '{request.VariantId}' was not found in product '{request.ProductId}'.");

            var newItem = _mapper.Map<ProductItem>(request);
            newItem.Id = Guid.NewGuid();
            newItem.VariantId = request.VariantId;
            variant.ProductItems.Add(newItem);

            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangeAsync();

            return product.Id;
        }
    }
}
