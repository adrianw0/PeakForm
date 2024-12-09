using Domain.Models.AiAssistanc;

namespace Infrastructure.ExternalAPIs.LLMAssistants;
public interface ILLMAssistantService
{
    public IAsyncEnumerable<string> GenerateResponseStreamAsync(Message prompt);
}
