using Fluxor;

namespace BlazorWithFluxor.Client.Store.Hubs;
public static class CounterHubReducers
{
    [ReducerMethod]
    public static CounterHubState OnSetConnected(CounterHubState state, CounterHubSetConnectedAction action)
    {
        return state with
        {
            Connected = action.Connected
        };
    }
}