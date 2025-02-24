using CommunityToolkit.Maui.Core.Platform;
using LeapEdu.Controls.Entries;
using LeapEdu.Controls.Popups;
using LeapEdu.ViewModels;
using Mopups.Services;

namespace LeapEdu.Views;

public partial class RegisterPage : ContentPage
{
    private readonly RegisterViewModel _registerViewModel;

    public RegisterPage(RegisterViewModel registerViewModel)
    {
        InitializeComponent();

        _registerViewModel = registerViewModel;
        BindingContext = registerViewModel;
    }

    private async void RemoveFocus(object sender, TappedEventArgs e)
    {
        var nameRoundedEntry = this.FindByName<RoundedEntry>("NameRoundedEntry");
        var nameEntry = nameRoundedEntry.FindByName<Entry>("EntryField");

        await nameEntry.HideKeyboardAsync(CancellationToken.None);
    }

    private void RegisterButton_Pressed(object sender, EventArgs e) => _registerViewModel.Validate();

    private async void TermsOfUse_Tapped(object sender, TappedEventArgs e)
    {
        await MopupService.Instance.PushAsync(new LegalNoticesPopup(), true);
    }

    private async void PrivacyPolicy_Tapped(object sender, TappedEventArgs e)
    {
        await MopupService.Instance.PushAsync(new LegalNoticesPopup(), true);
    }
}