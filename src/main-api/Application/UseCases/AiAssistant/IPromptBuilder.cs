using Domain.Models.AiAssistanc;

namespace Application.UseCases.AiAssistant;
public interface IPromptBuilder
{
    Message BuildPrompt(string prompt, IEnumerable<Message> history, string AiContext, Guid sessionId);
}
