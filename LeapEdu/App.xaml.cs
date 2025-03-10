using LeapEdu.Extensions;
using LeapEdu.Views;

namespace LeapEdu;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        var loginPage = serviceProvider.GetRequiredService<LoginPage>();
        var mainPage = serviceProvider.GetRequiredService<MainPage>();

        MainPage = new NavigationPage(mainPage);
        UpdateMainPageBackgroundColor();

        App.Current!.RequestedThemeChanged += (o, e) => UpdateMainPageBackgroundColor();
    }

    private void UpdateMainPageBackgroundColor() 
        => MainPage!.BackgroundColor = App.Current!.Resources.GetAppThemeColor("BackgroundColor");
}
