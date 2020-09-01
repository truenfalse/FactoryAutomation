using FactoryAutomation.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Designer.ViewModels
{
    public class ViewModelLocator
    {
        public MainVIewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.Resolve<MainVIewModel>();
            }
        }
        public MainContentPageViewModel TitleBar
        {
            get
            {
                return ServiceLocator.Current.Resolve<MainContentPageViewModel>();
            }
        }
        public ViewModelLocator()
        {

        }
    }
}
