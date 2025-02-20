using CommunityToolkit.Maui.Core.Platform;
using LeapEdu.Controls.Entries.Code;

namespace LeapEdu.Views;

public partial class LoginVerificationPage : ContentPage
{
    public LoginVerificationPage() => InitializeComponent();

    private async void RemoveFocus(object sender, TappedEventArgs e)
    {
        var codeEntryPanel = this.FindByName<CodeEntry>("CodeEntryPanel");
        var grid = codeEntryPanel.FindByName<Grid>("CodeGrid");
        var codeEntryItem = grid.Children.FirstOrDefault() as CodeEntryItem;
        var enrty = codeEntryItem.FindByName<Entry>("CodeEntry");

        await enrty.HideKeyboardAsync(CancellationToken.None);
    }
}