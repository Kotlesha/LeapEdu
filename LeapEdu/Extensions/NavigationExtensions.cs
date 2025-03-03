using LeapEdu.Extensions.Сonstants;

namespace LeapEdu.Extensions;

public static class NavigationExtensions
{
    public static async Task CustomPushAsync(
        this INavigation navigation,
        Page newPage,
        uint duration = NavigationConstants.DefaultDuration,
        Easing? easing = null)
    {
        easing ??= NavigationConstants.DefaultEasingIn;

        var width = Application.Current!.MainPage!.Width;
        newPage.TranslationX = width / NavigationConstants.PreviousPageOffsetFactor;
        newPage.Opacity = NavigationConstants.InitialOpacity;

        await navigation.PushAsync(newPage, false);

        var moveAnimation = newPage.TranslateTo(0, 0, duration, easing);
        var fadeAnimation = newPage.FadeTo(1, duration / 2);

        await Task.WhenAll(moveAnimation, fadeAnimation);
    }

    public static async Task CustomPopAsync(
        this INavigation navigation,
        uint duration = NavigationConstants.DefaultDuration,
        Easing? easing = null)
    {
        easing ??=  NavigationConstants.DefaultEasingOut;

        if (navigation.NavigationStack.Count < 2)
            return;

        var previousPage = navigation.NavigationStack[^2];
        var width = Application.Current!.MainPage!.Width;

        previousPage.TranslationX = -width / NavigationConstants.PreviousPageOffsetFactor;
        previousPage.Opacity = NavigationConstants.PreviousPageOpacity;

        await navigation.PopAsync(false);

        var moveAnimation = previousPage.TranslateTo(0, 0, duration, easing);
        var fadeAnimation = previousPage.FadeTo(1, duration / 2);

        await Task.WhenAll(moveAnimation, fadeAnimation);
    }
}

