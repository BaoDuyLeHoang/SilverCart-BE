namespace SilverCart.Application.Interfaces.Repositories;

public class MessageDto
{
    public Guid Id { get; set; }
    public Guid ConversationId { get; set; }
    public Guid SenderId { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsRead { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? ModificationDate { get; set; }
    public bool IsModified { get; set; }
}