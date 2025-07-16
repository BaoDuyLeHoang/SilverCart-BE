using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using SilverCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Consultation.ConsultationReport
{
    public sealed record CreateConsultationReportCommand(
    Guid ConsultationId,
    string ReportContent,
    bool IsDraft,
    string? VideoRecordingUrl = null,
    string? Notes = null
) : IRequest<bool>;
    public class CreateConsultationReportHandler(
       IUnitOfWork unitOfWork,
       ICurrentTime currentTime
   ) : IRequestHandler<CreateConsultationReportCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentTime _currentTime = currentTime;

        public async Task<bool> Handle(CreateConsultationReportCommand request, CancellationToken cancellationToken)
        {
            var consultation = await _unitOfWork.ConsultationRepository.GetDetailsById(request.ConsultationId);
            if (consultation is null)
                throw new KeyNotFoundException("Consultation not found");

            consultation.ReportContent = request.ReportContent;
            consultation.VideoRecordingUrl = request.VideoRecordingUrl;
            consultation.Notes = request.Notes;
            consultation.ModificationDate = _currentTime.GetCurrentTime();
            consultation.IsCompleted = !request.IsDraft;

            _unitOfWork.ConsultationRepository.Update(consultation);
            await _unitOfWork.SaveChangeAsync();

            return true;
        }
    }
}
