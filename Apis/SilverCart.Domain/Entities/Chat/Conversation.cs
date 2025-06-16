using SilverCart.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace SilverCart.Domain.Entities.Chat
{
    public class Conversation : BaseEntity, IAuditableEntity
    {
        public Guid User1Id { get; set; }
        public BaseUser User1 { get; set; }
        public Guid User2Id { get; set; }
        public BaseUser User2 { get; set; }
        public DateTime? LastMessageAt { get; set; }
        public string LastMessage { get; set; } = string.Empty;
        private readonly List<Message> _messages = new List<Message>();
        public IReadOnlyCollection<Message> Messages => _messages.AsReadOnly();
    }
}