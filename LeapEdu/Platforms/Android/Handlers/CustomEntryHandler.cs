using Android.Graphics;
using Android.OS;
using AndroidX.AppCompat.Widget;
using LeapEdu.Extensions;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Handlers;
using Graphics = Android.Graphics;

namespace LeapEdu.Platforms.Android.Handlers;

internal class CustomEntryHandler : EntryHandler
{
    private EventHandler<AppThemeChangedEventArgs>? _themeChangedHandler;

    protected override void ConnectHandler(AppCompatEditText platformView)
    {
        platformView.Background = null;
        base.ConnectHandler(platformView);

        if (VirtualView.IsPassword)
        {
            platformView.CustomSelectionActionModeCallback = null;
            platformView.LongClickable = false;
        }

        UpdateHighlightColor(platformView);
        UpdateCursorColor(platformView);

        _themeChangedHandler += (o, e) =>
        {
            UpdateHighlightColor(platformView);
            UpdateCursorColor(platformView);
        };

        App.Current!.RequestedThemeChanged += _themeChangedHandler;
    }

    private static void UpdateHighlightColor(AppCompatEditText platformView)
    {
        var color = Application.Current!.Resources.GetAppThemeColor("BackgroundColor");
        platformView.SetHighlightColor(color.ToAndroid());
    }

    private static void UpdateCursorColor(AppCompatEditText platformView)
    {
        if (Build.VERSION.SdkInt < BuildVersionCodes.Q) return;

        var color = Application.Current!.Resources.GetAppThemeColor("CursorColor");
        platformView.TextCursorDrawable!.SetTint(color.ToAndroid());

        var f = new BlendModeColorFilter(color.ToAndroid(), Graphics.BlendMode.SrcIn);

        platformView.TextSelectHandleLeft!.SetColorFilter(f);
        platformView.TextSelectHandleRight!.SetColorFilter(f);
        platformView.TextSelectHandle!.SetColorFilter(f);
    }

    protected override void DisconnectHandler(AppCompatEditText platformView)
    {
        if (_themeChangedHandler is not null)
        {
            Application.Current!.RequestedThemeChanged -= _themeChangedHandler;
            _themeChangedHandler = null;
        }

        base.DisconnectHandler(platformView);
    }
}
