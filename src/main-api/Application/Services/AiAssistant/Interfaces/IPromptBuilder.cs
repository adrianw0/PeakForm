using Domain.Models;
using Domain.Models.AiAssistanc;

namespace Application.Services.AiAssistant.Interfaces;
public interface IPromptBuilder
{
    string BuildPrompt(string prompt, string AiContext, Guid sessionId, IEnumerable<Message>? initialMessages = null, UserData? userData = null);
}
