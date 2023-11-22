using System;
using BlazorWithFluxor.Shared;
using Fluxor;

namespace BlazorWithFluxor.Client.Store.Weather;

[FeatureState]
public record WeatherState
{
    public bool Initialized { get; init; } = false;
    public bool Loading { get; init; } = false;
    public WeatherForecast[] Forecasts { get; init; } = Array.Empty<WeatherForecast>();
}