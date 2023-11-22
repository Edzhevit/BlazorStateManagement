using Blazored.LocalStorage;
using Fluxor;
using System.Threading.Tasks;
using System;

namespace BlazorWithFluxor.Client.Store.Counter;

public class CounterEffects
{
    private readonly ILocalStorageService _localStorageService;
    private const string CounterStatePersistenceName = "BlazorWithFluxor_CounterState";

    public CounterEffects(ILocalStorageService localStorageService)
    {
        _localStorageService = localStorageService;
    }

    [EffectMethod]
    public async Task PersistState(CounterPersistStateAction action, IDispatcher dispatcher)
    {
        try
        {
            await _localStorageService.SetItemAsync(CounterStatePersistenceName, action.CounterState);
            dispatcher.Dispatch(new CounterPersistStateSuccessAction());
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new CounterPersistStateFailureAction(ex.Message));
        }
    }

    [EffectMethod(typeof(CounterLoadStateAction))]
    public async Task LoadState(IDispatcher dispatcher)
    {
        try
        {
            var counterState = await _localStorageService.GetItemAsync<CounterState>(CounterStatePersistenceName);
            if (counterState is not null)
            {
                dispatcher.Dispatch(new CounterSetStateAction(counterState));
                dispatcher.Dispatch(new CounterLoadStateSuccessAction());
            }
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new CounterLoadStateFailureAction(ex.Message));
        }
    }

    [EffectMethod(typeof(CounterClearStateAction))]
    public async Task ClearState(IDispatcher dispatcher)
    {
        try
        {
            await _localStorageService.RemoveItemAsync(CounterStatePersistenceName);
            dispatcher.Dispatch(new CounterSetStateAction(new CounterState { CurrentCount = 0 }));
            dispatcher.Dispatch(new CounterClearStateSuccessAction());
        }
        catch (Exception ex)
        {
            dispatcher.Dispatch(new CounterClearStateFailureAction(ex.Message));
        }
    }
}