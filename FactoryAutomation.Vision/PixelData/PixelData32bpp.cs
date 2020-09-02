using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace FactoryAutomation.Vision.PixelData
{
    public class PixelData32bpp : IPixelData
    {
        public int Width
        {
            get
            {
                return m_Width;
            }
        }
        public int Height { get { return m_Height; } }
        public int Stride { get { return m_Stride; } }
        public IntPtr Scan0 { get { return m_Scan0; } }
        public PixelFormat Format { get { return m_Format; } }
        public byte[] Data
        {
            get
            {
                return m_Data;
            }
            set
            {
                if (value.Length != Height * Stride)
                    throw new Exception("value length is not equal allocated memory size");
                Array.Copy(value, 0, m_Data, 0, m_Data.Length);
            }
        }
        int m_Width;
        int m_Height;
        int m_Stride;
        IntPtr m_Scan0;
        PixelFormat m_Format;
        GCHandle m_Handle;
        byte[] m_Data;
        public PixelData32bpp(int Width, int Height, int Stride) : this(Width, Height, Stride, IntPtr.Zero)
        {

        }
        public PixelData32bpp(int Width, int Height, int Stride, IntPtr Scan0)
        {
            m_Width = Width;
            m_Height = Height;
            m_Stride = Stride;
            m_Data = new byte[m_Height * m_Stride];
            m_Handle = GCHandle.Alloc(m_Data, GCHandleType.Pinned);
            if (Scan0 != IntPtr.Zero)
            {
                Marshal.Copy(Scan0, m_Data, 0, m_Data.Length);
            }
            m_Scan0 = m_Handle.AddrOfPinnedObject();
            m_Format = PixelFormat.Format32bppArgb;
        }
        public void Dispose()
        {
            m_Width = 0;
            m_Height = 0;
            m_Stride = 0;
            m_Scan0 = IntPtr.Zero;
            if (m_Handle.IsAllocated == true)
                m_Handle.Free();
            m_Format = PixelFormat.Undefined;
        }
    }
}
