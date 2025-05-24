using Infrastructures.Commons.Exceptions;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Chat;

namespace Infrastructures;

public class MessageRepository(AppDbContext context, ICurrentTime currentTime) : IMessageRepository
{
    private readonly AppDbContext _context = context;
    private readonly ICurrentTime _currentTime = currentTime;

    public async Task AddMessageAsync(Message message)
    {
        await _context.Messages.AddAsync(message);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> CanUserAccessMessageAsync(Guid messageId, Guid userId)
    {
        var message = await _context.Messages.FindAsync(messageId);
        if (message == null)
        {
            throw new AppExceptions("Message not found");
        }
        return message.SenderId == userId;
    }

    public async Task<int> CountUnreadMessagesAsync(Guid conversationId, Guid userId)
    {
        return await _context.Messages.CountAsync(m => m.ConversationId == conversationId && m.SenderId != userId && !m.IsRead);
    }
    public async Task<Message?> GetByIdAsync(Guid messageId)
    {
        return await _context.Messages.FindAsync(messageId);
    }

    public async Task<List<Message>> GetMessagesAfterAsync(Guid conversationId, DateTime after, int limit = 20)
    {
        return await _context.Messages.Where(m => m.ConversationId == conversationId && m.CreationDate > after).OrderBy(m => m.CreationDate).Take(limit).ToListAsync();
    }

    public async Task<List<Message>> GetMessagesByConversationIdAsync(Guid conversationId)
    {
        return await _context.Messages.Where(m => m.ConversationId == conversationId).OrderBy(m => m.CreationDate).ToListAsync();
    }

    public async Task<List<Message>> GetMessagesByConversationIdBeforeAsync(Guid conversationId, DateTime? before, int limit = 20)
    {
        return await _context.Messages.Where(m => m.ConversationId == conversationId && m.CreationDate < before).OrderBy(m => m.CreationDate).Take(limit).ToListAsync();
    }

    public async Task<List<Message>> GetUnreadMessagesAsync(Guid conversationId, Guid userId)
    {
        return await _context.Messages.Where(m => m.ConversationId == conversationId && m.SenderId != userId && !m.IsRead).OrderBy(m => m.CreationDate).ToListAsync();
    }

    public async Task MarkAsReadAsync(Guid messageId, Guid userId)
    {
        var message = await _context.Messages.FindAsync(messageId);
        if (message == null)
        {
            throw new AppExceptions("Message not found");
        }
        message.IsRead = true;
        await _context.SaveChangesAsync();
    }

    public async Task RecallMessageAsync(Guid messageId, Guid userId)
    {
        var message = await _context.Messages.FindAsync(messageId);
        if (message == null)
        {
            throw new AppExceptions("Message not found");
        }
        message.IsDeleted = true;
        message.DeletionDate = _currentTime.GetCurrentTime();
    }

    public async Task UpdateMessageAsync(Guid messageId, string newContent)
    {
        var message = await _context.Messages.FindAsync(messageId);
        if (message == null)
        {
            throw new AppExceptions("Message not found");
        }
        message.Content = newContent;
        message.ModificationDate = _currentTime.GetCurrentTime();
        message.IsModified = true;
        await _context.SaveChangesAsync();
    }

}