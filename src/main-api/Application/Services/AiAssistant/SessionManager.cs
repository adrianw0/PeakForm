﻿using Application.Services.AiAssistant.Interfaces;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models.AiAssistanc;
using Domain.Models.AiAssistanc.Enums;
using Microsoft.Extensions.Logging;

namespace Application.Services.AiAssistant;
public class SessionManager(IWriteRepository<ChatSession> writeRepository, IReadRepository<ChatSession> readRepository, IDateTimeProvider dateTimeProvider, IWriteRepository<Message> messagesWriteRepository, ILogger<SessionManager> logger) : ISessionManager
{

    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    private readonly IReadRepository<ChatSession> _sessionReadRepository = readRepository;
    private readonly IWriteRepository<ChatSession> _sessionWriteRepository = writeRepository;
    private readonly IWriteRepository<Message> _messagesWriteRepository = messagesWriteRepository;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;
    private readonly ILogger<SessionManager> _logger = logger;

    public async Task CloseActiveChatSession(Guid userId)
    {
        var session = await _sessionReadRepository.FindOneAsync(s => s.UserId.Equals(userId) && s.Status == SessionStatus.Active);
        if (session is null)
        {
            _logger.LogWarning("No active session found for user ID: {UserId}", userId);
            throw new InvalidOperationException(Constants.NoActiveSessionFound);
        }

        try
        {
            await CloseActiveSession(session);
            _logger.LogInformation("session {id} for user {userId} closed.", session.Id, userId);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Error occured when trying to close active session for user: {userId}, sessionId: {sessionId}", session.UserId, session.Id);
        }
    }
    public async Task DumpMessagesToDatabase(List<Message> messages)
    {
        if (messages is null || messages.Count == 0)
        {
            _logger.LogWarning("Attempted to dump messages but the list is empty.");
            throw new ArgumentException(Constants.NullMessagesError);
        }
        await _messagesWriteRepository.InsertManyAsync(messages);
        _logger.LogInformation("Messages saved to database: {messages}", messages);
    }

    public async Task<ChatSession> GetActiveSessionForUser(Guid userId)
    {
        return await _sessionReadRepository.FindOneAsync(x => x.Status == SessionStatus.Active && x.UserId.Equals(userId));
    }

    public async Task<ChatSession> OpenNewChatSessionForUser(Guid userId)
    {
        await _semaphore.WaitAsync();
        try
        {
            var activeSessions = await GetActiveSessionForUser(userId);
            if (activeSessions is not null)
            {
                _logger.LogWarning("Attempted to open session for user {userId}, but other session is still active", userId);
                throw new InvalidOperationException(Constants.OtherSessionStillActive);
            }

            var session = new ChatSession
            {
                CreationDate = _dateTimeProvider.Now,
                Status = SessionStatus.Active,
                UserId = userId,
                Id = Guid.NewGuid(),
            };

            await _sessionWriteRepository.InsertOneAsync(session);
            _logger.LogInformation("Chat session created: Id: {Id} | Creation date: {CreationDate}, user ID: {userId}", session.Id, session.CreationDate, session.UserId);
            return session;
        }
        finally
        {
            _semaphore.Release();
        }

    }

    public async Task UpdateSessionLastActivityDate(ChatSession session)
    {
        session.LastActivityDate = _dateTimeProvider.Now;
        await _sessionWriteRepository.UpdateAsync(session);
    }

    private async Task CloseActiveSession(ChatSession session)
    {
        session.Status = SessionStatus.Closed;
        await _sessionWriteRepository.UpdateAsync(session);
    }

}

