namespace Infrastructure.ExternalAPIs.LLMAssistants;
public interface ILLMAssistantService
{
    public IAsyncEnumerable<string> GenerateResponseStreamAsync(string prompt);
}
