using Domain.Models.AiAssistanc;

namespace Infrastructure.ExternalAPIs.LLMAssistants;
public class OpenAiAssistant : ILLMAssistantService
{
    public async IAsyncEnumerable<string> GenerateResponseStreamAsync(Message prompt)
    {
        string responseStream = "asdasdasdasdasdasdassdasdasdasdasdasdasdasdasdasdasdasdasdasdasdsadasdasd";
        
        foreach(var chr in responseStream.ToArray())
        {
            yield return chr.ToString();
            await Task.Delay(1000);
        }

    }
}
