using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Text;

namespace FactoryAutomation.Vision.PixelData
{
    public interface IPixelData : IDisposable
    {
        int Width { get; }
        int Height { get; }
        int Stride { get; }
        IntPtr Scan0 { get; }
        byte[] Data { get; set; }
        PixelFormat Format { get; }
    }
}
