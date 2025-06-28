using SilverCart.Domain.Entities.Chat;

namespace Infrastructures;
public class MessageDto
{
    public Guid Id { get; set; }
    public Guid ConversationId { get; set; }
    public Guid SenderId { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsRead { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? ModificationDate { get; set; }
    public bool IsModified { get; set; }
}

public record CreateMessageRequest(Guid ConversationId, string Content);
public record CreateMessageResponse(Guid MessageId, string Content);

public record UpdateMessageRequest(Guid MessageId, string NewContent);
public record UpdateMessageResponse(Guid MessageId, string Content, DateTime ModificationDate);

public record MarkAsReadRequest(Guid MessageId);
public record MarkAsReadResponse(Guid MessageId, bool IsRead);

public record RecallMessageRequest(Guid MessageId);
public record RecallMessageResponse(Guid MessageId, bool IsDeleted, DateTime? DeletionDate);

public record GetMessagesByConversationRequest(Guid ConversationId);
public record GetMessagesByConversationResponse(List<MessageDto> Messages);

public record CountUnreadMessagesRequest(Guid ConversationId, Guid UserId);
public record CountUnreadMessagesResponse(int UnreadCount);
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
