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
        public static readonly DependencyProperty TitleProperty;
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        Window MainWindow;
        bool IsMouseDown;
        Point DownMainWIndowPoint;
        Point DownMousePoint;
        
        static TitleBarView()
        {
            FrameworkPropertyMetadata metaData = new FrameworkPropertyMetadata();
            metaData.AffectsMeasure = true;
            metaData.DefaultValue = "MainWindow";
            metaData.PropertyChangedCallback = new PropertyChangedCallback(Title_PropertyChangedCallback);
            TitleProperty = DependencyProperty.Register("Title",typeof(string), typeof(TitleBarView), metaData);
        }

        private static void Title_PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as TitleBarView).TitleTextBlock.Text = (d as TitleBarView).Title;
        }

        public TitleBarView()
        {
            MainWindow = Application.Current.MainWindow;
            InitializeComponent();
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(IsMouseDown == false && e.ClickCount == 1)
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

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Close();
        }

        private void btnChangeWindowState_Click(object sender, RoutedEventArgs e)
        {
            if(MainWindow.WindowState != WindowState.Maximized)
                MainWindow.WindowState = WindowState.Maximized;
            else
                MainWindow.WindowState = WindowState.Normal;
        }

        private void btnChangeWindowStateMinimized_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.WindowState = WindowState.Minimized;
        }
    }
}
