using LeapEdu.ViewModels.Auth;
using Mopups.Pages;

namespace LeapEdu.Controls.Popups;

public partial class AlertPopup : PopupPage
{
    public AlertPopup(AlertPopupViewModel alertPopupViewModel)
    {
        InitializeComponent();

        BindingContext = alertPopupViewModel;
    }
}