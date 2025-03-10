using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace LeapEdu.Platforms.iOS.Handlers;

internal class CustomEntryHandler : EntryHandler
{
    protected override void ConnectHandler(MauiTextField platformView)
    {
        base.ConnectHandler(platformView);

        platformView.BorderStyle = UIKit.UITextBorderStyle.None;
        platformView.Background = null;
    }
}
