using Domain.Models.AiAssistanc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.AiAssistant;
public interface ISessionManager
{
    Task CloseActiveChatSession(Guid userId);
    Task DumpMessagesToDatabase(ChatSession session, List<Message> messages);
    Task<ChatSession> GetActiveSessionForUser(Guid userId);
    Task<ChatSession> OpenNewChatSessionForUser(Guid userId);
}
