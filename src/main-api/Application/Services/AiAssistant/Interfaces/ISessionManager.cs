using Domain.Models.AiAssistanc;

namespace Application.Services.AiAssistant.Interfaces;
public interface ISessionManager
{
    Task CloseActiveChatSession(Guid userId);
    Task DumpMessagesToDatabase(List<Message> messages);
    Task<ChatSession> GetActiveSessionForUser(Guid userId);
    Task<ChatSession> OpenNewChatSessionForUser(Guid userId);
    Task UpdateSessionLastActivityDate(ChatSession session);
}
