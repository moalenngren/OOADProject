using System;
using System.Globalization;
using Xamarin.Forms;

namespace OOADProject.Converters
{
    public class ItemTapEventArgsToSelectedItemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as ItemTapEventArgs;
            return eventArgs?.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}





