using Fluxor;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWithFluxor.Client.Store.UserFeedback;
public class UserFeedbackEffects
{
    private readonly HttpClient _httpClient;
    public UserFeedbackEffects(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [EffectMethod]
    public async Task SubmitUserFeedback(UserFeedbackSubmitAction action, IDispatcher dispatcher)
    {
        var response = await _httpClient.PostAsJsonAsync("Feedback", action.UserFeedbackModel);

        if (response.IsSuccessStatusCode)
        {
            dispatcher.Dispatch(new UserFeedbackSubmitSuccessAction());
        }
        else
        {
            dispatcher.Dispatch(new UserFeedbackSubmitFailureAction(response.ReasonPhrase));
        }
    }
}