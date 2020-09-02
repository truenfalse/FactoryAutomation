using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryAutomation.Vision
{
    public delegate void ImageEventHandler(object sender, ImageEventArgs args);
    public class ImageEventArgs : EventArgs
    {
        public IImage Image { get; set; }
    }
}
