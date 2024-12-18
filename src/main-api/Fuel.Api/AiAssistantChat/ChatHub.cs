using Application.UseCases.AiAssistant;
using Application.UseCases.AiAssistant.QueryAiAssistant.Request;
using Application.UseCases.AiAssistant.QueryAiAssistantStream;
using Core.Interfaces.Providers;
using Microsoft.AspNetCore.SignalR;
using Domain.Models.AiAssistanc;

namespace Fuel.Api.AiAssistantChat;

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
        var request = new QueryAiAssistantRequest { prompt = prompt };

        int chunkId = 0;
        await foreach (var chunk in _aiAssistantService.GetAiResponse(request))
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
