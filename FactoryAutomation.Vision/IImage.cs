using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using FactoryAutomation.Vision.PixelData;
namespace FactoryAutomation.Vision
{
    public interface IImage : ICloneable
    {
        int Width { get; }
        int Height { get; }
        IPixelData PixelData { get; }
        ColorPalette Palette { get; set; }
        void Initialize(int _Width, int _Height, int _Stride, PixelFormat _Format, IntPtr _Scan0);
        Bitmap ToBitmap();
    }
}
