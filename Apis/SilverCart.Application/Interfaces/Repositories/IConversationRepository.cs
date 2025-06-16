using SilverCart.Domain.Entities.Chat;

namespace Infrastructures;

public record ConversationResponse(Guid Id, Guid User1Id, string User1Name, Guid User2Id, string User2Name, DateTime? LastMessageAt, string LastMessage);
public interface IConversationRepository
{
    Task<List<ConversationResponse>> GetConversationsByUserIdAsync(Guid userId);
    Task<ConversationResponse> CreateConversationAsync(Guid user1Id, Guid user2Id);
    Task<ConversationResponse?> GetByIdAsync(Guid conversationId);
    Task DeleteConversationAsync(Guid conversationId);
    Task<bool> ExistsAsync(Guid user1Id, Guid user2Id);
}
