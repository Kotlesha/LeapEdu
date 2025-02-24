using CommunityToolkit.Maui.Core.Platform;
using LeapEdu.Controls.Entries;
using LeapEdu.Controls.Popups;
using LeapEdu.ViewModels;
using Mopups.Services;
using System.Threading.Tasks;

namespace LeapEdu.Views;

public partial class RepairPasswordPage : ContentPage
{
    private readonly RepairPasswordViewModel _repairPasswordViewModel;

    public RepairPasswordPage(RepairPasswordViewModel repairPasswordViewModel)
    {
        InitializeComponent();

        _repairPasswordViewModel = repairPasswordViewModel;
        BindingContext = repairPasswordViewModel;
    }

    private async void RemoveFocus(object sender, TappedEventArgs e)
    {
        var emailRoundedEntry = this.FindByName<RoundedEntry>("EmailRoundedEntry");
        var emailEntry = emailRoundedEntry.FindByName<Entry>("EntryField");

        await emailEntry.HideKeyboardAsync(CancellationToken.None);
    }

    private async void RepairPasswordButton_Pressed(object sender, EventArgs e)
    {
        if (_repairPasswordViewModel.Validate())
            await MopupService.Instance.PushAsync(new AlertPopup());
    }
}