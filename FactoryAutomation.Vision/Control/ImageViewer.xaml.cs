using System;
using System.Collections.Generic;
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

namespace FactoryAutomation.Vision.Control
{
    /// <summary>
    /// ImageViewer.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ImageViewer : UserControl
    {
        public static readonly DependencyProperty IsFitProperty;
        public bool IsFit
        {
            get
            {
                return (bool)GetValue(IsFitProperty);
            }
            set
            {
                SetValue(IsFitProperty, value);
            }
        }
        static ImageViewer()
        {
            FrameworkPropertyMetadata IsFItMetaData = new FrameworkPropertyMetadata();
            IsFItMetaData.AffectsRender = true;
            IsFItMetaData.DefaultValue = false;
            IsFItMetaData.PropertyChangedCallback = new PropertyChangedCallback(IsFit_PropertyChangedCallback);
            IsFitProperty = DependencyProperty.Register("IsFit", typeof(bool), typeof(ImageViewer), IsFItMetaData);

            FrameworkPropertyMetadata WidthMetaData = new FrameworkPropertyMetadata();
            WidthMetaData.AffectsRender = true;
            WidthMetaData.PropertyChangedCallback = new PropertyChangedCallback(Size_PropertyChangedCallback);
            FrameworkElement.WidthProperty.OverrideMetadata(typeof(ImageViewer), WidthMetaData);

            FrameworkPropertyMetadata HeightMetaData = new FrameworkPropertyMetadata();
            HeightMetaData.AffectsRender = true;
            HeightMetaData.PropertyChangedCallback = new PropertyChangedCallback(Size_PropertyChangedCallback);
            FrameworkElement.HeightProperty.OverrideMetadata(typeof(ImageViewer), HeightMetaData);
        }

        private static void Size_PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageViewer imageViewer = d as ImageViewer;
            if (imageViewer.IsFit == true)
            {
                TransformGroup transformGroup = new TransformGroup();
                ScaleTransform scaleTransform = new ScaleTransform();
                scaleTransform.ScaleX = imageViewer.Width / imageViewer.ImageControl.Source.Width;
                scaleTransform.ScaleY = imageViewer.Height / imageViewer.ImageControl.Source.Height;
                transformGroup.Children.Add(scaleTransform);
                imageViewer.ImageControl.RenderTransform = transformGroup;
            }
        }
       
        private static void IsFit_PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageViewer imageViewer = d as ImageViewer;
            if (imageViewer == null)
                return;
            if ((bool)e.NewValue == true)
            {
                TransformGroup transformGroup = new TransformGroup();
                ScaleTransform scaleTransform = new ScaleTransform();
                scaleTransform.ScaleX = imageViewer.Width / imageViewer.ImageControl.Source.Width;
                scaleTransform.ScaleY = imageViewer.Height/ imageViewer.ImageControl.Source.Height;
                transformGroup.Children.Add(scaleTransform);
                imageViewer.ImageControl.RenderTransform = transformGroup;
            }
            else
            {
                TransformGroup transformGroup = new TransformGroup();
                ScaleTransform scaleTransform = new ScaleTransform();
                scaleTransform.ScaleX = 1;
                scaleTransform.ScaleY = 1;
                transformGroup.Children.Add(scaleTransform);
                imageViewer.ImageControl.RenderTransform = transformGroup;
            }
        }

        public ImageViewer()
        {
            InitializeComponent();
        }
    }
}
