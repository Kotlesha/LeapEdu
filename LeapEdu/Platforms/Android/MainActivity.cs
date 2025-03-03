using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using CommunityToolkit.Maui;

namespace LeapEdu
{
    [Activity(Theme = "@style/LeapEduTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var color = (Color)App.Current!.Resources["NavigationBarColor"];
            Window?.SetNavigationBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
            //Window?.SetStatusBarColor(Android.Graphics.Color.ParseColor(color.ToHex()));
        }
    }
}