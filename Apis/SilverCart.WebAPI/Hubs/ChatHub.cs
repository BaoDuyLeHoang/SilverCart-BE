using Microsoft.AspNetCore.SignalR;
using SilverCart.Domain.Entities.Chat;
using System;
using System.Threading.Tasks;
using Infrastructures;
using SilverCart.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces.Repositories;

namespace SilverCart.WebAPI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _currentTime;
        private readonly ILogger<ChatHub> _logger;
        private readonly IClaimsService _claimsService;
        private readonly AppDbContext _context;

        public ChatHub(IUnitOfWork unitOfWork, ICurrentTime currentTime, ILogger<ChatHub> logger, IClaimsService claimsService, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _logger = logger;
            _claimsService = claimsService;
            _context = context;
        }
        public Task<string> GetConnectionId()
        {
            return Task.FromResult(Context.ConnectionId);
        }

        public async Task SendMessage(Guid conversationId, string content)
        {
            _logger.LogError(Context.UserIdentifier);
            var message = new Message
            {
                ConversationId = conversationId,
                SenderId = _claimsService.CurrentUserId,
                Content = content,
                IsRead = false,
                IsModified = false
            };

            await _unitOfWork.MessageRepository.AddMessageAsync(message);
            var conversation = await _context.Conversations.FindAsync(conversationId);
            if (conversation != null)
            {
                conversation.LastMessageAt = _currentTime.GetCurrentTime();
                conversation.LastMessage = content;
                await _unitOfWork.SaveChangeAsync();
            }

            // Convert to DTO before sending to clients to avoid circular references
            var messageDto = new MessageDto
            {
                Id = message.Id,
                ConversationId = message.ConversationId,
                SenderId = message.SenderId,
                Content = message.Content,
                CreationDate = message.CreationDate ?? _currentTime.GetCurrentTime(),
                IsRead = message.IsRead,
                IsDeleted = message.IsDeleted,
                ModificationDate = message.ModificationDate,
                IsModified = message.IsModified
            };

            await Clients.Group(conversationId.ToString()).SendAsync("ReceiveMessage", messageDto);
        }

        public async Task UpdateMessage(Guid messageId, string newContent)
        {
            var userId = _claimsService.CurrentUserId;
            if (await _unitOfWork.MessageRepository.CanUserAccessMessageAsync(messageId, userId))
            {
                await _unitOfWork.MessageRepository.UpdateMessageAsync(messageId, newContent);
                var message = await _unitOfWork.MessageRepository.GetByIdAsync(messageId);
                if (message != null)
                {
                    var messageDto = new MessageDto
                    {
                        Id = message.Id,
                        ConversationId = message.ConversationId,
                        SenderId = message.SenderId,
                        Content = newContent,
                        CreationDate = message.CreationDate ?? _currentTime.GetCurrentTime(),
                        IsRead = message.IsRead,
                        IsDeleted = message.IsDeleted,
                        ModificationDate = message.ModificationDate,
                        IsModified = true
                    };

                    await Clients.Group(message.ConversationId.ToString())
                        .SendAsync("MessageUpdated", messageDto);
                }
            }
        }

        public async Task RecallMessage(Guid messageId)
        {
            var userId = _claimsService.CurrentUserId;
            if (await _unitOfWork.MessageRepository.CanUserAccessMessageAsync(messageId, userId))
            {
                await _unitOfWork.MessageRepository.RecallMessageAsync(messageId, userId);
                var message = await _unitOfWork.MessageRepository.GetByIdAsync(messageId);
                if (message != null)
                {
                    var messageDto = new MessageDto
                    {
                        Id = message.Id,
                        ConversationId = message.ConversationId,
                        SenderId = message.SenderId,
                        Content = message.Content,
                        CreationDate = message.CreationDate ?? _currentTime.GetCurrentTime(),
                        IsRead = message.IsRead,
                        IsDeleted = true,
                        ModificationDate = message.ModificationDate,
                        IsModified = message.IsModified
                    };

                    await Clients.Group(message.ConversationId.ToString())
                        .SendAsync("MessageRecalled", messageDto);
                }
            }
        }

        public async Task LoadMoreMessages(Guid conversationId, DateTime? before = null, int limit = 20)
        {
            var messages = await _unitOfWork.MessageRepository
                .GetMessagesByConversationIdBeforeAsync(conversationId, before, limit);
            await Clients.Caller.SendAsync("MoreMessagesLoaded", messages);
        }

        public async Task LoadNewMessages(Guid conversationId, DateTime after)
        {
            var messages = await _unitOfWork.MessageRepository
                .GetMessagesAfterAsync(conversationId, after);
            await Clients.Caller.SendAsync("NewMessagesLoaded", messages);
        }

        public async Task GetUnreadMessages(Guid conversationId)
        {
            var userId = _claimsService.CurrentUserId;
            var unreadMessages = await _unitOfWork.MessageRepository
                .GetUnreadMessagesAsync(conversationId, userId);
            var unreadCount = await _unitOfWork.MessageRepository
                .CountUnreadMessagesAsync(conversationId, userId);

            await Clients.Caller.SendAsync("UnreadMessagesReceived", unreadMessages, unreadCount);
        }

        public async Task CreateConversation(Guid otherUserId)
        {
            var userId = _claimsService.CurrentUserId;

            if (!await _unitOfWork.ConversationRepository.ExistsAsync(userId, otherUserId))
            {
                var conversation = await _unitOfWork.ConversationRepository
                    .CreateConversationAsync(userId, otherUserId);
                await _unitOfWork.SaveChangeAsync();

                var otherUserConnections = Clients.User(otherUserId.ToString());
                if (otherUserConnections != null)
                {
                    await otherUserConnections.SendAsync("ConversationCreated", conversation);
                    await Groups.AddToGroupAsync(Context.ConnectionId, conversation.Id.ToString());
                }
            }
        }

        public async Task DeleteConversation(Guid conversationId)
        {
            var userId = _claimsService.CurrentUserId;
            var conversation = await _unitOfWork.ConversationRepository.GetByIdAsync(conversationId);

            if (conversation != null && (conversation.Members.Any(m => m.UserId == userId)))
            {
                await _unitOfWork.ConversationRepository.DeleteConversationAsync(conversationId);

                await Clients.Group(conversationId.ToString())
                    .SendAsync("ConversationDeleted", conversationId);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString());
            }
        }

        public async Task JoinConversation(Guid conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
            _logger.LogInformation($"Connection {Context.ConnectionId} joined conversation {conversationId}");
        }

        public async Task LeaveConversation(Guid conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString());
            _logger.LogInformation($"Connection {Context.ConnectionId} left conversation {conversationId}");
        }

        public async Task MarkAsRead(Guid messageId)
        {
            var userId = _claimsService.CurrentUserId;
            await _unitOfWork.MessageRepository.MarkAsReadAsync(messageId, userId);

            var message = await _unitOfWork.MessageRepository.GetByIdAsync(messageId);
            if (message != null)
            {
                var messageDto = new MessageDto
                {
                    Id = message.Id,
                    ConversationId = message.ConversationId,
                    SenderId = message.SenderId,
                    Content = message.Content,
                    CreationDate = message.CreationDate ?? _currentTime.GetCurrentTime(),
                    IsRead = true,
                    IsDeleted = message.IsDeleted,
                    ModificationDate = message.ModificationDate,
                    IsModified = message.IsModified
                };

                await Clients.Group(message.ConversationId.ToString())
                    .SendAsync("MessageRead", messageDto);
            }
        }

        public override async Task OnConnectedAsync()
        {
            var userIdFromClaimsService = _claimsService.CurrentUserId;
            var userIdString = Context.User?.FindFirst("UserId")?.Value;

            _logger.LogInformation($"ClaimsService UserId: {userIdFromClaimsService}");
            _logger.LogInformation($"Context.UserIdentifier: {Context.UserIdentifier}");
            _logger.LogInformation($"User Claims: {string.Join(", ", Context.User.Claims.Select(c => $"{c.Type}: {c.Value}"))}");

            if (Guid.TryParse(userIdString, out var userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, userIdString);
                _logger.LogInformation($"User {userIdFromClaimsService} connected with connection {Context.ConnectionId}");
            }

            await base.OnConnectedAsync();
        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if (exception != null)
            {
                _logger.LogError(exception, $"Connection {Context.ConnectionId} disconnected with error.");
            }
            else
            {
                _logger.LogInformation($"Connection {Context.ConnectionId} disconnected gracefully.");
            }
            var userId = _claimsService.CurrentUserId;
            if (userId != null)
            {
                var conversations = await _unitOfWork.ConversationRepository
                    .GetConversationsByUserIdAsync(userId);

                foreach (var conversation in conversations)
                {
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversation.Id.ToString());
                }
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}