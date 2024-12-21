using Domain.Models.AiAssistanc.Enums;

namespace Domain.Models.AiAssistanc;
public class ChatSession : IEntity
{
    public Guid Id { get; init; }
    public Guid UserId { get; set; }
    public DateTime CreationDate { get; set; }
    public SessionStatus status { get; set; }
    public DateTime LastActivityDate { get; set; }
}
