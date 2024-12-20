using Microsoft.AspNetCore.SignalR;
using Domain.Models.AiAssistanc;
using Application.Services.AiAssistant.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Fuel.Api.AiAssistantChat;

[Authorize]
public class ChatHub : Hub
{
    private readonly IAiAssistantService _aiAssistantService;

    private ChatSession session;

    public ChatHub(IAiAssistantService queryAssitantUseCase)
    {
        _aiAssistantService = queryAssitantUseCase;
    }

    public async Task SendMessage(string prompt)
    {
        int chunkId = 0;
        await foreach (var chunk in _aiAssistantService.GetAiResponse(prompt))
        {
            var payload = new
            {
                Text = chunk,
                ChunkId = chunkId,
                isComplete = false
            }; 
            await Clients.Caller.SendAsync("ReceiveMessage", payload);
            chunkId++;
        }

        var finalPayload = new
        {
            Text = string.Empty, 
            ChunkId = chunkId,
            IsComplete = true
        };
        await Clients.Caller.SendAsync("ReceiveMessage", finalPayload);

    }

    public async Task GetMessageHistory()
    {
        throw new NotImplementedException();
    }
    public override async Task OnConnectedAsync()
    {
        await _aiAssistantService.OpenSessionForCurrentUser();
        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _aiAssistantService.CloseSessionForCurrentuser();
        //load existing messages.
        await base.OnDisconnectedAsync(exception);
    }

}
