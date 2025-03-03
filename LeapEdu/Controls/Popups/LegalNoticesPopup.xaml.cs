using LeapEdu.ViewModels;
using Mopups.Pages;
using Mopups.Services;
using Plugin.Maui.MarkdownView;

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