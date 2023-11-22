using Fluxor;

namespace BlazorWithFluxor.Client.Store.Hubs;

[FeatureState]
public record CounterHubState
{
    public bool Connected { get; init; } = false;
};