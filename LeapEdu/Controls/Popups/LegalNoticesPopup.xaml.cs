using Indiko.Maui.Controls.Markdown;
using Mopups.Pages;
using Mopups.Services;

namespace LeapEdu.Controls.Popups;

public partial class LegalNoticesPopup : PopupPage
{
	public LegalNoticesPopup()
	{
		InitializeComponent();
    }

    private async void BackToRegister_Pressed(object sender, EventArgs e)
    {
		await MopupService.Instance.PopAsync();
    }
}