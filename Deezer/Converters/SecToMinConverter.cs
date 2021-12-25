using System;
using System.Globalization;
using Xamarin.Forms;

namespace Deezer.Converters
{
    public class SecToMinConverter: IValueConverter
    {


        // Value => int seconds
        // Result time formated : mm:ss
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, (int)value);
            return timeSpan.ToString(@"mm\:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
