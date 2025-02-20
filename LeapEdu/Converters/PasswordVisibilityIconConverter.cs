using System.Globalization;

namespace LeapEdu.Converters;

internal class PasswordVisibilityIconConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool isPasswordVisible)
        {
            return isPasswordVisible ? "open_eye_icon.svg" : "close_eye_icon.svg";
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
