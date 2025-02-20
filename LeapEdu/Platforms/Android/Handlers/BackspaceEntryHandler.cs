using Android.Views;
using AndroidX.AppCompat.Widget;
using LeapEdu.Controls.Entries;
using static Android.Views.View;

namespace LeapEdu.Platforms.Android.Handlers;

internal class BackspaceEntryHandler : CustomEntryHandler
{
    protected override void ConnectHandler(AppCompatEditText platformView)
    {
        base.ConnectHandler(platformView);
        platformView.KeyPress += OnKeyPressed;
    }

    private void OnKeyPressed(object? sender, KeyEventArgs e)
    {
        if (e.Event?.Action != KeyEventActions.Down) return;

        var isBackspaceEvent = e.KeyCode == Keycode.Del && string.IsNullOrEmpty(PlatformView.Text);

        if (isBackspaceEvent)
        {
            (VirtualView as BackspaceEntry)?.InvokeBackspace();
        }

        e.Handled = isBackspaceEvent;
    }

    protected override void DisconnectHandler(AppCompatEditText platformView)
    {
        platformView.KeyPress -= OnKeyPressed;
        base.DisconnectHandler(platformView);
    }
}
