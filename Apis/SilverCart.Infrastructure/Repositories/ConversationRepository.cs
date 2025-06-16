using Infrastructures;
using Infrastructures.Commons.Exceptions;
using Microsoft.EntityFrameworkCore;
using SilverCart.Application.Interfaces;
using SilverCart.Domain.Entities.Chat;

public class ConversationRepository(AppDbContext context, ICurrentTime currentTime) : IConversationRepository
{
    private readonly AppDbContext _context = context;
    private readonly ICurrentTime _currentTime = currentTime;
    public async Task<ConversationResponse> CreateConversationAsync(Guid user1Id, Guid user2Id)
    {
        var user1 = await _context.Users.FindAsync(user1Id) 
            ?? throw new AppExceptions("User1 not found");
        var user2 = await _context.Users.FindAsync(user2Id)
            ?? throw new AppExceptions("User2 not found");

        var conversation = new Conversation
        {
            User1Id = user1Id,
            User2Id = user2Id,
            LastMessage = "",
        };

        await _context.Conversations.AddAsync(conversation);
        await _context.SaveChangesAsync();
        return new ConversationResponse(
            conversation.Id,
            conversation.User1Id,
            user1.FullName,
            conversation.User2Id,
            user2.FullName,
            conversation.LastMessageAt,
            conversation.LastMessage
        );
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
        return await _context.Conversations.AnyAsync(c =>
            (c.User1Id == user1Id && c.User2Id == user2Id) ||
            (c.User1Id == user2Id && c.User2Id == user1Id));
    }

    public async Task<ConversationResponse?> GetByIdAsync(Guid conversationId)
    {
        var conversation = await _context.Conversations
            .Include(c => c.User1)
            .Include(c => c.User2)
            .FirstOrDefaultAsync(c => c.Id == conversationId);
            
        return conversation == null ? null : new ConversationResponse(
            conversation.Id,
            conversation.User1Id,
            conversation.User1.FullName,
            conversation.User2Id,
            conversation.User2.FullName,
            conversation.LastMessageAt,
            conversation.LastMessage
        );
    }

    public async Task<List<ConversationResponse>> GetConversationsByUserIdAsync(Guid userId)
    {
        return await _context.Conversations
            .Include(c => c.User1)
            .Include(c => c.User2)
            .Where(c => c.User1Id == userId || c.User2Id == userId)
            .Select(c => new ConversationResponse(
                c.Id,
                c.User1Id,
                c.User1.FullName,
                c.User2Id,
                c.User2.FullName,
                c.LastMessageAt,
                c.LastMessage
            ))
            .ToListAsync();
    }
}


