using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Consultation.ConsultationReport.Update
{
    public class UpdateConsultationReportValidator : AbstractValidator<UpdateConsultationReportCommand>
    {
        public UpdateConsultationReportValidator()
        {
            RuleFor(x => x.ConsultationId)
                .NotEmpty()
                .WithMessage("ConsultationId is required.");

            RuleFor(x => x.ReportContent)
                .NotEmpty()
                .WithMessage("Report content must not be empty.")
                .MaximumLength(5000)
                .WithMessage("Report content must not exceed 5000 characters.");

            RuleFor(x => x.VideoRecordingUrl)
                .MaximumLength(2048)
                .WithMessage("Video URL must not exceed 2048 characters.")
                .When(x => !string.IsNullOrEmpty(x.VideoRecordingUrl));

            RuleFor(x => x.Notes)
                .MaximumLength(1000)
                .WithMessage("Notes must not exceed 1000 characters.")
                .When(x => !string.IsNullOrEmpty(x.Notes));
        }
    }
}
