using MediatR;
using SilverCart.Domain.Entities.Chat;
using SilverCart.Application.Interfaces;
using SilverCart.Application.Interfaces.Repositories;

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