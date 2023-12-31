﻿using Fluxor;

namespace BlazorWithFluxor.Client.Store.Counter;

public record CounterState
{
    public int CurrentCount { get; init; }
}

public class CounterFeature : Feature<CounterState>
{
    public override string GetName() => "Counter";

    protected override CounterState GetInitialState()
    {
        return new CounterState
        {
            CurrentCount = 0
        };
    }
}