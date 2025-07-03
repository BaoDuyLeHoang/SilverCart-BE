using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Features.Messages.Commands.Update;

public sealed record UpdateMessageCommand(Guid MessageId, string NewContent) : IRequest<UpdateMessageResponse>;
public record UpdateMessageResponse(Guid MessageId, string Content);
public class UpdateMessageHandler(ICurrentTime currentTime, IClaimsService claimsService, IUnitOfWork unitOfWork) : IRequestHandler<UpdateMessageCommand, UpdateMessageResponse>
{
    private readonly ICurrentTime _currentTime = currentTime;
    private readonly IClaimsService _claimsService = claimsService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<UpdateMessageResponse> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
    {
        var currentUserId = _claimsService.CurrentUserId;
        if (currentUserId == Guid.Empty)
        {
            throw new AppExceptions("User is not authenticated.");
        }
        var updatedMessage = await _unitOfWork.MessageRepository.GetByIdAsync(request.MessageId);
        if (updatedMessage == null)
        {
            throw new AppExceptions("Message not found.");
        }
        var checkPermission = await _unitOfWork.MessageRepository.CanUserAccessMessageAsync(request.MessageId, currentUserId);
        if (!checkPermission)
        {
            throw new AppExceptions("You do not have permission to update this message.");
        }
        await _unitOfWork.MessageRepository.UpdateMessageAsync(request.MessageId, request.NewContent);
        return new UpdateMessageResponse(request.MessageId, request.NewContent);
    }
}
