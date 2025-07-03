using Infrastructures.Commons.Exceptions;
using MediatR;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Chat;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructures.Features.Messages.Commands.Create
{
    public sealed record CreateMessageCommand(Guid ConversationId, string Content) : IRequest<CreateMessageResponse>;
    public record CreateMessageResponse(MessageDto Message);
    public class CreateMessageHandler : IRequestHandler<CreateMessageCommand, CreateMessageResponse>
    {
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;

        public CreateMessageHandler(IClaimsService claimsService, IUnitOfWork unitOfWork, ICurrentTime currentTime)
        {
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
        }

        public async Task<CreateMessageResponse> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _claimsService.CurrentUserId;
            if (currentUserId == Guid.Empty)
            {
                throw new AppExceptions("User is not authenticated.");
            }

            var message = new Message
            {
                ConversationId = request.ConversationId,
                SenderId = currentUserId,
                Content = request.Content,
                CreationDate = _currentTime.GetCurrentTime(),
                IsRead = false
            };

            await _unitOfWork.MessageRepository.AddMessageAsync(message);

            var messageDto = _unitOfWork.MessageRepository.ToDto(message); // dùng static helper có sẵn

            return new CreateMessageResponse(messageDto);
        }

    }
}
