using CommunityToolkit.Maui.Core.Platform;
using LeapEdu.Controls.Entries.Code;
using LeapEdu.ViewModels;

namespace LeapEdu.Views;

public partial class LoginVerificationPage : ContentPage
{
    private readonly LoginVerificationViewModel _loginVerificationViewModel;

    public LoginVerificationPage(LoginVerificationViewModel loginVerificationViewModel)
    {
        InitializeComponent();

        _loginVerificationViewModel = loginVerificationViewModel;
        BindingContext = loginVerificationViewModel;
    }

    private async void RemoveFocus(object sender, TappedEventArgs e)
    {
        var grid = CodeEntryPanel.FindByName<Grid>("CodeGrid");
        var codeEntryItem = grid.Children.FirstOrDefault() as CodeEntryItem;
        var enrty = codeEntryItem.FindByName<Entry>("CodeEntry");

        await enrty.HideKeyboardAsync(CancellationToken.None);
    }

    private void RetryButton_Pressed(object sender, EventArgs e) => _loginVerificationViewModel.RestartTimer();
}