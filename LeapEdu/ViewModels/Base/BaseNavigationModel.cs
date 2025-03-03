using CommunityToolkit.Mvvm.ComponentModel;
using LeapEdu.Services.Interfaces;

namespace LeapEdu.ViewModels.Base;

public abstract class BaseNavigationModel : ObservableObject
{
    protected readonly INavigationService _navigationService;

    protected BaseNavigationModel(
        INavigationService navigationService) => _navigationService = navigationService;

    public async Task NavigateToAsync<TPage>(
        IDictionary<string, object>? parameters = null,
        bool animated = true) where TPage : Page
    {
        await _navigationService.NavigateToAsync<TPage>(parameters, animated);
    }

    public async Task GoBackAsync(bool animated = true) => await _navigationService.GoBackAsync(animated);
}
