using Application.UseCases.AiAssistant.QueryAiAssistant.Request;
using Domain.Models.AiAssistanc;
using Infrastructure.ExternalAPIs.LLMAssistants;
using Domain.Models.AiAssistanc.Enums;
using System.Text;
using Core.Interfaces.Repositories;
using Core.Interfaces.Providers;

namespace Application.UseCases.AiAssistant.QueryAiAssistantStream;
public class QueryAiAssistantStreamUseCase : IQueryAiAssistantStreamUseCase
{
    private readonly IPromptBuilder _promptBuilder;
    private readonly ILLMAssistantService _assistantService;
    private readonly ISessionManager _sessionManager;
    private readonly IWriteRepository<Message> _messageWriteRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public QueryAiAssistantStreamUseCase(IPromptBuilder promptBuilder, ILLMAssistantService assistantService,
         ISessionManager sessionManager, IWriteRepository<Message> messageWriteRepository, IDateTimeProvider dateTimeProvider)
    {
        _promptBuilder = promptBuilder;
        _assistantService = assistantService;
        _sessionManager = sessionManager;
        _messageWriteRepository = messageWriteRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async IAsyncEnumerable<string> Execute(QueryAiAssistantRequest request)
    {
        var messageHistory = new List<Message>();
        var session = await _sessionManager.GetActiveSessionForCurrentUser();

        if (session is not null)
        {
            //messageHistory = _messageCache.GetMessages(session.id);
        }
        else { 
            session = await _sessionManager.OpenNewChatSession();
        }

        var message = _promptBuilder.BuildPrompt(request.prompt, messageHistory, Constants.AiContext, session.Id);
        var responseContent = new StringBuilder();

        await foreach (var chunk in _assistantService.GenerateResponseStreamAsync(message))
        {
            responseContent.AppendLine(chunk);
            yield return chunk;
        }

        var response = new Message
        {
            Id = new Guid(),
            Content = responseContent.ToString(),
            Sender = MessageSender.Assistant,
            SessionId = session.Id,
            timestamp = _dateTimeProvider.Now
        };

        await _messageWriteRepository.InsertOneAsync(message);
        await _messageWriteRepository.InsertOneAsync(response);

    }


}

