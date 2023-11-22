using BlazorWithFluxor.Client.Store.UserFeedback;
using BlazorWithFluxor.Shared;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace BlazorWithFluxor.Client.Pages;

public partial class UserFeedback
{
    [Inject] private IState<UserFeedbackState> UserFeedbackState { get; set; }
    [Inject] private IDispatcher Dispatcher { get; set; }
    
    private UserFeedbackModel Model => UserFeedbackState.Value.Model;

    private void HandleValidSubmit()
    {
        Dispatcher.Dispatch(new UserFeedbackSubmitAction(UserFeedbackState.Value.Model));
    }
}