using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using LeapEdu.Controls.Entries;

namespace LeapEdu;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
                fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
                fonts.AddFont("Montserrat-Medium.ttf", "MontserratMedium");
            })
            .ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                handlers.AddHandler(typeof(Entry), typeof(Platforms.Android.Handlers.CustomEntryHandler));
                handlers.AddHandler(typeof(BackspaceEntry), typeof(Platforms.Android.Handlers.BackspaceEntryHandler));
#endif
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
