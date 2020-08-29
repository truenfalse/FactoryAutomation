using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FactoryAutomation.Common
{
    [Serializable]
    public struct CircleD
    {
        public PointD Center
        {
            get
            {
                return m_Center;
            }
            set
            {
                m_Center = value;
            }
        }
        PointD m_Center;
        public double Radius
        {
            get
            {
                return m_Radius;
            }
            set
            {
                m_Radius = value;
            }
        }
        double m_Radius;
        public RectangleD BoundingBox
        {
            get
            {
                return new RectangleD(m_Center.X - m_Radius,m_Center.Y - m_Radius, m_Radius + m_Radius, m_Radius + m_Radius);
            }
        }
        public CircleD(PointD _Center, double _Radius)
        {
            m_Center = _Center;
            m_Radius = _Radius;
        }
        public CircleD(double _X, double _Y, double _Radius)
        {
            m_Center = new PointD(_X, _Y);
            m_Radius = _Radius;
        }
    }
}
