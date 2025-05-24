using SilverCart.Domain.Entities.Chat;

namespace Infrastructures;

public interface IConversationRepository
{
    Task<List<Conversation>> GetConversationsByUserIdAsync(Guid userId);
    Task<Conversation> CreateConversationAsync(Guid user1Id, Guid user2Id);
    Task<Conversation?> GetByIdAsync(Guid conversationId);
    Task DeleteConversationAsync(Guid conversationId);
    Task<bool> ExistsAsync(Guid user1Id, Guid user2Id);
}
