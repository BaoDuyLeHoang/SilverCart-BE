using FluentValidation;
using Infrastructures.Features.Categories.Commands.Update.UpdateCategory;

namespace SilverCart.Application.Features.Categories.Commands.Update.UpdateCategory
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID danh mục không được để trống");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên danh mục không được để trống")
                .MaximumLength(100).WithMessage("Tên danh mục không được vượt quá 100 ký tự");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Trạng thái không hợp lệ");
        }
    }
}