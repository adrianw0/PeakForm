using Application.UseCases.AiAssistant.QueryAiAssistant.Request;
using Domain.Models.AiAssistanc;

namespace Application.UseCases.AiAssistant.QueryAiAssistantStream;
public interface IAiAssistantService
{
    Task CloseSessionForCurrentuser();
    IAsyncEnumerable<string> GetAiResponse(QueryAiAssistantRequest request);
    Task<ChatSession> OpenSessionForCurrentUser();
}
