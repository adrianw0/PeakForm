using Microsoft.Extensions.Logging;
using OpenAI;

namespace Infrastructure.ExternalAPIs.LLMAssistants;
public class OpenAiAssistant(OpenAIClient openAIClient, ILogger<OpenAiAssistant> logger) : ILLMAssistantService
{
    private readonly OpenAIClient _openAiClient = openAIClient;
    private readonly ILogger<OpenAiAssistant> _logger = logger;

    public async IAsyncEnumerable<string> GenerateResponseStreamAsync(string prompt)
    {
        _logger.LogInformation("Generating response stream for prompt:\n {prompt}", prompt); ///TODO: to remove 

        await foreach (var chunk in _openAiClient.GetChatClient("gpt-4o-mini").CompleteChatStreamingAsync(prompt))
        {
            if (chunk.ContentUpdate != null && chunk.ContentUpdate.Count != 0)
                yield return $"{chunk.ContentUpdate[0].Text}";
        }
    }
}
