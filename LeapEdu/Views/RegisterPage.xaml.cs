using CommunityToolkit.Maui.Core.Platform;
using LeapEdu.Controls.Entries;
using LeapEdu.ViewModels;

namespace LeapEdu.Views;

public partial class RegisterPage : ContentPage
{
    private readonly RegisterViewModel _registerViewModel;

    public RegisterPage()
    {
        InitializeComponent();

        _registerViewModel = new();
        BindingContext = _registerViewModel;
    }

    private async void RemoveFocus(object sender, TappedEventArgs e)
    {
        var nameRoundedEntry = this.FindByName<RoundedEntry>("NameRoundedEntry");
        var nameEntry = nameRoundedEntry.FindByName<Entry>("EntryField");
        await nameEntry.HideKeyboardAsync(CancellationToken.None);
    }

    private void RegisterButton_Pressed(object sender, EventArgs e)
    {
        _registerViewModel.Validate();
    }
}