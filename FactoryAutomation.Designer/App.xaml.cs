using FactoryAutomation.Core;
using FactoryAutomation.Designer.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FactoryAutomation.Designer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class FactoryAutomationApp : Application
    {
        public FactoryAutomationApp()
        {

        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ServiceLocator.Initialize(() =>
            {
                return new Container();
            });

            ServiceLocator.Current.Register<MainVIewModel>();
            ServiceLocator.Current.Register<MainWindow>();

            MainWindow = ServiceLocator.Current.Resolve<MainWindow>();
            MainWindow.ShowDialog();
        }
    }
}
