using FactoryAutomation.WPF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FactoryAutomation.Designer.ViewModels
{
    public class TitleBarViewModel : ViewModelBase
    {
        public CommandBase WindowMinimizeCommand { get; set; }
        public CommandBase WindowStateChangeCommand { get; set; }
        public CommandBase WindowCloseCommand { get; set; }
        public string Title { get; set; }
        public bool IsMaximized { get; set; }
        Point NormalStateLocation;
        Size NormalStateSize;

        public TitleBarViewModel()
        {
            WindowMinimizeCommand = new CommandBase(WindowMinimizeAction);
            WindowStateChangeCommand = new CommandBase(WindowStateChangeAction);
            WindowCloseCommand = new CommandBase(WindowCloseAction);
        }

        private void WindowCloseAction(object obj)
        {
            Application.Current.MainWindow.Close();
        }

        private void WindowStateChangeAction(object obj)
        {
            if(IsMaximized == false)
            {
                NormalStateLocation = new Point(Application.Current.MainWindow.Left, Application.Current.MainWindow.Top);
                NormalStateSize = new Size(Application.Current.MainWindow.ActualWidth, Application.Current.MainWindow.ActualHeight);
                Application.Current.MainWindow.Left = 0;
                Application.Current.MainWindow.Top = 0;
                Application.Current.MainWindow.Width = 1920;
                Application.Current.MainWindow.Height = 1080;
                IsMaximized = true;
            }
            else
            {
                Application.Current.MainWindow.Width = NormalStateSize.Width;
                Application.Current.MainWindow.Height = NormalStateSize.Height;
                Application.Current.MainWindow.Left = NormalStateLocation.X;
                Application.Current.MainWindow.Top = NormalStateLocation.Y;
                IsMaximized = false;
            }
        }

        private void WindowMinimizeAction(object obj)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        
    }
}
