using SilverCart.Application.Repositories;
using SilverCart.Domain.Entities.Chat;

namespace Infrastructures;

public record ConversationResponse(Guid Id, Guid User1Id, string User1Name, Guid User2Id, string User2Name, DateTime? LastMessageAt, string LastMessage);
public interface IConversationRepository : IGenericRepository<Conversation>
{
    Task<List<Conversation>> GetConversationsByUserIdAsync(Guid userId);
    Task<Conversation?> GetByIdAsync(Guid conversationId);
    Task DeleteConversationAsync(Guid conversationId);
    Task<bool> ExistsAsync(Guid userId, Guid otherUserId);
    Task<Conversation> CreateConversationAsync(List<Guid> memberUserIds);
    Task<Conversation> CreateConversationAsync(Guid userId, Guid otherUserId);
}
