using CommunityToolkit.Maui.Core.Platform;
using LeapEdu.Controls.Entries;
using LeapEdu.ViewModels;

namespace LeapEdu.Views;

public partial class LoginPage : ContentPage
{
    private readonly LoginViewModel _loginViewModel;

    public LoginPage()
    {
        InitializeComponent();

        _loginViewModel = new LoginViewModel();
        BindingContext = _loginViewModel;
    }

    private async void SignIn_Button_Pressed(object sender, EventArgs e)
    {
        if (_loginViewModel.Validate())
            await Shell.Current.GoToAsync("//loginVerification", true);
    }

    private async void RegisterLabel_Tapped(object sender, TappedEventArgs e) 
        => await Shell.Current.GoToAsync("//register", true);

    private async void RepairPassword_Tapped(object sender, TappedEventArgs e) 
        => await Shell.Current.GoToAsync("//repairPassword", true);

    private async void RemoveFocus(object sender, TappedEventArgs e)
    {
        var emailRoundedEntry = this.FindByName<RoundedEntry>("EmailEntry");
        var emailEntry = emailRoundedEntry.FindByName<Entry>("EntryField");
        await emailEntry.HideKeyboardAsync(CancellationToken.None);
    }
}