using BlazorWithFluxor.Client.Store.Weather;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorWithFluxor.Client.Pages;

public partial class WeatherForecasts
{
    [Inject] private IDispatcher Dispatcher { get; set; }
    [Inject] private IState<WeatherState> WeatherState { get; set; }

    protected override void OnInitialized()
    {
        if (WeatherState.Value.Initialized == false)
        {
            LoadForecasts();
        }
        base.OnInitialized();
    }

    private void LoadForecasts()
    {
        Dispatcher.Dispatch(new WeatherLoadForecastsAction());
    }
}