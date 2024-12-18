using Domain.Models.AiAssistanc;

namespace Application.UseCases.AiAssistant;
public interface IPromptBuilder
{
    Message BuildPrompt(string prompt, string AiContext, Guid sessionId, IEnumerable<Message>? initialMessages = null);
}
