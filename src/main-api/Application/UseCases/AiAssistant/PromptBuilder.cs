using Domain.Models.AiAssistanc.Enums;
using Domain.Models.AiAssistanc;
using System.Text;
using Core.Interfaces.Providers;

namespace Application.UseCases.AiAssistant;
public class PromptBuilder : IPromptBuilder

{
    private readonly IDateTimeProvider _dateTimeProvider;
    public PromptBuilder(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }
    public Message BuildPrompt(string prompt, IEnumerable<Message> history, string AiContext, Guid sessionId)
    {
        
        StringBuilder builder = new();

        builder.AppendLine(AiContext);
        foreach (Message msg in history)
        {
            builder.AppendLine($"role : {msg.Sender}, content: {msg.Content}");
        }
        builder.AppendLine(prompt);

        var message = new Message
        {
            Sender = MessageSender.User,
            SessionId = sessionId,
            Content = builder.ToString(),
            timestamp = _dateTimeProvider.Now,
        };

        return message;
    }
}
