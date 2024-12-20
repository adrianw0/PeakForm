using Domain.Models.AiAssistanc;
using Infrastructure.ExternalAPIs.LLMAssistants;
using Domain.Models.AiAssistanc.Enums;
using System.Text;
using Core.Interfaces.Providers;
using Microsoft.Extensions.Caching.Memory;
using Application.Services.AiAssistant.Interfaces;
using System.Linq.Expressions;
using Core.Interfaces.Repositories;
using Domain.Models;

namespace Application.Services.AiAssistant;
public class AiAssistantService : IAiAssistantService
{
    private readonly IPromptBuilder _promptBuilder;
    private readonly ILLMAssistantService _assistantService;
    private readonly ISessionManager _sessionManager;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserProvider _userProvider;
    private readonly IMemoryCache _memoryCache;
    private readonly IReadRepository<UserData> _UserDataReadRepo;

    public AiAssistantService(IPromptBuilder promptBuilder, ILLMAssistantService assistantService,
         ISessionManager sessionManager, IDateTimeProvider dateTimeProvider, IUserProvider userProvider, IMemoryCache memoryCache, IReadRepository<UserData> readRepository)
    {
        _promptBuilder = promptBuilder;
        _assistantService = assistantService;
        _sessionManager = sessionManager;
        _dateTimeProvider = dateTimeProvider;
        _userProvider = userProvider;
        _memoryCache = memoryCache;
        _UserDataReadRepo = readRepository;
    }

    public async Task<ChatSession> OpenSessionForCurrentUser()
    {
        Guid userId = new(_userProvider.UserId);
        var activeSession = await _sessionManager.GetActiveSessionForUser(userId);

        if (activeSession is not null && _dateTimeProvider.Now - activeSession.LastActivityDate <= TimeSpan.FromMinutes(30))
            return activeSession;

        if (activeSession is not null && _dateTimeProvider.Now - activeSession.LastActivityDate > TimeSpan.FromMinutes(30))
            await _sessionManager.CloseActiveChatSession(userId);

        return await _sessionManager.OpenNewChatSessionForUser(userId);
    }
    public async Task CloseSessionForCurrentuser()
    {
        Guid userId = new(_userProvider.UserId);
        Guid sessionId = (await _sessionManager.GetActiveSessionForUser(userId)).Id;

        var key = GetCacheKey(userId, sessionId); 

        if (_memoryCache.TryGetValue(key, out List<Message> messages))
        {
            await _sessionManager.DumpMessagesToDatabase(messages);
        }

        await _sessionManager.CloseActiveChatSession(userId);
        
    }
    public async IAsyncEnumerable<string> GetAiResponse(string prompt)
    {
        List<Message> messageHistory;
        Guid userId = new(_userProvider.UserId);
        var session = await _sessionManager.GetActiveSessionForUser(userId);

        if (session is null)
        {
            throw new Exception("Something went wrong, please try again later");
        }

        _sessionManager.UpdateSessionLastActivityDate(session);

        if (_memoryCache.TryGetValue(GetCacheKey(userId, session.Id), out List<Message> messages))
        {
            messageHistory = messages;
        }

        else messageHistory = new();


        var promptDateTime = _dateTimeProvider.Now;
        Message message = new()
        {
            Content = prompt,
            Id = Guid.NewGuid(),
            Sender = MessageSender.User,
            SessionId = session.Id,
            timestamp = promptDateTime,
        };
        AddMessageToCache(userId, session.Id, message);
        var userData = await _UserDataReadRepo.FindByIdAsync(userId);

        var response = new StringBuilder();
        var composedPrompt = _promptBuilder.BuildPrompt(prompt, Constants.AiContext, session.Id, messageHistory, userData);
        try
        {
            await foreach (var chunk in _assistantService.GenerateResponseStreamAsync(composedPrompt))
            {
                response.Append(chunk);
                    yield return chunk;
            }
        }
        finally
        {
            var responseMesage = new Message
            {
                Id = Guid.NewGuid(),
                Content = response.ToString(),
                Sender = MessageSender.Assistant,
                SessionId = session.Id,
                timestamp = _dateTimeProvider.Now,
            };

            AddMessageToCache(userId, session.Id, responseMesage); 
        }
        

    }


    private void AddMessageToCache(Guid usertId, Guid sessionId, Message message) 
    {
        var cacheKey = GetCacheKey(usertId, sessionId);
        if (!_memoryCache.TryGetValue(cacheKey, out List<Message> messages))
        {
            messages = new List<Message>();
        }

        messages.Add(message);

        _memoryCache.Set(cacheKey, messages);
    }

    private static string GetCacheKey(Guid userId, Guid sessionId)
    {
        return $"{userId}_{sessionId}";
    }

}

