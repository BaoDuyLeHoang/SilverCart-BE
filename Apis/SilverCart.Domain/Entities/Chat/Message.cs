using SilverCart.Domain.Common.Interfaces;
using System;

namespace SilverCart.Domain.Entities.Chat
{
    public class Message : BaseEntity, IAuditableEntity
    {
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public Guid SenderId { get; set; }
        public BaseUser Sender { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; } = false;
        public bool IsModified { get; set; } = false;
    }
}