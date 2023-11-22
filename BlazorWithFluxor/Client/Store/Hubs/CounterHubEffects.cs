using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using System;

namespace BlazorWithFluxor.Client.Store.Hubs;

public class CounterHubEffects
{
    private readonly HubConnection _hubConnection;

    public CounterHubEffects(NavigationManager navigationManager)
    {
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(navigationManager.ToAbsoluteUri("/counterhub"))
            .WithAutomaticReconnect()
            .Build();
    }

    [EffectMethod(typeof(CounterHubStartAction))]
    public async Task Start(IDispatcher dispatcher)
    {
        await _hubConnection.StartAsync();

        _hubConnection.Reconnecting += (ex) =>
        {
            dispatcher.Dispatch(new CounterHubSetConnectedAction(false));
            return Task.CompletedTask;
        };

        _hubConnection.Reconnected += (connectionId) =>
        {
            dispatcher.Dispatch(new CounterHubSetConnectedAction(true));
            return Task.CompletedTask;
        };

        _hubConnection.On<int>("ReceiveCount", (count) => dispatcher.Dispatch(new CounterHubReceiveCountAction(count)));

        dispatcher.Dispatch(new CounterHubSetConnectedAction(true));
    }

    [EffectMethod]
    public async Task SendCount(CounterHubSendCountAction action, IDispatcher dispatcher)
    {
        try
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                await _hubConnection.SendAsync("SendCount", action.Count);
            }
            else
            {
                dispatcher.Dispatch(new CounterHubSendCountFailedAction("Not connected to hub."));
            }
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new CounterHubSendCountFailedAction(ex.Message));
        }
    }
}