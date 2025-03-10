using LeapEdu.Extensions;
using LeapEdu.ViewModels.Auth;
using LeapEdu.Views.Base;
using System.Net;

namespace LeapEdu.Views.Auth;

public partial class LoginPage : BasePage
{
    private readonly LoginViewModel _loginViewModel;

    public LoginPage(LoginViewModel loginViewModel)
    {
        InitializeComponent();

        _loginViewModel = loginViewModel;
        BindingContext = loginViewModel;

        RemoveFocusCommand = new Command(async () =>
            await EmailEntry.RemoveFocusAsync(CancellationToken.None));

        App.Current.RequestedThemeChanged += ThemeChanged;
    }


    private void ThemeChanged(object? sender, AppThemeChangedEventArgs e)
    {
        //var buttonColor = App.Current!.Resources.GetAppThemeColor("BackgroundAuthButtonColor");

        //But.Refresh();
    }

    private async void SignIn_Button_Pressed(object sender, EventArgs e)
    {
        if (_loginViewModel.Validate())
        {
            await _loginViewModel.NavigateToAsync<LoginVerificationPage>(
                new Dictionary<string, object>
                {
                    ["Email"] = WebUtility.UrlEncode(EmailEntry.Text)
                });
        }
    }

    private async void RegisterLabel_Tapped(object sender, TappedEventArgs e) 
        => await _loginViewModel.NavigateToAsync<RegisterPage>();

    private async void RepairPassword_Tapped(object sender, TappedEventArgs e) 
        => await _loginViewModel.NavigateToAsync<RepairPasswordPage>();
}