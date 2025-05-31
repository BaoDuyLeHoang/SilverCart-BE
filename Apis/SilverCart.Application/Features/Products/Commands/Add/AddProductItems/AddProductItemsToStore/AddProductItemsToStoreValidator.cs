using FluentValidation;
using Infrastructures.Features.Products.Commands.Add.AddProductItems.AddProductItemsToStore;

namespace SilverCart.Application.Features.Products.Commands.Add.AddProductItems.AddProductItemsToStore
{
    public class AddProductItemsToStoreValidator : AbstractValidator<AddProductItemsToStoreCommand>
    {
        public AddProductItemsToStoreValidator()
        {
            RuleFor(x => x.AddProductItemsToStores)
                .NotEmpty().WithMessage("Danh sách sản phẩm không được để trống");

            RuleForEach(x => x.AddProductItemsToStores).ChildRules(item =>
            {
                item.RuleFor(i => i.ProductItemId)
                    .NotEmpty().WithMessage("ID phiên bản sản phẩm không được để trống");

                item.RuleFor(i => i.Stock)
                    .GreaterThanOrEqualTo(0).WithMessage("Số lượng tồn kho phải lớn hơn hoặc bằng 0");
            });
        }
    }
}