using Fluxor;

namespace BlazorWithFluxor.Client.Store.UserFeedback;

public static class UserFeedbackReducers
{
    [ReducerMethod(typeof(UserFeedbackSubmitAction))]
    public static UserFeedbackState OnSubmit(UserFeedbackState state)
    {
        return state with
        {
            Submitting = true
        };
    }

    [ReducerMethod(typeof(UserFeedbackSubmitSuccessAction))]
    public static UserFeedbackState OnSubmitSuccess(UserFeedbackState state)
    {
        return state with
        {
            Submitting = false,
            Submitted = true
        };
    }

    [ReducerMethod]
    public static UserFeedbackState OnSubmitFailure(UserFeedbackState state, UserFeedbackSubmitFailureAction action)
    {
        return state with
        {
            Submitting = false,
            ErrorMessage = action.ErrorMessage
        };
    }
}