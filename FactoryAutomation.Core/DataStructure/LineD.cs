using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryAutomation.DataStructure
{
    [Serializable]
    public struct LineD
    {
        public double m
        {
            get
            {
                if (m_P2.X - m_P1.X == 0)
                    return (m_P2.Y - m_P1.Y) / 0.000000001;
                return (m_P2.Y - m_P1.Y) / (m_P2.X - m_P1.X);
            }
        }
        public double n
        {
            get
            {
                return m_P1.Y - (m * m_P1.X);
            }
        }
        // ax + c = -by
        // -(a/1) = m
        // -(c/1) = n
        // a = -m
        // c = -n
        public double a
        {
            get
            {
                return -m;
            }
        }
        public double b
        {
            get
            {
                return 1;
            }
        }
        public double c
        {
            get
            {
                return -n;
            }
        }
        public PointD StartPoint
        {
            get
            {
                return m_P1;
            }
            set
            {
                m_P1 = value;
            }
        }
        PointD m_P1;
        public PointD EndPoint
        {
            get
            {
                return m_P2;
            }
            set
            {
                m_P2 = value;
            }
        }

        PointD m_P2;
        public LineD(PointD _P1,PointD _P2)
        {
            m_P1 = _P1;
            m_P2 = _P2;
        }
        // y = mx + n
        public LineD(double _m, double _n,double _x1 = 1000000.0, double _x2 = -1000000.0)
        {
            m_P1 = new PointD(_x1, (_m * _x1) + _n);
            m_P2 = new PointD(_x2, (_m * _x2) + _n);
        }
        // ax + by + c = 0
        public LineD(double _a,double _b, double _c, double _x1 = 1.0, double _x2 = -1.0)
        {
            m_P1 = new PointD(_x1, -((_a * _x1 +_c) / _b));
            m_P2 = new PointD(_x2, -((_a * _x2 + _c) / _b));
        }

        public LineD(double _m, PointD _P1) : this(_m, _P1.Y - (_m * _P1.X))
        {
            
        }
    }
}
