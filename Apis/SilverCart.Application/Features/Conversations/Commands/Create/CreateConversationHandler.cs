using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SilverCart.Application.Interfaces;

namespace Infrastructures.Features.Conversations.Commands.Create
{
    public sealed record CreateConversationCommand(Guid PartnerId) : IRequest<Guid>;
    public class CreateConversationHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<CreateConversationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IClaimsService _claimsService = claimsService;
        public async Task<Guid> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            var check = await _unitOfWork.ConversationRepository.ExistsAsync(currentUserId, request.PartnerId);
            if (check)
            {
                throw new Exception("Cuộc trò chuyện đã tồn tại");
            }
            var conversation = await _unitOfWork.ConversationRepository.CreateConversationAsync(currentUserId, request.PartnerId);
            return conversation.Id;
        }
    }
}