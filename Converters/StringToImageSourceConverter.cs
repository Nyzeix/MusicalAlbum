using Microsoft.Maui.Controls;
using System;
using System.Globalization;

namespace MusicalAlbum.Converters
{
    public class StringToImageSourceConverter : IValueConverter
    {
        // Converts string object to ImageSource
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string path && !string.IsNullOrEmpty(path))
            {
                // Cas 1 : URL absolue
                if (Uri.IsWellFormedUriString(path, UriKind.Absolute))
                    return ImageSource.FromUri(new Uri(path));

                // Cas 2 : chemin local (MAUI image intégrée)
                return ImageSource.FromFile(path);
            }

            // Fallback = image par défaut
            return "default_image.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
