using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace FactoryAutomation.WPF
{
    public class StringToFloatConverter : IValueConverter
    {
        public StringToFloatConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) // Property -> Xaml
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float fVal;
            bool bResult = float.TryParse(value.ToString(), out fVal);
            if (bResult == true)
                return fVal;
            else
                return default(int);
        }
    }
}
