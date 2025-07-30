using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructures.Interfaces.Repositories;
using SilverCart.Domain.Entities;
using SilverCart.Application.Interfaces;
using Infrastructures.Interfaces.System;
namespace Infrastructures.Features.Reports.Command.Add
{

    public class AddReportHandler : IRequestHandler<AddReportCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;
        private readonly IFirebaseFileService _uploadFileService;
        public AddReportHandler(IUnitOfWork unitOfWork, ICurrentTime currentTime, IFirebaseFileService uploadFileService)
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _uploadFileService = uploadFileService;
        }
        public async Task<Guid> Handle(AddReportCommand request, CancellationToken cancellationToken)
        {
            string filePath = await _uploadFileService.UploadFIleAsync(request.File, "Reports");
            var newReport = new Report
            {
                Title = request.Title,
                Description = request.Content,
                CreationDate = _currentTime.GetCurrentTime(),
                FilePath = filePath,
                CreatedById = null, // Assuming you will set this later or handle it in the repository
            };
            await _unitOfWork.ReportRepository.AddAsync(newReport);
            int i = await _unitOfWork.SaveChangeAsync();
            if (i > 0)
            {
                return newReport.Id;
            }
            return Guid.Empty;
        }
    }
}
