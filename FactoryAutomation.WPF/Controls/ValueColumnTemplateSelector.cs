using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FactoryAutomation.WPF
{
    public class ValueColumnTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultDataTemplate { get; set; }
        public DataTemplate IntTypeValueDataTemplate { get; set; }
        public DataTemplate FloatTypeValueDataTemplate { get; set; }
        public DataTemplate DoubleTypeValueDataTemplate { get; set; }
        public DataTemplate StringTypeValueDataTemplate { get; set; }
        public DataTemplate EnumTypeValueDataTemplate { get; set; }
        public ValueColumnTemplateSelector()
        {
                
        }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return base.SelectTemplate(item, container);
            Type PropertyType = (item as PropertyData).PropertyType;
            if (PropertyType == typeof(int))
                return IntTypeValueDataTemplate;
            else if (PropertyType == typeof(float))
                return FloatTypeValueDataTemplate;
            else if (PropertyType == typeof(double))
                return DoubleTypeValueDataTemplate;
            else if (PropertyType == typeof(string))
                return StringTypeValueDataTemplate;
            else if (PropertyType.IsEnum == true)
                return EnumTypeValueDataTemplate;
            else
                return DefaultDataTemplate;
        }
    }
}
