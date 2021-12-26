using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Ebd.Mobile.Converters
{
    public class HasItemsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = value is IEnumerable<object> items && (items?.Any() ?? false);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
