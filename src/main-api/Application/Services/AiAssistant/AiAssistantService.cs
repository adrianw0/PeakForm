using Application.Services.AiAssistant.Interfaces;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.AiAssistanc;
using Domain.Models.AiAssistanc.Enums;
using Infrastructure.ExternalAPIs.LLMAssistants;
using Microsoft.Extensions.Caching.Memory;
using System.Text;

namespace Application.Services.AiAssistant;
public class AiAssistantService(IPromptBuilder promptBuilder, ILLMAssistantService assistantService,
     ISessionManager sessionManager, IDateTimeProvider dateTimeProvider, IUserProvider userProvider,
     IMemoryCache memoryCache, IReadRepository<UserData> readRepository) : IAiAssistantService
{
    private readonly IPromptBuilder _promptBuilder = promptBuilder;
    private readonly ILLMAssistantService _assistantService = assistantService;
    private readonly ISessionManager _sessionManager = sessionManager;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly IUserProvider _userProvider = userProvider;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly IReadRepository<UserData> _UserDataReadRepo = readRepository;

    public async Task<ChatSession> OpenSessionForCurrentUser()
    {
        Guid userId = GetUserId();
        var activeSession = await _sessionManager.GetActiveSessionForUser(userId);

        if (activeSession is not null && !IsSessionExpired(activeSession))
            return activeSession;

        if (activeSession is not null && IsSessionExpired(activeSession))
            await _sessionManager.CloseActiveChatSession(userId);

        return await _sessionManager.OpenNewChatSessionForUser(userId);
    }



    public async Task CloseSessionForCurrentuser()
    {
        Guid userId = GetUserId();
        var session = await _sessionManager.GetActiveSessionForUser(userId) ?? throw new InvalidOperationException(Constants.NoSessionToClose);

        var key = GetCacheKey(userId, session.Id);

        if (_memoryCache.TryGetValue(key, out List<Message>? messages) && messages is not null)
        {
            await _sessionManager.DumpMessagesToDatabase(messages);
            _memoryCache.Remove(key);
        }

        await _sessionManager.CloseActiveChatSession(userId);

    }
    public async IAsyncEnumerable<string> GetAiResponse(string prompt)
    {
        if (string.IsNullOrEmpty(prompt))
            throw new ArgumentException(Constants.EmptyPromptError, nameof(prompt));

        Guid userId = GetUserId();
        var session = await _sessionManager.GetActiveSessionForUser(userId)
            ?? throw new Exception(Constants.SessionManagerError);

        await _sessionManager.UpdateSessionLastActivityDate(session);

        var messageHistory = GetMessageHistory(userId, session);

        Message message = CreateMessage(session.Id, MessageSender.User, prompt);

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
            Message responseMessage = CreateMessage(session.Id, MessageSender.Assistant, response.ToString());
            AddMessageToCache(userId, session.Id, responseMessage);
        }


    }

    private List<Message> GetMessageHistory(Guid userId, ChatSession session)
    {
        if (_memoryCache.TryGetValue(GetCacheKey(userId, session.Id), out List<Message>? messages) && messages is not null)
        {
            return messages;
        }

        return [];
    }

    private void AddMessageToCache(Guid usertId, Guid sessionId, Message message)
    {
        var cacheKey = GetCacheKey(usertId, sessionId);
        if (!_memoryCache.TryGetValue(cacheKey, out List<Message>? messages) || messages is null)
        {
            messages = [];
        }

        messages.Add(message);

        _memoryCache.Set(cacheKey, messages);
    }

    private static string GetCacheKey(Guid userId, Guid sessionId)
    {
        return $"{userId}_{sessionId}";
    }

    private Guid GetUserId()
    {
        var userId = _userProvider.UserId;

        if (string.IsNullOrEmpty(userId))
            throw new InvalidOperationException(Constants.InvalidUserId);
        return new Guid(userId);
    }

    private Message CreateMessage(Guid sessionId, MessageSender sender, string content)
    {
        return new Message
        {
            Id = Guid.NewGuid(),
            SessionId = sessionId,
            Sender = sender,
            Content = content,
            Timestamp = _dateTimeProvider.Now
        };
    }
    private bool IsSessionExpired(ChatSession? activeSession)
    {
        return activeSession is not null && _dateTimeProvider.Now - activeSession.LastActivityDate <= TimeSpan.FromMinutes(Constants.SessionValidityMinutes);
    }
}

