namespace LeapEdu.Services.Interfaces;

public interface INavigationService
{
    Task NavigateToAsync<TPage>(
        IDictionary<string, object>? parameters = null, 
        bool animated = true) where TPage : Page;

    Task GoBackAsync(bool animated = true);
}
