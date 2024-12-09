using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models.AiAssistanc;
using Domain.Models.AiAssistanc.Enums;
using System.Data;

namespace Application.UseCases.AiAssistant;
public class SessionManager : ISessionManager
{
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    private readonly IReadRepository<ChatSession> _readRepository;
    private readonly IWriteRepository<ChatSession> _writeRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserProvider _userProvider;
    public SessionManager(IWriteRepository<ChatSession> writeRepository, IReadRepository<ChatSession> readRepository, IUserProvider userProvider, IDateTimeProvider dateTimeProvider)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _userProvider = userProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task CloseChatSession(Guid sessionId)
    {
        var session = await _readRepository.FindOneAsync(s=>s.Id.Equals(sessionId) && s.status == SessionStatus.Active);
        if (session is null)
            throw new ArgumentException("No session was found or session is not active");

        session.status = SessionStatus.Closed;
        await _writeRepository.UpdateAsync(session);
    }

    public async Task<ChatSession> GetActiveSessionForCurrentUser()
    {
        return await _readRepository.FindOneAsync(x => x.status == SessionStatus.Active && x.UserId.Equals(_userProvider.UserId));
    }

    public async Task<ChatSession> OpenNewChatSession()
    {
        await _semaphore.WaitAsync();
        try
        {
            var activeSessions = await _readRepository.FindOneAsync(n => n.status == SessionStatus.Active && n.UserId.Equals(_userProvider.UserId));
            if (activeSessions is not null)
                throw new InvalidOperationException("Another session is still active. New one cannot be opened");

            var session = new ChatSession
            {
                CreationDate = _dateTimeProvider.Now,
                status = SessionStatus.Active,
                UserId = new Guid(_userProvider.UserId),
                Id = Guid.NewGuid(),
            };
            await _writeRepository.InsertOneAsync(session);
            return session;
        }
        finally {
            _semaphore.Release();
        }

    }


}

