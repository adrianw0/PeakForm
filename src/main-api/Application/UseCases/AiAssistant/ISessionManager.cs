﻿using Domain.Models.AiAssistanc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.AiAssistant;
public interface ISessionManager
{
    Task<ChatSession> GetActiveSessionForCurrentUser();
    Task<ChatSession> OpenNewChatSession();
    Task CloseChatSession(Guid sessionId);
}
