using BlazorWithFluxor.Shared;

namespace BlazorWithFluxor.Client.Store.Weather;

public record WeatherLoadForecastsAction();
public record WeatherSetForecastsAction(WeatherForecast[] Forecasts);
public record WeatherSetStateAction(WeatherState WeatherState);
public record WeatherLoadStateAction();
public record WeatherPersistStateAction(WeatherState WeatherState);
public record WeatherClearStateAction();


// Toaster Actions
public record WeatherLoadForecastsSuccessAction();
public record WeatherLoadStateSuccessAction();
public record WeatherLoadStateFailureAction(string ErrorMessage);
public record WeatherPersistStateSuccessAction();
public record WeatherPersistStateFailureAction(string ErrorMessage);
public record WeatherClearStateSuccessAction();
public record WeatherClearStateFailureAction(string ErrorMessage);