using AutoMapper;
using Infrastructures.Features.Products.Commands.Create.CreateProduct;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SilverCart.Domain.Entities;
using SilverCart.Domain.Entities.Products;

namespace Infrastructures.Features.Products.Commands.AddProductItems
{
    public sealed record AddProductItemsCommand(Guid ProductId, CreateProductItemsRequest ProductItems) : IRequest<Guid>;
    public class AddProductItemsHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<AddProductItemsCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        public async Task<Guid> Handle(AddProductItemsCommand request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(
                predicate: x => x.Id == request.ProductId,
                include: source => source.Include(x => x.ProductItems!)
            );

            var product = products.FirstOrDefault();
            if (product is null)
                throw new KeyNotFoundException($"Product with ID '{request.ProductId}' was not found.");

            var newItem = _mapper.Map<ProductItem>(request);
            newItem.Id = Guid.NewGuid();
            newItem.ProductId = request.ProductId;
            product.ProductItems.Add(newItem);

            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveChangeAsync();

            return product.Id;
        }
    }
}
