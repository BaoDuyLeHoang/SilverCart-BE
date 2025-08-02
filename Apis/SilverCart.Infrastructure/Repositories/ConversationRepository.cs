using Infrastructures;
using Infrastructures.Commons.Exceptions;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Chat;

namespace Infrastructures.Repositories;

public class ConversationRepository : GenericRepository<Conversation>, IConversationRepository
{
    private new readonly AppDbContext _context;
    public ConversationRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    // Create a new conversation with members
    public async Task<Conversation> CreateConversationAsync(Guid userId, Guid otherUserId)
    {
        return await CreateConversationAsync(new List<Guid> { userId, otherUserId });
    }
    public async Task<Conversation> CreateConversationAsync(List<Guid> memberUserIds)
    {
        var conversation = new Conversation();
        await _context.Conversations.AddAsync(conversation);
        // ❌ Loại bỏ SaveChangesAsync đầu tiên - để UnitOfWork xử lý

        foreach (var userId in memberUserIds)
        {
            var member = new ConversationMember
            {
                ConversationId = conversation.Id,
                UserId = userId
            };
            await _context.ConversationMembers.AddAsync(member);
        }
        // ❌ Loại bỏ SaveChangesAsync thứ hai - để UnitOfWork xử lý
        return conversation;
    }

    // Get all conversations for a user
    public async Task<List<Conversation>> GetConversationsByUserIdAsync(Guid userId)
    {
        return await _context.ConversationMembers
            .Where(cm => cm.UserId == userId)
            .Include(cm => cm.Conversation)
            .Select(cm => cm.Conversation)
            .Distinct()
            .ToListAsync();
    }

    // Delete a conversation
    public async Task DeleteConversationAsync(Guid conversationId)
    {
        var conversation = await _context.Conversations.FindAsync(conversationId);
        if (conversation == null)
            throw new AppExceptions("Conversation not found");
        _context.Conversations.Remove(conversation);
        // ❌ Loại bỏ SaveChangesAsync - để UnitOfWork xử lý
    }

    // Get conversation by Id (with members)
    public async Task<Conversation?> GetByIdAsync(Guid conversationId)
    {
        return await _context.Conversations
            .Include(c => c.Members)
            .Include(c => c.Messages)
            .FirstOrDefaultAsync(c => c.Id == conversationId);
    }

    public async Task<bool> ExistsAsync(Guid userId, Guid otherUserId)
    {
        return await _context.ConversationMembers
            .AnyAsync(cm => cm.UserId == userId && cm.ConversationId == otherUserId);
    }


}
