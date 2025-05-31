using Infrastructures;
using Infrastructures.Commons.Exceptions;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Chat;

public class ConversationRepository(AppDbContext context, ICurrentTime currentTime) : IConversationRepository
{
    private readonly AppDbContext _context = context;
    private readonly ICurrentTime _currentTime = currentTime;
    public async Task<Conversation> CreateConversationAsync(Guid user1Id, Guid user2Id)
    {
        var conversation = new Conversation
        {
            User1Id = user1Id,
            User2Id = user2Id
        };

        await _context.Conversations.AddAsync(conversation);
        return conversation;
    }

    public async Task DeleteConversationAsync(Guid conversationId)
    {
        var existedConversation = await _context.Conversations.FindAsync(conversationId);
        if (existedConversation == null)
        {
            throw new AppExceptions("Conversation not found");
        }
        existedConversation.IsDeleted = true;
        existedConversation.DeletionDate = _currentTime.GetCurrentTime();
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid user1Id, Guid user2Id)
    {
        return await _context.Conversations.AnyAsync(c => c.User1Id == user1Id && c.User2Id == user2Id);
    }

    public async Task<Conversation?> GetByIdAsync(Guid conversationId)
    {
        return await _context.Conversations.FindAsync(conversationId);
    }

    public async Task<List<Conversation>> GetConversationsByUserIdAsync(Guid userId)
    {
        return await _context.Conversations.Where(c => c.User1Id == userId || c.User2Id == userId).ToListAsync();
    }
}


