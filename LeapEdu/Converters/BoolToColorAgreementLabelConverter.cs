using System.Globalization;

namespace LeapEdu.Converters;

public class BoolToColorAgreementLabelConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool IsValid)
        {
            var invalidColor = (Color)App.Current!.Resources["InvalidDataColor"];
            var normalColor = (Color)App.Current!.Resources["DefaultLabelTextColor"];

            return IsValid ? normalColor : invalidColor;
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }
}
