using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace FactoryAutomation.Common
{
    [Serializable]
    public struct RectangleD
    {
        PointD m_TopLeft;
        PointD m_BottomRight;

        public double X
        {
            get
            {
                return m_TopLeft.X;
            }
            set
            {
                double deltaX = value - m_TopLeft.X;
                m_TopLeft.X = value;
                m_BottomRight.X = m_BottomRight.X + deltaX;
            }
        }
        public double Y
        {
            get
            {
                return m_TopLeft.Y;
            }
            set
            {
                double deltaY = value - m_TopLeft.Y;
                m_TopLeft.Y = value;
                m_BottomRight.Y = m_BottomRight.Y + deltaY;
            }
        }
        public double Top
        {
            get
            {
                return m_TopLeft.Y;
            }
            set
            {
                m_BottomRight.Y = value;
            }
        }
        public double Bottom
        {
            get
            {
                return m_BottomRight.Y;
            }
            set
            {
                m_BottomRight.Y = value;
            }
        }
        public double Left
        {
            get
            {
                return m_TopLeft.X;
            }
            set
            {
                m_TopLeft.X = value;
            }
        }
        public double Right
        {
            get
            {
                return m_BottomRight.X;
            }
            set
            {
                m_BottomRight.X = value;
            }
        }
        public double Width
        {
            get
            {
                return m_BottomRight.X - m_TopLeft.X;
            }
            set
            {
                m_BottomRight.X = m_TopLeft.X + value;
            }
        }
        public double Height
        {
            get
            {
                return m_BottomRight.Y - m_TopLeft.Y;
            }
            set
            {
                m_BottomRight.Y = m_TopLeft.Y + value;
            }
        }
        public PointD TopLeft
        {
            get
            {
                return m_TopLeft;
            }
            set
            {
                m_TopLeft = value;
            }
        }
        public PointD TopRight
        {
            get
            {
                return new PointD(m_BottomRight.X, m_TopLeft.Y);
            }
            set
            {
                m_BottomRight.X = value.X;
                m_TopLeft.Y = value.Y;
            }
        }
        public PointD BottomLeft
        {
            get
            {
                return new PointD(m_TopLeft.X, m_BottomRight.Y);
            }
            set
            {
                m_TopLeft.X = value.X;
                m_BottomRight.Y = value.Y;
            }
        }
        public PointD BottomRight
        {
            get
            {
                return m_BottomRight;
            }
            set
            {
                m_BottomRight = value;
            }
        }



        public RectangleD(double _X, double _Y , double _Width, double _Height)
        {
            m_TopLeft = new PointD(_X, _Y);
            m_BottomRight = new PointD(_X + _Width, _Y + _Height);
        }
        public RectangleD(PointD _TopLeft, PointD _BottomRight)
        {
            m_TopLeft = _TopLeft;
            m_BottomRight = _BottomRight;
        }
        public bool IsContains(PointD _Point)
        {
            if(m_TopLeft <= _Point && m_BottomRight >= _Point)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static explicit operator RectangleD(RectangleF _RectF)
        {
            return new RectangleD(_RectF.X, _RectF.Y, _RectF.Width, _RectF.Height);
        }
        public static explicit operator RectangleD(Rectangle _Rect)
        {
            return new RectangleD(_Rect.X, _Rect.Y, _Rect.Width, _Rect.Height);
        }
        public static implicit operator RectangleF(RectangleD _RectD)
        {
            return new RectangleF((float)_RectD.X, (float)_RectD.Y, (float)_RectD.Width, (float)_RectD.Height);
        }
        public static implicit operator Rectangle(RectangleD _RectD)
        {
            return new Rectangle((int)_RectD.X, (int)_RectD.Y, (int)_RectD.Width, (int)_RectD.Height);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(X);
            sb.Append(',');
            sb.Append(Y);
            sb.Append(',');
            sb.Append(Width);
            sb.Append(',');
            sb.Append(Height);
            return sb.ToString();
        }
        public static RectangleD Parse(string RectToString)
        {
            string[] splitString = RectToString.Split(',');
            double X = double.Parse(splitString[0]);
            double Y = double.Parse(splitString[1]);
            double W = double.Parse(splitString[2]);
            double H = double.Parse(splitString[3]);
            return new RectangleD(X, Y, W, H);
        }
    }
}
