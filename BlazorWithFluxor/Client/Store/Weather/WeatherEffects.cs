using Blazored.LocalStorage;
using BlazorWithFluxor.Client.Store.Counter;
using BlazorWithFluxor.Shared;
using Fluxor;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWithFluxor.Client.Store.Weather;

public class WeatherEffects
{
    private readonly HttpClient _http;
    private readonly IState<CounterState> _counterState;
    private readonly ILocalStorageService _localStorageService;
    private const string WeatherStatePersistenceName = "BlazorWithFluxor_WeatherState";

    public WeatherEffects(HttpClient http, IState<CounterState> counterState, ILocalStorageService localStorageService)
    {
        _http = http;
        _counterState = counterState;
        _localStorageService = localStorageService;
    }

    [EffectMethod(typeof(WeatherLoadForecastsAction))]
    public async Task LoadForecasts(IDispatcher dispatcher)
    {
        var forecasts = await _http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        dispatcher.Dispatch(new WeatherSetForecastsAction(forecasts));
        dispatcher.Dispatch(new WeatherLoadForecastsSuccessAction());
    }

    [EffectMethod(typeof(CounterIncrementAction))]
    public async Task LoadForecastsOnIncrement(IDispatcher dispatcher)
    {
        if (_counterState.Value.CurrentCount % 10 == 0)
        {
            dispatcher.Dispatch(new WeatherLoadForecastsAction());
        }
    }

    [EffectMethod]
    public async Task PersistState(WeatherPersistStateAction action, IDispatcher dispatcher)
    {
        try
        {
            await _localStorageService.SetItemAsync(WeatherStatePersistenceName, action.WeatherState);
            dispatcher.Dispatch(new WeatherPersistStateSuccessAction());
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new WeatherPersistStateFailureAction(ex.Message));
        }
    }

    [EffectMethod(typeof(WeatherLoadStateAction))]
    public async Task LoadState(IDispatcher dispatcher)
    {
        try
        {
            var weatherState = await _localStorageService.GetItemAsync<WeatherState>(WeatherStatePersistenceName);
            if (weatherState is not null)
            {
                dispatcher.Dispatch(new WeatherSetStateAction(weatherState));
                dispatcher.Dispatch(new WeatherLoadStateSuccessAction());
            }
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new WeatherLoadStateFailureAction(ex.Message));
        }
    }

    [EffectMethod(typeof(WeatherClearStateAction))]
    public async Task ClearState(IDispatcher dispatcher)
    {
        try
        {
            await _localStorageService.RemoveItemAsync(WeatherStatePersistenceName);
            dispatcher.Dispatch(new WeatherSetStateAction(new WeatherState
            {
                Initialized = false,
                Loading = false,
                Forecasts = Array.Empty<WeatherForecast>()
            }));
            dispatcher.Dispatch(new WeatherClearStateSuccessAction());
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new WeatherClearStateFailureAction(ex.Message));
        }
    }
}