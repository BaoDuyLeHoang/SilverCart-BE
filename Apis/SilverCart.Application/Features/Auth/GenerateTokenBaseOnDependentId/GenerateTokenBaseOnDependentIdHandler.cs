using Infrastructures.Commons.Exceptions;
using Infrastructures.Interfaces.System;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Auth.GenerateTokenBaseOnDependentId
{
    public sealed record GenerateTokenBaseOnDependentIdCommand(Guid DependentUserIds) : IRequest<GenerateTokenBaseOnDependentIdResponse>;
    public sealed record GenerateTokenBaseOnDependentIdResponse(string Token);
    public class GenerateTokenBaseOnDependentIdHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<GenerateTokenBaseOnDependentIdCommand, GenerateTokenBaseOnDependentIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
        public Task<GenerateTokenBaseOnDependentIdResponse> Handle(GenerateTokenBaseOnDependentIdCommand request, CancellationToken cancellationToken)
        {
            var existedDependentUser = _unitOfWork.DependentUserRepository.GetByIdAsync(request.DependentUserIds);
            if (existedDependentUser == null)
                throw new AppExceptions("Dependent user not found");

            var token = _jwtTokenGenerator.GenerateTokenForDependentUser(request.DependentUserIds, 15);
            return Task.FromResult(new GenerateTokenBaseOnDependentIdResponse(token));
        }
    }
}
