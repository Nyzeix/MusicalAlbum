using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace MusicalAlbum.Converters
{
    public class DurationToTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int seconds && seconds >= 0)
            {
                int m = seconds / 60;
                int s = seconds % 60;
                return $"{m:D2}:{s:D2}"; // format mm:ss
            }
            return "00:00";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
