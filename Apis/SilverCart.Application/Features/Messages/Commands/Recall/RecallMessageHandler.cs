using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Messages.Commands.Recall;

public sealed record RecallMessageCommand(Guid MessageId) : IRequest<RecallMessageResponse>;
public record RecallMessageResponse(Guid MessageId, string Status);
public class RecallMessageHandler(IUnitOfWork unitOfWork, ICurrentTime currentTime, IClaimsService claimsService) : IRequestHandler<RecallMessageCommand, RecallMessageResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ICurrentTime _currentTime = currentTime;
    private readonly IClaimsService _claimsService = claimsService;
    public async Task<RecallMessageResponse> Handle(RecallMessageCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
        {
            throw new AppExceptions("User is not authenticated.");
        }
        var message = await _unitOfWork.MessageRepository.GetByIdAsync(request.MessageId);
        if (message == null)
        {
            throw new AppExceptions("Message not found.");
        }
        var canAccess = await _unitOfWork.MessageRepository.CanUserAccessMessageAsync(request.MessageId, currentUserId);
        if (!canAccess)
        {
            throw new AppExceptions("You do not have permission to recall this message.");
        }
        if (message.SenderId != currentUserId)
        {
            throw new AppExceptions("You do not have permission to recall this message.");
        }
        await _unitOfWork.MessageRepository.RecallMessageAsync(request.MessageId, currentUserId);

        return new RecallMessageResponse(request.MessageId, "Message recalled successfully.");
    }
}
