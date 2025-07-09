using MediatR;
using SilverCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Consultation.ConsultationReport.Update
{
    public sealed record UpdateConsultationReportCommand(
        Guid ConsultationId,
        string ReportContent,
        string? VideoRecordingUrl = null,
        string? Notes = null,
        bool IsComplete = false) : IRequest<bool>;

    public class UpdateConsultationReportHandler(
        IUnitOfWork unitOfWork,
        ICurrentTime currentTime
    ) : IRequestHandler<UpdateConsultationReportCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentTime _currentTime = currentTime;

        public async Task<bool> Handle(UpdateConsultationReportCommand request, CancellationToken cancellationToken)
        {
            var consultation = await _unitOfWork.ConsultationRepository.GetByIdAsync(request.ConsultationId);

            if (consultation is null)
            {
                throw new KeyNotFoundException($"Order item with ID '{request.ConsultationId}' not found.");
             }

            consultation.Notes = request.Notes;
            consultation.UpdatedAt = _currentTime.GetCurrentTime();
            consultation.IsCompleted = request.IsComplete;
            _unitOfWork.ConsultationRepository.Update(consultation);
            await _unitOfWork.SaveChangeAsync();

            return true;
        }
    }
}
