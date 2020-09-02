using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using FactoryAutomation.Vision.PixelData;

namespace FactoryAutomation.Vision
{
    public sealed class VBitmap : IImage
    {
        public int Width
        {
            get
            {
                if(PixelData == null)
                    return 0;
                return PixelData.Width;
            }
        }
        public int Height
        {
            get
            {
                if (PixelData == null)
                    return 0;
                return PixelData.Height;
            }
        }
        public IPixelData PixelData
        {
            get
            {
                return m_PixelData;
            }
        }
        IPixelData m_PixelData;
        public PixelFormat Format
        {
            get
            {
                return m_PixelData.Format;
            }
        }
        public ColorPalette Palette
        {
            get
            {
                return m_Palette;
            }
            set
            {
                m_Palette = value;
            }
        }
        ColorPalette m_Palette;
        Bitmap m_Bitmap;
        public VBitmap(string FileName)
        {
            Bitmap tempBitmap = Bitmap.FromFile(FileName) as Bitmap;
            m_Palette = tempBitmap.Palette;
            BitmapData imgdata = tempBitmap.LockBits(new Rectangle(0, 0, tempBitmap.Width, tempBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            m_PixelData = CreatePixelData(imgdata.Width, imgdata.Height, imgdata.Stride, imgdata.PixelFormat, imgdata.Scan0);
            tempBitmap.UnlockBits(imgdata);
            m_Bitmap = new Bitmap(m_PixelData.Width, m_PixelData.Height, m_PixelData.Stride, m_PixelData.Format, m_PixelData.Scan0);
        }
        public VBitmap(Bitmap Bitmap)
        {
            Bitmap tempBitmap = Bitmap;
            m_Palette = tempBitmap.Palette;
            BitmapData imgdata = tempBitmap.LockBits(new Rectangle(0, 0, tempBitmap.Width, tempBitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            m_PixelData = CreatePixelData(imgdata.Width, imgdata.Height, imgdata.Stride, imgdata.PixelFormat, imgdata.Scan0);
            tempBitmap.UnlockBits(imgdata);
            m_Bitmap = new Bitmap(m_PixelData.Width, m_PixelData.Height, m_PixelData.Stride, m_PixelData.Format, m_PixelData.Scan0);
        }
        public VBitmap(int _Width, int _Height, PixelFormat _Format) : this(new Bitmap(_Width, _Height, _Format))
        {

        }
        ~VBitmap()
        {
            if(m_PixelData != null)
                m_PixelData.Dispose();
            if (m_Bitmap != null)
                m_Bitmap.Dispose();
        }
        public void Initialize(int _Width, int _Height, int _Stride, PixelFormat _Format, IntPtr _Scan0)
        {
            if (m_PixelData != null)
                m_PixelData.Dispose();
            m_PixelData = CreatePixelData(_Width, _Height, _Stride, _Format, _Scan0);
        }
        private IPixelData CreatePixelData(int _Width, int _Height, int _Stride, PixelFormat _Format, IntPtr _Scan0)
        {
            switch(_Format)
            {
                case PixelFormat.Format8bppIndexed:
                    {
                        return new PixelData8bpp(_Width, _Height, _Stride, _Scan0);
                    }
                case PixelFormat.Format24bppRgb:
                    {
                        return new PixelData24bpp(_Width, _Height, _Stride, _Scan0);
                    }
                case PixelFormat.Format32bppArgb:
                    {
                        return new PixelData32bpp(_Width, _Height, _Stride, _Scan0);
                    }
                default:
                    {
                        throw new NotSupportedException("this Type does not support");
                    }
            }
        }
        public Bitmap ToBitmap()
        {
            return m_Bitmap;
        }

        public object Clone()
        {
            return new VBitmap(m_Bitmap);
        }
    }
}
