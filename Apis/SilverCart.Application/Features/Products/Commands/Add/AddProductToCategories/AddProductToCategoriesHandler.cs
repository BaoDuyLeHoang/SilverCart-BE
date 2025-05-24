using MediatR;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Products.Commands.Add.AddProductToCategories
{
    public sealed record AddProductToCategoriesCommand(Guid ProductId, List<Guid> CategoryIds) : IRequest<Guid>;
    public class AddProductToCategoriesHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddProductToCategoriesCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Guid> Handle(AddProductToCategoriesCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductId);
            if (product == null)
                throw new Exception("Product not found");

            var existingCategories = await _unitOfWork.CategoryRepository
                .GetAllAsync(c => request.CategoryIds.Contains(c.Id));

            var productCategories = request.CategoryIds.Select(cid => new ProductCategory
            {
                ProductId = request.ProductId,
                CategoryId = cid
            }).ToList();

            await _unitOfWork.ProductCategoryRepository.AddRangeAsync(productCategories);
            await _unitOfWork.SaveChangeAsync();
            return request.ProductId;
        }
    }
}
