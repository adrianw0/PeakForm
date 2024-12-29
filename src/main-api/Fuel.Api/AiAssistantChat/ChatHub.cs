using Application.Services.AiAssistant.Interfaces;
using Domain.Models.AiAssistanc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Fuel.Api.AiAssistantChat;

[Authorize]
public class ChatHub : Hub
{
    private readonly IAiAssistantService _aiAssistantService;

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

    public Task GetMessageHistory()
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
        await base.OnDisconnectedAsync(exception);
    }

}
