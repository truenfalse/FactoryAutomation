using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FactoryAutomation.Designer.Views
{
    /// <summary>
    /// TitleBarTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TitleBarView : UserControl
    {
        Window MainWindow;
        bool IsMouseDown;
        Point DownMainWIndowPoint;
        Point DownMousePoint;
        public TitleBarView()
        {
            InitializeComponent();
            MainWindow = Application.Current.MainWindow;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(IsMouseDown == false)
            {
                CaptureMouse();
                double Left = MainWindow.Left;
                double Top = MainWindow.Top;
                DownMainWIndowPoint = new Point(Left, Top);
                DownMousePoint = PointToScreen(Mouse.GetPosition(MainWindow));
                IsMouseDown = true;
            }
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(IsMouseDown == true)
            {
                Point CurrentMousePoint = PointToScreen(Mouse.GetPosition(MainWindow));
                (MainWindow as MainWindow).Left = DownMainWIndowPoint.X + (CurrentMousePoint.X - DownMousePoint.X);
                (MainWindow as MainWindow).Top = DownMainWIndowPoint.Y + (CurrentMousePoint.Y - DownMousePoint.Y);
            }
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ReleaseMouseCapture();
            IsMouseDown = false;
        }
        private DependencyObject FindMainWindow()
        {
            DependencyObject dependencyObj = this.TemplatedParent;
            while (dependencyObj.GetType() != typeof(MainWindow))
            {
                dependencyObj = VisualTreeHelper.GetParent(this);
            }
            return dependencyObj;
        }
    }
}
