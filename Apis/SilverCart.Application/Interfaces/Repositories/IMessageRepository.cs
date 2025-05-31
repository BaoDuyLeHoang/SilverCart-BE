using SilverCart.Domain.Entities.Chat;

namespace Infrastructures;

public interface IMessageRepository
{
    Task<List<Message>> GetMessagesByConversationIdAsync(Guid conversationId);
    Task<List<Message>> GetMessagesByConversationIdBeforeAsync(Guid conversationId, DateTime? before, int limit = 20);
    Task<List<Message>> GetMessagesAfterAsync(Guid conversationId, DateTime after, int limit = 20);
    Task<List<Message>> GetUnreadMessagesAsync(Guid conversationId, Guid userId);
    Task<int> CountUnreadMessagesAsync(Guid conversationId, Guid userId);
    Task<Message?> GetByIdAsync(Guid messageId);
    Task AddMessageAsync(Message message);
    Task UpdateMessageAsync(Guid messageId, string newContent);
    Task RecallMessageAsync(Guid messageId, Guid userId);
    Task MarkAsReadAsync(Guid messageId, Guid userId);
    Task<bool> CanUserAccessMessageAsync(Guid messageId, Guid userId);
}
