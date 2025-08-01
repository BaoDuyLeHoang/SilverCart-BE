using SilverCart.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace SilverCart.Domain.Entities.Chat
{
    public class Conversation : BaseEntity, IAuditableEntity
    {
        public string Name { get; set; } // Optional: group chat name
        public ICollection<ConversationMember> Members { get; set; } = new List<ConversationMember>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public DateTime? LastMessageAt { get; set; }
        public string LastMessage { get; set; } = string.Empty;
    }
}