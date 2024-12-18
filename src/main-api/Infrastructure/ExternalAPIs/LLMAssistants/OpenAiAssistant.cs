using Domain.Models.AiAssistanc;
using OpenAI;
using OpenAI.Chat;

namespace Infrastructure.ExternalAPIs.LLMAssistants;
public class OpenAiAssistant : ILLMAssistantService
{
    private readonly OpenAIClient _openAiClient;

    public OpenAiAssistant(OpenAIClient openAIClient)
    {
            _openAiClient = openAIClient;
    }
    public async IAsyncEnumerable<string> GenerateResponseStreamAsync(Message prompt)
    {
        await foreach (var chunk in _openAiClient.GetChatClient("gpt-4o-mini").CompleteChatStreamingAsync(prompt.Content))
        {
                yield return $"{chunk.ContentUpdate[0].Text}";   
        }

    }
}
