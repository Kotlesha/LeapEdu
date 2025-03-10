using LeapEdu.ViewModels;
using LeapEdu.ViewModels.Auth;
using LeapEdu.Views.Base;
using LeapEdu.Views.Catalog;

namespace LeapEdu.Views.Auth;

public partial class LoginVerificationPage : BasePage
{
    private readonly LoginVerificationViewModel _loginVerificationViewModel;

    public LoginVerificationPage(LoginVerificationViewModel loginVerificationViewModel)
    {
        InitializeComponent();

        _loginVerificationViewModel = loginVerificationViewModel;
        BindingContext = loginVerificationViewModel;

        RemoveFocusCommand = new Command(async () => 
            await CodeEntryPanel.RemoveFocusAsync(CancellationToken.None));
    }

    private void RetryButton_Pressed(object sender, EventArgs e) => _loginVerificationViewModel.RestartTimer();

    private async void AcceptButton_Pressed(object sender, EventArgs e) 
        => await _loginVerificationViewModel.NavigateToAsync<MainPage>();
}