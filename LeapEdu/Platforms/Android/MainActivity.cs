using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using LeapEdu.Extensions;

namespace LeapEdu
{
    [Activity(Theme = "@style/LeapEduTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            UpdateStatusNavigationBarsColor();
            UpdateStatusNavigationBarIconsColor();

            App.Current!.RequestedThemeChanged += (o, e) =>
            {
                UpdateStatusNavigationBarsColor();
                UpdateStatusNavigationBarIconsColor();
            };
        }

        private void UpdateStatusNavigationBarsColor()
        {
            var color = App.Current!.Resources.GetAppThemeColor("NavigationBarColor");
            Window?.SetNavigationBarColor(Android.Graphics.Color.ParseColor(color!.ToHex()));
            Window?.SetStatusBarColor(Android.Graphics.Color.ParseColor(color!.ToHex()));
        }

        private void UpdateStatusNavigationBarIconsColor()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.M) return;

            var isDarkTheme = App.Current!.RequestedTheme == AppTheme.Dark;

            var decorView = Window?.DecorView;
            var flags = decorView.SystemUiFlags;

            if (!isDarkTheme)
            {
                flags |= (SystemUiFlags.LightStatusBar | SystemUiFlags.LightNavigationBar);
            }
            else
            {
                flags &= ~(SystemUiFlags.LightStatusBar | SystemUiFlags.LightNavigationBar);
            }

            decorView.SystemUiFlags = flags;
        }
    }
}