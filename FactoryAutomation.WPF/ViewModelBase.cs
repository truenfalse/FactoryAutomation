using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using FactoryAutomation.Abstract;

namespace FactoryAutomation.WPF
{
    public abstract class ViewModelBase : ObservableObject
    {
        public static bool IsInDesignMode 
        {
            get
            {
                return m_IsInDesignMode;
            }
        }
        static bool m_IsInDesignMode;
        public string ViewName
        {
            get
            {
                return m_ViewName;
            }
            set
            {
                Set<string>(ref m_ViewName, value);
            }
        }
        string m_ViewName;
        static ViewModelBase()
        {
            DependencyObject dobject = new DependencyObject();
            m_IsInDesignMode = DesignerProperties.GetIsInDesignMode(dobject);
        }
        public ViewModelBase()
        {

        }
    }
}
