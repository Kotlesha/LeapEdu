using LeapEdu.ViewModels;
using LeapEdu.Views.Base;

namespace LeapEdu.Views;

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
    }

    private async void SignIn_Button_Pressed(object sender, EventArgs e)
    {
        if (_loginViewModel.Validate())
        {
            await _loginViewModel.NavigateToAsync<LoginVerificationPage>(
                new Dictionary<string, object>
                {
                    ["Email"] = EmailEntry.Text
                });
        }
    }

    private async void RegisterLabel_Tapped(object sender, TappedEventArgs e) 
        => await _loginViewModel.NavigateToAsync<RegisterPage>();

    private async void RepairPassword_Tapped(object sender, TappedEventArgs e) 
        => await _loginViewModel.NavigateToAsync<RepairPasswordPage>();
}