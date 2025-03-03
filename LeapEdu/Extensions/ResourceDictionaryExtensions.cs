﻿using CommunityToolkit.Maui;

namespace LeapEdu.Extensions;

public static class ResourceDictionaryExtensions
{
    public static Color? GetAppThemeColor(this ResourceDictionary resources, string key)
    {
        var isDarkMode = Application.Current!.RequestedTheme == AppTheme.Dark;

        if (resources.TryGetValue(key, out var resource) && resource is AppThemeColor appThemeColor)
        {
            return isDarkMode ? appThemeColor.Dark : appThemeColor.Light;
        }

        return default;
    }

    public static object? GetAppThemeIcon(this ResourceDictionary resources, string key)
    {
        var isDarkMode = Application.Current!.RequestedTheme == AppTheme.Dark;

        if (resources.TryGetValue(key, out var resource) && resource is AppThemeObject appThemeObject)
        {
            return isDarkMode ? appThemeObject.Light : appThemeObject.Dark;
        }

        return default;
    }
}
