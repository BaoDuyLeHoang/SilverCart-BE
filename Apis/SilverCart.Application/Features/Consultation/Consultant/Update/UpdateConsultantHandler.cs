using Infrastructures.Features.Consultation.ConsultationReport.Update;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Consultation.Consultant.Update
{
    public sealed record UpdateConsultantCommand(
        Guid ConsultantId,
        string? Email = null,
        string? Phone = null,
        string? Specialization = null,
        string? CertificationDocumentLink = null,
        string? AvatarPath = null,
        string? ExpertiseArea = null,
        string? Biography = null,
        string? StringeeAccessToken = null
    ) : IRequest<bool>;
    public class UpdateConsultantHandler(
        IUnitOfWork unitOfWork,
        ICurrentTime currentTime) : IRequestHandler<UpdateConsultantCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ICurrentTime _currentTime = currentTime;

        public async Task<bool> Handle(UpdateConsultantCommand request, CancellationToken cancellationToken)
        {
            var consultant = await _unitOfWork.ConsultantUserRepository.GetByIdAsync(request.ConsultantId);

            if (consultant is null)
            {
                throw new KeyNotFoundException($"Người dùng với ID '{request.ConsultantId}' không tồn tại.");
            }

            _unitOfWork.ConsultantUserRepository.Update(consultant);
            await _unitOfWork.SaveChangeAsync();

            return true;
        }
    }
}

