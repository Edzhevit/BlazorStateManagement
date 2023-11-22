using Fluxor;

namespace BlazorWithFluxor.Client.Store.Weather;

public static class WeatherReducers
{
    [ReducerMethod]
    public static WeatherState OnSetForecasts(WeatherState state, WeatherSetForecastsAction action)
    {
        return state with
        {
            Forecasts = action.Forecasts,
            Loading = false,
            Initialized = true
        };
    }

    [ReducerMethod(typeof(WeatherLoadForecastsAction))]
    public static WeatherState OnLoadForecasts(WeatherState state)
    {
        return state with
        {
            Loading = true
        };
    }

    [ReducerMethod]
    public static WeatherState OnWeatherSetState(WeatherState state, WeatherSetStateAction action)
    {
        return action.WeatherState;
    }
}