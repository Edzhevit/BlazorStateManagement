using BlazorWithFluxor.Client.Store.Counter;
using BlazorWithFluxor.Client.Store.Hubs;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorWithFluxor.Client.Pages;

public partial class Counter
{
    [Inject] private IDispatcher Dispatcher { get; set; }
    [Inject] private IState<CounterState> CounterState { get; set; }
    [Inject] private IState<CounterHubState> CounterHubState { get; set; }

    private void IncrementCount()
    {
        Dispatcher.Dispatch(new CounterIncrementAction());
    }
    private void SaveCount()
    {
        Dispatcher.Dispatch(new CounterPersistStateAction(CounterState.Value));
    }

    private void LoadCount()
    {
        Dispatcher.Dispatch(new CounterLoadStateAction());
    }

    private void ClearCount()
    {
        Dispatcher.Dispatch(new CounterClearStateAction());
    }

    private void SendCount()
    {
        Dispatcher.Dispatch(new CounterHubSendCountAction(CounterState.Value.CurrentCount));
    }
}