using Microsoft.Extensions.Logging;
using OpenAI;

namespace Infrastructure.ExternalAPIs.LLMAssistants;
public class OpenAiAssistant : ILLMAssistantService
{
    private readonly OpenAIClient _openAiClient;
    private readonly ILogger<OpenAiAssistant> _logger;

    public OpenAiAssistant(OpenAIClient openAIClient, ILogger<OpenAiAssistant> logger)
    {
        _openAiClient = openAIClient;
        _logger = logger;
    }
    public async IAsyncEnumerable<string> GenerateResponseStreamAsync(string prompt)
    {
        _logger.LogInformation("Generating response stream for prompt:\n {prompt}", prompt); ///TODO: to remove 

        await foreach (var chunk in _openAiClient.GetChatClient("gpt-4o-mini").CompleteChatStreamingAsync(prompt))
        {
            yield return $"{chunk.ContentUpdate[0].Text}";
        }
    }
}
