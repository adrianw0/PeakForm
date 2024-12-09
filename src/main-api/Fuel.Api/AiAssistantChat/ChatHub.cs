using Application.UseCases.AiAssistant.QueryAiAssistant.Request;
using Application.UseCases.AiAssistant.QueryAiAssistantStream;
using Core.Interfaces.Providers;
using Microsoft.AspNetCore.SignalR;

namespace Fuel.Api.AiAssistantChat;

public class ChatHub : Hub
{
    private readonly IQueryAiAssistantStreamUseCase _queryAssitantUseCase;

    public ChatHub(IQueryAiAssistantStreamUseCase queryAssitantUseCase)
    {
        _queryAssitantUseCase = queryAssitantUseCase;
    }

    public async Task SendMessage(string prompt)
    {
        var request = new QueryAiAssistantRequest { prompt = prompt };

        await foreach (var chunk in _queryAssitantUseCase.Execute(request))
        {
            await Clients.Caller.SendAsync("ReceiveMessage", chunk);
        }


    }

}
