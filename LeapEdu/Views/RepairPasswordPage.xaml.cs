using CommunityToolkit.Maui.Core.Platform;
using LeapEdu.Controls.Entries;
using LeapEdu.ViewModels;

namespace LeapEdu.Views;

public partial class RepairPasswordPage : ContentPage
{
    private readonly RepairPasswordViewModel _repairPasswordViewModel;

    public RepairPasswordPage()
    {
        InitializeComponent();

        _repairPasswordViewModel = new();
        BindingContext = _repairPasswordViewModel;
    }

    private async void RemoveFocus(object sender, TappedEventArgs e)
    {
        var emailRoundedEntry = this.FindByName<RoundedEntry>("EmailRoundedEntry");
        var emailEntry = emailRoundedEntry.FindByName<Entry>("EntryField");
        await emailEntry.HideKeyboardAsync(CancellationToken.None);
    }

    private void RepairPasswordButton_Pressed(object sender, EventArgs e)
    {
        _repairPasswordViewModel.Validate();
    }
}