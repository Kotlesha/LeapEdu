using System.Globalization;

namespace LeapEdu.Converters;

public class TimeRemainingToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        int remainingSeconds = (int)value;

        if (remainingSeconds > 0)
        {
            return $"{remainingSeconds / 60:D2}:{remainingSeconds % 60:D2}";
        }

        return "сейчас";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
