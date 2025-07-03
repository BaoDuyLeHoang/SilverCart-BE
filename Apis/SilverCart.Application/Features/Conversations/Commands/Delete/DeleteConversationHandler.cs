using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Infrastructures.Features.Conversations.Commands.Delete
{
    public sealed record DeleteConversationCommand(Guid ConversationId) : IRequest<bool>;
    public class DeleteConversationHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteConversationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<bool> Handle(DeleteConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _unitOfWork.ConversationRepository.GetByIdAsync(request.ConversationId);
            if (conversation == null)
            {
                throw new Exception("Conversation not found");
            }
            await _unitOfWork.ConversationRepository.DeleteConversationAsync(request.ConversationId);
            await _unitOfWork.SaveChangeAsync();
            return true;
        }
    }
}