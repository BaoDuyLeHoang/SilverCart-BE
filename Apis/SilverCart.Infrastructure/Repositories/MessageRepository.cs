using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Chat;
using Infrastructures.Commons.Exceptions;
using SilverCart.Application.Interfaces.Repositories;

namespace Infrastructures
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;
        private readonly ICurrentTime _currentTime;

        public MessageRepository(AppDbContext context, ICurrentTime currentTime)
        {
            _context = context;
            _currentTime = currentTime;
        }

        public async Task AddMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CanUserAccessMessageAsync(Guid messageId, Guid userId)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message == null)
                throw new AppExceptions("Message not found");
            return message.SenderId == userId;
        }

        public async Task<int> CountUnreadMessagesAsync(Guid conversationId, Guid userId)
        {
            return await _context.Messages
                .CountAsync(m => m.ConversationId == conversationId && m.SenderId != userId && !m.IsRead);
        }

        public async Task<Message?> GetByIdAsync(Guid messageId)
        {
            return await _context.Messages.FindAsync(messageId);
        }
        public async Task<List<MessageDto>> GetMessagesByConversationIdAsync(Guid conversationId)
        {
            var messages = await _context.Messages
                .Where(m => m.ConversationId == conversationId)
                .OrderBy(m => m.CreationDate)
                .ToListAsync();

            return messages.Select(ToDto).ToList();
        }

        public async Task<List<MessageDto>> GetMessagesAfterAsync(Guid conversationId, DateTime after, int limit = 20)
        {
            var messages = await _context.Messages
                .Where(m => m.ConversationId == conversationId && m.CreationDate > after)
                .OrderBy(m => m.CreationDate)
                .Take(limit)
                .ToListAsync();

            return messages.Select(ToDto).ToList();
        }

        public async Task<List<MessageDto>> GetMessagesByConversationIdBeforeAsync(Guid conversationId, DateTime? before, int limit = 20)
        {
            if (before == null) return new List<MessageDto>();

            var messages = await _context.Messages
                .Where(m => m.ConversationId == conversationId && m.CreationDate < before)
                .OrderBy(m => m.CreationDate)
                .Take(limit)
                .ToListAsync();

            return messages.Select(ToDto).ToList();
        }

        public async Task<List<MessageDto>> GetUnreadMessagesAsync(Guid conversationId, Guid userId)
        {
            var messages = await _context.Messages
                .Where(m => m.ConversationId == conversationId && m.SenderId != userId && !m.IsRead)
                .OrderBy(m => m.CreationDate)
                .ToListAsync();

            return messages.Select(ToDto).ToList();
        }

        public async Task MarkAsReadAsync(Guid messageId, Guid userId)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message == null)
                throw new AppExceptions("Message not found");

            message.IsRead = true;
            await _context.SaveChangesAsync();
        }

        public async Task RecallMessageAsync(Guid messageId, Guid userId)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message == null)
                throw new AppExceptions("Message not found");

            message.IsDeleted = true;
            message.DeletionDate = _currentTime.GetCurrentTime();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMessageAsync(Guid messageId, string newContent)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message == null)
                throw new AppExceptions("Message not found");

            message.Content = newContent;
            message.ModificationDate = _currentTime.GetCurrentTime();
            message.IsModified = true;
            await _context.SaveChangesAsync();
        }

        // Helper mapping từ entity sang DTO
        public MessageDto ToDto(Message message) => new()
        {
            Id = message.Id,
            ConversationId = message.ConversationId,
            SenderId = message.SenderId,
            Content = message.Content,
            CreationDate = message.CreationDate ?? DateTime.MinValue,
            IsRead = message.IsRead,
            IsDeleted = message.IsDeleted,
            ModificationDate = message.ModificationDate,
            IsModified = message.IsModified,
        };
    }
}
