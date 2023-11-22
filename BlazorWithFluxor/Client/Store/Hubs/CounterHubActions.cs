namespace BlazorWithFluxor.Client.Store.Hubs;

public record CounterHubStartAction();
public record CounterHubSetConnectedAction(bool Connected);
public record CounterHubReceiveCountAction(int Count);
public record CounterHubSendCountAction(int Count);
public record CounterHubSendCountFailedAction(string Message);