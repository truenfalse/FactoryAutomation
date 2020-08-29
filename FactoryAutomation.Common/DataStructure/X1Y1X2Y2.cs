using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace FactoryAutomation.Common
{
    public struct X1Y1X2Y2
    {
        public double X1
        {
            get
            {
                return m_XY1.X;
            }
            set
            {
                m_XY1.X = value;
            }
        }
        public double Y1
        {
            get
            {
                return m_XY1.Y;
            }
            set
            {
                m_XY1.Y = value;
            }
        }
        public double X2
        {
            get
            {
                return m_XY2.X;
            }
            set
            {
                m_XY2.X = value;
            }
        }
        public double Y2
        {
            get
            {
                return m_XY2.Y;
            }
            set
            {
                m_XY2.Y = value;
            }
        }
        XY m_XY1;
        XY m_XY2;

        public X1Y1X2Y2(double _X1, double _Y1,double _X2,double _Y2)
        {
            m_XY1 = new XY(_X1, _Y1);
            m_XY2 = new XY(_X2, _Y2);
        }
        public X1Y1X2Y2(XY _XY1, XY _XY2)
        {
            m_XY1 = _XY1;
            m_XY2 = _XY2;
        }
        public static bool operator ==(X1Y1X2Y2 _X1Y1X2Y21, X1Y1X2Y2 _X1Y1X2Y22)
        {
            bool result = false;
            if (_X1Y1X2Y21.m_XY1 == _X1Y1X2Y22.m_XY1 && _X1Y1X2Y21.m_XY2 == _X1Y1X2Y22.m_XY2)
                result = true;
            return result;
        }
        public static bool operator !=(X1Y1X2Y2 _X1Y1X2Y21, X1Y1X2Y2 _X1Y1X2Y22)
        {
            bool result = false;
            if (_X1Y1X2Y21.m_XY1 != _X1Y1X2Y22.m_XY1 || _X1Y1X2Y21.m_XY2 != _X1Y1X2Y22.m_XY2)
                result = true;
            return result;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return (this == (X1Y1X2Y2)obj);
        }
    }
}
