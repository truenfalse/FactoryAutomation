using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace FactoryAutomation.WPF
{
    public class StringToIntConverter : IValueConverter
    {
        public StringToIntConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) // Property -> Xaml
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int iVal;
            bool bResult = int.TryParse(value.ToString(), out iVal);
            if (bResult == true)
                return iVal;
            else
                return default(int);
        }
    }
}
