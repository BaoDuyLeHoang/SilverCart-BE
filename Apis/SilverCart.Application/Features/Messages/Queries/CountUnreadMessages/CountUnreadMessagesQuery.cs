using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Messages.Queries.CountUnreadMessages;
public sealed record CountUnreadMessagesQuery(Guid ConversationId) : IRequest<int>;
public class CountUnreadMessagesQueryHandler(IUnitOfWork unitOfWork, IClaimsService claimsService) : IRequestHandler<CountUnreadMessagesQuery, int>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClaimsService _claimsService = claimsService;
    public async Task<int> Handle(CountUnreadMessagesQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
        {
            throw new AppExceptions("User is not authenticated.");
        }
        return await _unitOfWork.MessageRepository.CountUnreadMessagesAsync(request.ConversationId, currentUserId);
    }
}
