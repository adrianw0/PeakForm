using Domain.Models.AiAssistanc.Enums;

namespace Domain.Models.AiAssistanc;
public record Message : IEntity
{
    public Guid Id { get; init; }
    public Guid SessionId { get; set; }
    public MessageSender Sender { get; set; }
    public DateTime timestamp { get; set; }
    public string Content { get; set; } = string.Empty;
    
}
