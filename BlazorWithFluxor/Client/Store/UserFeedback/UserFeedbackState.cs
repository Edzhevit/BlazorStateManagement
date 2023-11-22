using BlazorWithFluxor.Shared;
using Fluxor;
using static System.String;

namespace BlazorWithFluxor.Client.Store.UserFeedback;

[FeatureState]
public record UserFeedbackState
{
    public bool Submitting { get; init; } = false;
    public bool Submitted { get; init; } = false;
    public string ErrorMessage { get; init; } = Empty;
    public UserFeedbackModel Model { get; init; } = new();
}