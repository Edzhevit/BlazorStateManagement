namespace BlazorWithFluxor.Client.Store.Counter;

public record CounterIncrementAction();
public record CounterSetStateAction(CounterState CounterState);
public record CounterPersistStateAction(CounterState CounterState);
public record CounterLoadStateAction();
public record CounterClearStateAction();


// Toaster Actions
public record CounterPersistStateSuccessAction();
public record CounterPersistStateFailureAction(string ErrorMessage);
public record CounterLoadStateSuccessAction();
public record CounterLoadStateFailureAction(string ErrorMessage);
public record CounterClearStateSuccessAction();
public record CounterClearStateFailureAction(string ErrorMessage);