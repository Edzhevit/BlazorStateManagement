using BlazorWithFluxor.Shared;

namespace BlazorWithFluxor.Client.Store.UserFeedback;

public record UserFeedbackSubmitAction(UserFeedbackModel UserFeedbackModel);


// Toaster Actions
public record UserFeedbackSubmitSuccessAction();
public record UserFeedbackSubmitFailureAction(string ErrorMessage);