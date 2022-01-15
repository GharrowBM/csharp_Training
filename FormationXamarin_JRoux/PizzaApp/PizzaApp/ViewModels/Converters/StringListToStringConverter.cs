using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace PizzaApp.ViewModels.Converters
{
    internal class StringListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> list = value as List<string>;
            string endResult = string.Empty;


            if (list != null)
            {
                if (list.Count > 0)
                {
                    endResult = string.Join(", ", list);
                }
            }

            return endResult;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> list = new List<string>();

            string baseString = value as string;
            if (baseString != null)
            {
                var array = baseString.Split(new[] {',', ' '});
                list = array.ToList();
            }

            return list;
        }
    }
}
