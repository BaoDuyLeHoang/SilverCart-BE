using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using MediatR;

namespace Infrastructures.Features.Auth.GenerateQrLoginToken
{
    public sealed record GenerateQrLoginTokenCommand(Guid DependentUserId) : IRequest<GenerateQrLoginTokenResponse>;
    public sealed record GenerateQrLoginTokenResponse(string QrCodeUrl);
    public class GenerateQrLoginTokenHandler(IUnitOfWork unitOfWork, IGenerateQRCodeGeneratorService generateQRCodeGeneratorService, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<GenerateQrLoginTokenCommand, GenerateQrLoginTokenResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IGenerateQRCodeGeneratorService _generateQRCodeGeneratorService = generateQRCodeGeneratorService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        public async Task<GenerateQrLoginTokenResponse> Handle(GenerateQrLoginTokenCommand request, CancellationToken cancellationToken)
        {
            var dependentUser = await _unitOfWork.DependentUserRepository.GetByIdAsync(request.DependentUserId);
            if (dependentUser == null)
            {
                throw new AppExceptions("Không tìm thấy người dùng phụ thuộc");
            }
            var token = _jwtTokenGenerator.GenerateQrLoginToken(dependentUser.Id, 2);
            var qrCodeBase64 = _generateQRCodeGeneratorService.GenerateQRCodeBase64("example.com/api/auth/elder-login?token=" + token);
            return new GenerateQrLoginTokenResponse(qrCodeBase64);
        }
    }
}