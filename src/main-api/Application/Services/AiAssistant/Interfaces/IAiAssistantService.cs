
using Domain.Models.AiAssistanc;

namespace Application.Services.AiAssistant.Interfaces;
public interface IAiAssistantService
{
    Task CloseSessionForCurrentuser();
    IAsyncEnumerable<string> GetAiResponse(string prompt);
    Task<ChatSession> OpenSessionForCurrentUser();
}
