using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Lab_5.Enums;

namespace Lab_5.Converters
{
    public class ImagePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ninjaType = (NinjaType)value;
            ninjaType = ninjaType != 0 ? ninjaType : NinjaType.Genin;

            var uri = new Uri($@"D:\3 year\KPZ\kpz\Lab_5\Lab_5\Images\{ninjaType}.png", UriKind.Absolute);
            var image = new BitmapImage(uri);

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}