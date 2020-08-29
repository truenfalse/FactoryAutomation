using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace FactoryAutomation.WPF
{
    public class StringToDoubleConverter : IValueConverter
    {
        public StringToDoubleConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) // Property -> Xaml
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double dVal;
            bool bResult = double.TryParse(value.ToString(), out dVal);
            if (bResult == true)
                return dVal;
            else
                return default(int);
        }
    }
}
