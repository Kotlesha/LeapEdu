using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using LeapEdu.Controls.Entries;
using Mopups.Hosting;
using LeapEdu.ViewModels;
using LeapEdu.Views;
using Mopups.Services;
using LeapEdu.Services.Interfaces;
using LeapEdu.Services.Implementations;
using LeapEdu.Controls.Buttons;
using LeapEdu.Views.CatalogPages;

namespace LeapEdu;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews()
            .ConfigureMopups()
            .ConfigureCustomFonts()
            .ConfigureHandlers();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static MauiAppBuilder ConfigureCustomFonts(this MauiAppBuilder builder)
    {
        builder.ConfigureFonts(fonts =>
        {
            fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
            fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
            fonts.AddFont("Montserrat-Regular.ttf", "MontserratRegular");
            fonts.AddFont("Montserrat-Medium.ttf", "MontserratMedium");
        });

        return builder;
    }

    public static MauiAppBuilder ConfigureHandlers(this MauiAppBuilder builder)
    {
        builder.ConfigureMauiHandlers(handlers =>
        {
#if ANDROID
            handlers.AddHandler(typeof(Entry), typeof(Platforms.Android.Handlers.CustomEntryHandler));
            handlers.AddHandler(typeof(BackspaceEntry), typeof(Platforms.Android.Handlers.BackspaceEntryHandler));
#endif
#if IOS
            handlers.AddHandler(typeof(Entry), typeof(Platforms.iOS.Handlers.CustomEntryHandler));
#endif
        });

        return builder;
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
        mauiAppBuilder.Services.AddSingleton(MopupService.Instance);

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<LoginViewModel>();
        mauiAppBuilder.Services.AddTransient<LoginVerificationViewModel>();
        mauiAppBuilder.Services.AddTransient<RegisterViewModel>();
        mauiAppBuilder.Services.AddTransient<RepairPasswordViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<LoginPage>();
        mauiAppBuilder.Services.AddTransient<LoginVerificationPage>();
        mauiAppBuilder.Services.AddTransient<RegisterPage>();
        mauiAppBuilder.Services.AddTransient<RepairPasswordPage>();

        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddSingleton<CourseCatalogPage>();
        mauiAppBuilder.Services.AddSingleton<UserCoursesPage>();
        mauiAppBuilder.Services.AddSingleton<BasketPage>();

        return mauiAppBuilder;
    }
}
