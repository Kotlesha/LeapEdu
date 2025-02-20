using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;

namespace LeapEdu.Platforms.Android.Handlers;

internal class CustomEntryHandler : EntryHandler
{
    protected override void ConnectHandler(AppCompatEditText platformView)
    {
        platformView.Background = null;
        base.ConnectHandler(platformView);

        var color = (Color)Application.Current!.Resources["BackgroundColor"];
        platformView.SetHighlightColor(color.ToAndroid());
    }
}
