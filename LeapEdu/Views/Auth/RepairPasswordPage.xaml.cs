using LeapEdu.Controls.Popups;
using LeapEdu.ViewModels;
using LeapEdu.ViewModels.Auth;
using LeapEdu.Views.Base;
using Mopups.Interfaces;

namespace LeapEdu.Views.Auth;

public partial class RepairPasswordPage : BasePage
{
    private readonly RepairPasswordViewModel _repairPasswordViewModel;
    private readonly IPopupNavigation _popupNavigation;

    public RepairPasswordPage(
        RepairPasswordViewModel repairPasswordViewModel, 
        IPopupNavigation popupNavigation)
    {
        InitializeComponent();

        _repairPasswordViewModel = repairPasswordViewModel;
        BindingContext = repairPasswordViewModel;
        _popupNavigation = popupNavigation;

        RemoveFocusCommand = new Command(async () =>
            await EmailForRepairEntry.RemoveFocusAsync(CancellationToken.None));
    }

    private async void RepairPasswordButton_Pressed(object sender, EventArgs e)
    {
        if (_repairPasswordViewModel.Validate())
        {
            var closeCommand = new Command(async () =>
            {
                await _popupNavigation.PopAsync();
                await _repairPasswordViewModel.GoBackAsync();
            });

            var alertPopupViewModel = new AlertPopupViewModel(
                message: $"На вашу почту {EmailForRepairEntry.Text} отправлена ссылка для восстановления пароля!",
                closeCommand: closeCommand);

            await _popupNavigation.PushAsync(new AlertPopup(alertPopupViewModel));
        }
    }
}