using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Infrastructures.Features.Conversations.Queries.GetByUserId
{
    public sealed record GetConversationByUserIdQuery(Guid UserId) : IRequest<GetConversationByUserIdResponse>;
    public record GetConversationByUserIdResponse(List<ConversationDto> Conversations);
    public record ConversationDto(Guid Id, string Name, string LastMessage, DateTime LastMessageTime);
    public class GetConversationByUserIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetConversationByUserIdQuery, GetConversationByUserIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<GetConversationByUserIdResponse> Handle(GetConversationByUserIdQuery request, CancellationToken cancellationToken)
        {
            var conversations = await _unitOfWork.ConversationRepository.GetConversationsByUserIdAsync(request.UserId);

            var conversationDtos = conversations.Select(c =>
            {
                var partnerName = c.User1Id == request.UserId ? c.User2Name : c.User1Name;

                return new ConversationDto(
                    c.Id,
                    partnerName,
                    c.LastMessage,
                    c.LastMessageAt ?? DateTime.MinValue
                );
            }).ToList();

            return new GetConversationByUserIdResponse(conversationDtos);
        }
    }
}

