using LeapEdu.Extensions;
using LeapEdu.Services.Interfaces;

namespace LeapEdu.Services.Implementations;

public class NavigationService(IServiceProvider serviceProvider) : INavigationService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task NavigateToAsync<TPage>(
        IDictionary<string, object>? parameters = null, 
        bool animated = true) where TPage : Page
    {
        var page = _serviceProvider.GetRequiredService<TPage>();

        if (page.BindingContext is IQueryAttributable viewModel)
        {
            viewModel.ApplyQueryAttributes(parameters ?? new Dictionary<string, object>());
        }

        if (page is IQueryAttributable pageWithQueryParameters)
        {
            pageWithQueryParameters.ApplyQueryAttributes(parameters ?? new Dictionary<string, object>());
        }

        var navigation = Application.Current!.MainPage!.Navigation;

        if (animated)
        {
            await navigation.CustomPushAsync(page);
            return;
        }

        await navigation.PushAsync(page, false);
    }

    public async Task GoBackAsync(bool animated = true)
    {
        var navigation = Application.Current!.MainPage!.Navigation;

        if (navigation.NavigationStack.Count <= 1) return;

        if (animated)
        {
            await navigation.CustomPopAsync();
            return;
        }

        await navigation.PopAsync(false);
    }
}


