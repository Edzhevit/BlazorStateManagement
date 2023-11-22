using Fluxor;

namespace BlazorWithFluxor.Client.Store.Counter;

public static class CounterReducers
{
    [ReducerMethod(typeof(CounterIncrementAction))]
    public static CounterState OnIncrement(CounterState state)
    {
        return state with
        {
            CurrentCount = state.CurrentCount + 1
        };
    }

    [ReducerMethod]
    public static CounterState OnCounterSetState(CounterState state, CounterSetStateAction action)
    {
        return action.CounterState;
    }
}