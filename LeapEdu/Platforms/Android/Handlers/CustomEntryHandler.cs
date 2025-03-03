using AndroidX.AppCompat.Widget;
using LeapEdu.Extensions;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;

namespace LeapEdu.Platforms.Android.Handlers;

internal class CustomEntryHandler : EntryHandler
{
    protected override void ConnectHandler(AppCompatEditText platformView)
    {
        platformView.Background = null;
        base.ConnectHandler(platformView);

        if (VirtualView.IsPassword)
        {
            platformView.CustomSelectionActionModeCallback = null;
            platformView.LongClickable = false;
        }

        var color = Application.Current!.Resources.GetAppThemeColor("BackgroundColor");
        platformView.SetHighlightColor(color.ToAndroid());
    }
}
