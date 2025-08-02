using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Reports.Queries.GetAll
{
    public class GetAllReportValidation : AbstractValidator<GetAllReportQuery>
    {
        public GetAllReportValidation()
        {
            When(x => x.PagingRequest != null, () =>
            {
                RuleFor(x => x.PagingRequest.Page)
                    .GreaterThan(0).WithMessage("Số trang phải lớn hơn 0");

                RuleFor(x => x.PagingRequest.PageSize)
                    .GreaterThan(0).WithMessage("Kích thước trang phải lớn hơn 0")
                    .LessThanOrEqualTo(100).WithMessage("Kích thước trang không được vượt quá 100");
            });
            When(x => !string.IsNullOrEmpty(x.Title), () =>
            {
                RuleFor(x => x.Title)
                    .MaximumLength(100).WithMessage("Tựa đề tìm kiếm không được vượt quá 100 ký tự");
            });

        }
    }
}
