using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilverCart.Domain.Entities.Chat;
using Humanizer;

public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>, IEntityTypeConfiguration<ConversationMember>, IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Conversation> builder)
    {
        builder.ToTable(nameof(Conversation).Pluralize());
        builder.HasMany(c => c.Members)
            .WithOne(cm => cm.Conversation)
            .HasForeignKey(cm => cm.ConversationId);

        builder.HasMany(c => c.Messages)
            .WithOne(m => m.Conversation)
            .HasForeignKey(m => m.ConversationId);
    }

    public void Configure(EntityTypeBuilder<ConversationMember> builder)
    {
        builder.ToTable(nameof(ConversationMember).Pluralize());
        builder.HasOne(cm => cm.Conversation)
            .WithMany(c => c.Members)
            .HasForeignKey(cm => cm.ConversationId);

        builder.HasOne(cm => cm.User)
            .WithMany(u => u.ConversationMemberships)
            .HasForeignKey(cm => cm.UserId);
    }

    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable(nameof(Message).Pluralize());
        builder.HasOne(m => m.Conversation)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ConversationId);

        builder.HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId);
    }
}