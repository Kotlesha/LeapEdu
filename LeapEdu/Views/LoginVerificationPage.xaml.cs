using LeapEdu.ViewModels;
using LeapEdu.Views.Base;

namespace LeapEdu.Views;

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
}