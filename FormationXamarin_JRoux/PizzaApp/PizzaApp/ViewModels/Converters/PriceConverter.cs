using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PizzaApp.ViewModels.Converters
{
    internal class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal) value;

            if (price == 0)
                return "";

            return price.ToString("C", CultureInfo.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string baseValue = value as string;
            decimal outputValue;

                if (decimal.TryParse(baseValue, out outputValue))
                {
                    return outputValue;
                }

                return default(decimal);
            
        }
    }
}
