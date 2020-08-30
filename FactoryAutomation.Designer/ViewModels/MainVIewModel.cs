using FactoryAutomation.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FactoryAutomation.Designer.ViewModels
{
    public enum EnumA
    {
        A,
        B,
        C,
        D,
    }
    public class MainVIewModel : ViewModelBase
    {
        public EnumA A
        {
            get;set;
        }
        public MainVIewModel()
        {
 
        }
    }
}
