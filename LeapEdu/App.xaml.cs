using LeapEdu.Views;

namespace LeapEdu;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        var loginPage = serviceProvider.GetRequiredService<LoginPage>();

        MainPage = new NavigationPage(loginPage)
        {
            BackgroundColor = App.Current.Resources["BackgroundColor"] as Color
        };
    }
}
