using Application.UseCases.AiAssistant.QueryAiAssistant.Request;

namespace Application.UseCases.AiAssistant.QueryAiAssistantStream;
public interface IQueryAiAssistantStreamUseCase
{
    IAsyncEnumerable<string> Execute(QueryAiAssistantRequest request);
}
