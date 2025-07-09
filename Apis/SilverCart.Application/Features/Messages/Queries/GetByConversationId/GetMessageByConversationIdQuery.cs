using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SilverCart.Domain.Entities.Chat;

namespace Infrastructures.Features.Messages.Queries.GetByConversationId
{
    public sealed record GetMessageByConversationIdQuery(Guid ConversationId) : IRequest<List<MessageDto>>;
    public class GetMessageByConversationIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetMessageByConversationIdQuery, List<MessageDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<List<MessageDto>> Handle(GetMessageByConversationIdQuery request, CancellationToken cancellationToken)
        {
            var messages = await _unitOfWork.MessageRepository.GetMessagesByConversationIdAsync(request.ConversationId);
            return messages;
        }
    }
}