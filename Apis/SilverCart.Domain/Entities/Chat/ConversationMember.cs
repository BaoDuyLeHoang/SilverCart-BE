namespace SilverCart.Domain.Entities.Chat
{
    public class ConversationMember : BaseEntity
    {
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }

        public Guid UserId { get; set; }
        public BaseUser User { get; set; }

        // Optionally: Role, JoinedAt, etc.
    }
}