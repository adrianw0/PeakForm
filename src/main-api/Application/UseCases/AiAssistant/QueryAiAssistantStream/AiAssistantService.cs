using Application.UseCases.AiAssistant.QueryAiAssistant.Request;
using Domain.Models.AiAssistanc;
using Infrastructure.ExternalAPIs.LLMAssistants;
using Domain.Models.AiAssistanc.Enums;
using System.Text;
using Core.Interfaces.Repositories;
using Core.Interfaces.Providers;
using Microsoft.Extensions.Caching.Memory;
using Application.UseCases.AiAssistant.QueryAiAssistantStream;

namespace Application.UseCases.AiAssistant;
public class AiAssistantService : IAiAssistantService
{
    private readonly IPromptBuilder _promptBuilder;
    private readonly ILLMAssistantService _assistantService;
    private readonly ISessionManager _sessionManager;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserProvider _userProvider;

    public AiAssistantService(IPromptBuilder promptBuilder, ILLMAssistantService assistantService,
         ISessionManager sessionManager, IDateTimeProvider dateTimeProvider, IUserProvider userProvider)
    {
        _promptBuilder = promptBuilder;
        _assistantService = assistantService;
        _sessionManager = sessionManager;
        _dateTimeProvider = dateTimeProvider;
        _userProvider = userProvider;
    }

    public async Task<ChatSession> OpenSessionForCurrentUser()
    {
        Guid userId = new(_userProvider.UserId);
        var activeSession = await _sessionManager.GetActiveSessionForUser(userId);

        if (activeSession is not null && activeSession.LastActivityDate - _dateTimeProvider.Now <= TimeSpan.FromMinutes(30))
            return activeSession;
        
        if(activeSession is not null && activeSession.LastActivityDate - _dateTimeProvider.Now > TimeSpan.FromMinutes(30))
            await _sessionManager.CloseActiveChatSession(userId);

        return await _sessionManager.OpenNewChatSessionForUser(userId);
    }
    public async Task CloseSessionForCurrentuser()
    {
        Guid userId = new(_userProvider.UserId);
        await _sessionManager.CloseActiveChatSession(userId);
    }
    public async IAsyncEnumerable<string> GetAiResponse(QueryAiAssistantRequest request)
    {
        List<Message> messageHistory = new();

        Guid userId = new(_userProvider.UserId);
        var session = await _sessionManager.GetActiveSessionForUser(userId);
        if (session is null)
        {
            throw new Exception("Something went wrong, please try again later");
        }
        
        var message = _promptBuilder.BuildPrompt(request.prompt, Constants.AiContext, session.Id, messageHistory);
        messageHistory.Add(message);

        var responseContent = new StringBuilder();
        await foreach (var chunk in _assistantService.GenerateResponseStreamAsync(message))
        {
            responseContent.AppendLine(chunk);
            yield return chunk;
        }

        Message responseMessage = new()
        {
            Content = responseContent.ToString(),
            Id = Guid.NewGuid(),
            SessionId = session.Id,
            Sender = MessageSender.Assistant,
            timestamp = _dateTimeProvider.Now
        };
    }


}

