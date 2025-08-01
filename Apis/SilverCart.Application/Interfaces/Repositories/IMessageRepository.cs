using SilverCart.Domain.Entities.Chat;

namespace SilverCart.Application.Interfaces.Repositories;

public interface IMessageRepository
{
    Task<List<MessageDto>> GetMessagesByConversationIdAsync(Guid conversationId);
    Task<List<MessageDto>> GetMessagesByConversationIdBeforeAsync(Guid conversationId, DateTime? before, int limit = 20);
    Task<List<MessageDto>> GetMessagesAfterAsync(Guid conversationId, DateTime after, int limit = 20);
    Task<List<MessageDto>> GetUnreadMessagesAsync(Guid conversationId, Guid userId);
    Task<int> CountUnreadMessagesAsync(Guid conversationId, Guid userId);
    Task<Message?> GetByIdAsync(Guid messageId);
    Task AddMessageAsync(Message message);
    Task UpdateMessageAsync(Guid messageId, string newContent);
    Task RecallMessageAsync(Guid messageId, Guid userId);
    Task MarkAsReadAsync(Guid messageId, Guid userId);
    Task<bool> CanUserAccessMessageAsync(Guid messageId, Guid userId);
    MessageDto ToDto(Message message);
}
