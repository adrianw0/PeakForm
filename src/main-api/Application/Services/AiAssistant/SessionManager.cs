using Application.Services.AiAssistant.Interfaces;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models.AiAssistanc;
using Domain.Models.AiAssistanc.Enums;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Application.Services.AiAssistant;
public class SessionManager : ISessionManager
{
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    private readonly IReadRepository<ChatSession> _sessionReadRepository;
    private readonly IWriteRepository<ChatSession> _sessionWriteRepository;
    private readonly IWriteRepository<Message> _messagesWriteRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    public SessionManager(IWriteRepository<ChatSession> writeRepository, IReadRepository<ChatSession> readRepository, IDateTimeProvider dateTimeProvider, IWriteRepository<Message> messagesWriteRepository)
    {
        _sessionWriteRepository = writeRepository;
        _sessionReadRepository = readRepository;
        _dateTimeProvider = dateTimeProvider;
        _messagesWriteRepository = messagesWriteRepository;
    }

    public async Task CloseActiveChatSession(Guid userId)
    {
        var session = await _sessionReadRepository.FindOneAsync(s => s.UserId.Equals(userId) && s.status == SessionStatus.Active);
        if (session is null)
            throw new ArgumentException("No session was found or session is not active");

        await CloseActiveSession(session);
    }
    public async Task DumpMessagesToDatabase(List<Message> messages)
    {
        await _messagesWriteRepository.InsertManyAsync(messages);
    }

    public async Task<ChatSession> GetActiveSessionForUser(Guid userId)
    {
        return await _sessionReadRepository.FindOneAsync(x => x.status == SessionStatus.Active && x.UserId.Equals(userId));
    }

    public async Task<ChatSession> OpenNewChatSessionForUser(Guid userId)
    {
        await _semaphore.WaitAsync();
        try
        {
            var activeSessions = await GetActiveSessionForUser(userId);
            if (activeSessions is not null)
                throw new InvalidOperationException("Another session is still active. New one cannot be opened");

            var session = new ChatSession
            {
                CreationDate = _dateTimeProvider.Now,
                status = SessionStatus.Active,
                UserId = userId,
                Id = Guid.NewGuid(),
            };
            await _sessionWriteRepository.InsertOneAsync(session);
            return session;
        }
        finally
        {
            _semaphore.Release();
        }

    }

    public async void UpdateSessionLastActivityDate(ChatSession session)
    {
        session.LastActivityDate = _dateTimeProvider.Now;
        await _sessionWriteRepository.UpdateAsync(session);
    }

    private async Task CloseActiveSession(ChatSession session)
    {
        session.status = SessionStatus.Closed;
        await _sessionWriteRepository.UpdateAsync(session);
    }

}

