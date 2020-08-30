using FactoryAutomation.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Designer.ViewModels
{
    public class ViewModelLocator
    {
        public MainVIewModel Main
        {
            get
            {
                return ServiceLocator.Current.Resolve<MainVIewModel>();
            }
        }
        public TitleBarViewModel TitleBar
        {
            get
            {
                return ServiceLocator.Current.Resolve<TitleBarViewModel>();
            }
        }
        public ViewModelLocator()
        {

        }
    }
}
