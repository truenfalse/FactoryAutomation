using FactoryAutomation.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FactoryAutomation.Designer.ViewModels
{
    public class MainVIewModel : ViewModelBase
    {
        private int m_DefaultProperty;
        private int m_ReadOnlyProperty;
        private int m_NoVisibleProperty;
        private float m_FloatProperty;
        private double m_DoubleProperty;

        [Category("ABCD")]
        public int DefaultProperty 
        {
            get
            {
                return m_DefaultProperty;
            }
            set 
            {
                Set<int>(ref m_DefaultProperty, value);
            }
        }
        [Category("ABCD")]
        public int ReadOnlyProperty
        {
            get
            {
                return m_ReadOnlyProperty;
            }
        }
        [Category("NoVisible")]
        public int NoVisibleProperty
        {
            get
            {
                return m_NoVisibleProperty;
            }
            set
            {
                Set<int>(ref m_NoVisibleProperty, value);
            }
        }
        public ViewModelBase AAA
        {
            get; set;
        }
        public float FloatProperty
        {
            get
            {
                return m_FloatProperty;
            }
            set
            {
                Set<float>(ref m_FloatProperty, value);
            }
        }
        public double DoubleProperty
        {
            get
            {
                return m_DoubleProperty;
            }
            set
            {
                Set<double>(ref m_DoubleProperty, value);
            }
        }
        public MainVIewModel()
        {
 
        }
    }
}
