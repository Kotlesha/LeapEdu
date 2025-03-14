using LeapEdu.ViewModels.Auth;
using Mopups.Pages;
using Mopups.Services;

namespace LeapEdu.Controls.Popups;

public partial class LegalNoticesPopup : PopupPage
{
    public LegalNoticesPopup(LegalNoticiesViewModel legalNoticiesViewModel)
    {
        InitializeComponent();

        BindingContext = legalNoticiesViewModel;
    }

    private async void BackToRegister_Pressed(object sender, EventArgs e) => await MopupService.Instance.PopAsync();
}