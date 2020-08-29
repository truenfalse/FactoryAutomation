using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FactoryAutomation.DataStructure
{
    [Serializable]
    public struct XY
    {
        public double X
        {
            get
            {
                return m_X;
            }
            set
            {
                m_X = value;
            }
        }
        double m_X;
        public double Y
        {
            get
            {
                return m_Y;
            }
            set
            {
                m_Y = value;
            }
        }
        double m_Y;

        public XY(double _X, double _Y)
        {
            m_X = _X;
            m_Y = _Y;
        }
        public static explicit operator Point(XY _P1)
        {
            return new Point((int)_P1.X, (int)_P1.Y);
        }
        public static explicit operator PointF(XY _P1)
        {
            return new PointF((float)_P1.X, (float)_P1.Y);
        }
        public static implicit operator PointD(XY _P1)
        {
            return new PointD(_P1.X, _P1.Y);
        }
        public static bool operator ==(XY _P1, XY _P2)
        {
            bool result = false;
            if (_P1.X == _P2.X && _P1.Y == _P2.Y)
                result = true;
            return result;
        }
        public static bool operator !=(XY _P1, XY _P2)
        {
            bool result = false;
            if (_P1.X != _P2.X || _P1.Y != _P2.Y)
                result = true;
            return result;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
