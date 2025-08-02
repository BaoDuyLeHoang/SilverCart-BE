using FluentValidation;
using System;

namespace Infrastructures.Features.Stores.Commands.Update.UpdateStore
{
    public class UpdateStoreValidator : AbstractValidator<UpdateStoreCommand>
    {
        public UpdateStoreValidator()
        {
            RuleFor(x => x.StoreName)
                .NotEmpty().WithMessage("Tên cửa hàng không được để trống.")
                .MaximumLength(100).WithMessage("Tên cửa hàng không được vượt quá 100 ký tự.");

            RuleFor(x => x.StreetAddress)
                .NotEmpty().WithMessage("Địa chỉ không được để trống.")
                .MaximumLength(200).WithMessage("Địa chỉ không được vượt quá 200 ký tự.");

            RuleFor(x => x.WardCode)
                .NotEmpty().WithMessage("Mã phường/xã không được để trống.");

            RuleFor(x => x.DistrictId)
                .GreaterThan(0).WithMessage("Mã quận/huyện không hợp lệ.");

            RuleFor(x => x.DistrictName)
                .NotEmpty().WithMessage("Tên quận/huyện không được để trống.");

            RuleFor(x => x.ProvinceName)
                .NotEmpty().WithMessage("Tên tỉnh/thành không được để trống.");

            RuleFor(x => x.Information)
                .MaximumLength(500).WithMessage("Thông tin không được vượt quá 500 ký tự.")
                .When(x => !string.IsNullOrEmpty(x.Information));

            RuleFor(x => x.AvatarPath)
                .Must(x => x == null || x.EndsWith(".jpg") || x.EndsWith(".png") || x.EndsWith(".jpeg"))
                .WithMessage("Đường dẫn ảnh không hợp lệ. Chỉ chấp nhận các định dạng .jpg, .png hoặc .jpeg.")
                .When(x => !string.IsNullOrEmpty(x.AvatarPath));
        }
    }
}